using Mawingu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VenueMaker.Models;
using WayfindR.Models;

namespace VenueMaker.Dialogs
{
    public partial class EditMapPointsAndEdgesDialog : Form
    {
        
        public WFVenue Venue { get; set; }
        public WFNode Node { get; set; }
        public WFEdge<WFNode> Edge { get; set; }
        

        public EditMapPointsAndEdgesDialog()
        {
            InitializeComponent();
        }


        private void InitUI()
        {
            try
            {
                MapsBS.DataSource = Venue.Maps;
                MapsBS.CurrentChanged += MapsBS_CurrentChanged1;

                MapCombo.DataSource = MapsBS;
                MapCombo.DisplayMember = nameof(WFMap.Title);
                MapCombo.ValueMember = nameof(WFMap.Id);

                if (Node != null)
                {
                    Text = $"Välj plats på karta för {Node.Name}";
                    WFMapPoint mp = Node.MapPoint;
                    if (!string.IsNullOrWhiteSpace(mp.MapId))
                    {
                        MapCombo.SelectedValue = mp.MapId;

                    } // Not null
                    ClearDirectionPointsBtn.Visible = false;

                }
                else if (Edge != null)
                {
                    Text = $"Markera vägbeskrivning på karta för {Edge.Start.Name} -> {Edge.Destination.Name}";
                    WFMapPoint mp = Edge.Start.MapPoint;
                    if (!string.IsNullOrWhiteSpace(mp.MapId))
                    {
                        MapCombo.SelectedValue = mp.MapId;

                    } // Not null
                    ClearDirectionPointsBtn.Visible = true;

                } // What

                
                MapsBS.ResetBindings(false);

            }
            catch (Exception ex)
            {
                string errmsg = $"Fel när formuläret skulle initieras: {ex.Message}";
                throw new Exception(errmsg);

            }
        }

        private void MapsBS_CurrentChanged1(object sender, EventArgs e)
        {
            try
            {
                WFMap m = MapsBS.Current as WFMap;
                if (m != null)
                {
                    if (MapPB.Image != null)
                    {
                        MapPB.Image.Dispose();
                        MapPB.Image = null;

                    } // Has image

                    string img = Path.Combine(GetDataFilesFolder(), m.FileName);
                    if (!File.Exists(img))
                    {
                        return;

                    } // Doesn't exists

                    MapPB.Image = Image.FromFile(img);

                }

            }
            catch
            {
            }
        }

        private void MapPB_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                MousePositionLabel.Text = $"x: {e.X}, y: {e.Y}";

            }
            catch
            {
            }

        }

        private void MapPB_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                WFMap m = MapsBS.Current as WFMap;
                if (m == null)
                {
                    return;

                } // No map


                // Mouse down
                WFMapPoint mp = new WFMapPoint()
                {
                    MapId = m.Id,
                    X = e.X,
                    Y = e.Y
                };

                if (Node != null)
                {
                    Node.MapPoint = mp;

                }
                else if (Edge != null)
                {
                    List<WFMapPoint> mps = Edge.MapPoints.ToList();
                    mps.Add(mp);
                    Edge.MapPoints = mps.ToArray();
                    
                } // What

                MapPB.Refresh();
                
            }
            catch
            {
            }
        }

        private void MapPB_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                WFMap currentmap = MapsBS.Current as WFMap;
                if (currentmap == null)
                {
                    return;

                } // No map

                float radius = 10;

                Font f = new Font("Arial", 9);


                foreach (WFNode n in Venue.NodesGraph.GetNodesAlphabetical())
                {
                    Brush b = Brushes.ForestGreen;

                    if (n == Node)
                    {
                        b = Brushes.Red;

                    } // The node we edit
                    if (Edge != null &&
                        (n == Edge.Start ||
                        n == Edge.Destination))
                    {
                        b = Brushes.Red;

                    } // The edge we edit

                    if (n.MapPoint.MapId != currentmap.Id)
                    {
                        continue;

                    } // Not on the same map

                    RectangleF r = new RectangleF(
                        (float)(n.MapPoint.X - radius),
                        (float)(n.MapPoint.Y - radius),
                        radius * 2,
                        radius * 2
                        );

                    e.Graphics.FillEllipse(b, r);
                    if (ShowNamesChk.Checked)
                    {
                        e.Graphics.DrawString(
                            n.Name,
                            f,
                            b,
                            r.Right + 2,
                            r.Top
                            );

                    } // Show node names

                } // foreach Node on Venue

                // Paint the navigation
                if (Edge != null)
                {
                    using (Pen p = new Pen(Color.Red))
                    {
                        p.Width = 5;
                        
                        
                        Point fromP = new Point(
                            Convert.ToInt32(Edge.Start.MapPoint.X),
                            Convert.ToInt32(Edge.Start.MapPoint.Y)
                            );

                        foreach (WFMapPoint mp in Edge.MapPoints)
                        {
                            if (mp.MapId != currentmap.Id)
                            {
                                continue;

                            } // Not on the same map

                            Point toP = new Point(
                                Convert.ToInt32(mp.X),
                                Convert.ToInt32(mp.Y)
                                );

                            e.Graphics.DrawLine(p, fromP, toP);
                            fromP = toP;

                        } // foreach MapPoint

                        Point destP = new Point(
                            Convert.ToInt32(Edge.Destination.MapPoint.X),
                            Convert.ToInt32(Edge.Destination.MapPoint.Y)
                            );
                        e.Graphics.DrawLine(p, fromP, destP);

                    } // using Pen

                } // Is edge


            }
            catch
            {
            }

        }

        private void EditMapPointsAndEdgesDialog_Load(object sender, EventArgs e)
        {
            try
            {
                InitUI();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public string GetDataFilesFolder()
        {
            string folder = Path.Combine(
                Preferences.Me.DataFolder,
                Venue.Id
                );

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);

            } // Create it

            return folder;
        }

        private void ShowNamesChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                MapPB.Refresh();
            }
            catch (Exception ex)
            {
                string errmsg = $"Fel när kartan skulle ritas om: {ex.Message}";
                MessageBox.Show(errmsg, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void ClearDirectionPointsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Edge != null)
                {
                    Edge.MapPointsStr = string.Empty;
                    MapPB.Refresh();

                } // Not null

            }
            catch (Exception ex)
            {
                string errmsg = $"Fel när vägbeskrivningarna skulle rensas: {ex.Message}";
                LogCenter.Error("ClearDirectionsBtnClick", ex.Message);
                MessageBox.Show(errmsg, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
