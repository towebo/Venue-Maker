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
using WayfindR.Controllers;
using WayfindR.Models;

namespace VenueMaker.Dialogs
{
    public partial class MainForm : Form
    {



        public WFVenue Venue { get; set; }


        public MainForm()
        {
            InitializeComponent();
        }



        private void InitUI()
        {
            try
            {
                VenueBS.DataSource = new WFVenue();
                VenueBS.CurrentChanged += (s1, e1) =>
                {
                    WFVenue v = VenueBS.Current as WFVenue;
                    if (v != null)
                    {
                        POIsBS.DataSource = v.PointsOfInterest;

                    }
                    else
                    {
                        POIsBS.DataSource = new WFPointOfInterest[] { };

                    }

                };


                VenueNameTB.DataBindings.Add("Text", VenueBS, "Name");
                VenueIDTB.DataBindings.Add("Text", VenueBS, "Id");
                AddressTB.DataBindings.Add("Text", VenueBS, "Address");
                ZipTB.DataBindings.Add("Text", VenueBS, "Zip");
                CityTB.DataBindings.Add("Text", VenueBS, "City");
                CountryTB.DataBindings.Add("Text", VenueBS, "Country");


                POIsBS.DataSource = new WFPointOfInterest[] { };
                POIsBS.CurrentChanged += (s2, e2) =>
                {
                    WFPointOfInterest p = POIsBS.Current as WFPointOfInterest;
                    if (p != null &&
                    p.Information != null)
                    {
                        POIInfosBS.DataSource = p.Information;

                    }
                    else
                    {
                        POIInfosBS.DataSource = new WFPOIInformation[] { };

                    }

                };

                POIsLB.DataSource = POIsBS;
                POIsLB.DisplayMember = "Name";
                POIsLB.ValueMember = "Name";


                POIInfosBS.DataSource = new WFPOIInformation[] { };
                

                POIInfosLB.DataSource = POIInfosBS;
                POIInfosLB.DisplayMember = "Information";
                POIInfosLB.ValueMember = "Information";
                POIInformationTB.DataBindings.Add("Text", POIInfosBS, "Information");
                POIInfoStartsTB.DataBindings.Add("Text", POIInfosBS, "StartsAt", true);
                POIInfoEndsTB.DataBindings.Add("Text", POIInfosBS, "EndsAt", true);




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }




        private void closeAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newVenueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewVenue();

        }

        private void CreateNewVenue()
        {
            try
            {
                Venue = new WFVenue();
                SaveVenueDialog.FileName = "";

                VenueBS.DataSource = Venue;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void openVenueFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenVenueDialog.ShowDialog() != DialogResult.OK)
                {
                    return;

                }

                SaveVenueDialog.FileName = OpenVenueDialog.FileName;

                Venue = WFVenue.LoadFromFile(OpenVenueDialog.FileName);
                string graphfile = Path.ChangeExtension(
                    OpenVenueDialog.FileName,
                    OpenGraphMLDialog.DefaultExt
                    );                
                if (File.Exists(graphfile))
                {                    
                    WFGraph g = WFGraph.LoadFromGraphML(graphfile);
                    Venue.NodesGraph = g;
                    Venue.AddPOIsFromGraph();

                }
                                
                VenueBS.DataSource = Venue;

                SystemSounds.Asterisk.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void saveVenueFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveVenueDialog.ShowDialog() != DialogResult.OK)
                {
                    return;

                }
                Venue.SaveToFile(SaveVenueDialog.FileName);

                SystemSounds.Asterisk.Play();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitUI();

                CreateNewVenue();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void AddPOIInfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                WFPointOfInterest p = POIsBS.Current as WFPointOfInterest;
                if (p == null)
                {
                    return;

                }

                WFPOIInformation newinfo = new WFPOIInformation();

                List<WFPOIInformation> poiis;
                if (p.Information != null)
                {
                    poiis = p.Information.ToList();

                }
                else
                {
                    poiis = new List<WFPOIInformation>();

                }

                poiis.Add(newinfo);

                p.Information = poiis.ToArray();

                POIsBS.ResetBindings(false);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void RemovePOIInfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                WFPointOfInterest p = POIsBS.Current as WFPointOfInterest;
                if (p == null)
                {
                    return;

                }

                
                WFPOIInformation poii = POIInfosBS.Current as WFPOIInformation;
                if (poii == null)
                {
                    return;

                }


                if (p.Information == null)
                {
                    return;

                }

                List<WFPOIInformation> poiis;
                poiis = p.Information.ToList();
                poiis.Remove(poii);
                p.Information = poiis.ToArray();
                POIsBS.ResetBindings(false);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void MoveInfoUpButton_Click(object sender, EventArgs e)
        {
            try
            {
                WFPOIInformation selone = POIInfosBS.Current as WFPOIInformation;
                if (selone == null)
                {
                    return;

                }

                int selidx = POIInfosBS.IndexOf(selone);
                WFPOIInformation[] items = POIInfosBS.DataSource as WFPOIInformation[];
                if (items == null)
                {
                    return;

                }

                int swapidx;
                
                if (sender == MoveInfoUpButton)
                {
                    swapidx = selidx - 1;
                                        
                }
                else
                {
                    swapidx = selidx + 1;

                }


                if (swapidx < 0 ||
                    swapidx > items.Length)
                {
                    return;

                }

                WFPOIInformation swapone = items[swapidx];
                items[swapidx] = selone;
                items[selidx] = swapone;
                
                POIInfosBS.ResetBindings(false);
                if (sender == MoveInfoUpButton)
                {
                    POIInfosBS.MovePrevious();

                }
                else
                {
                    POIInfosBS.MoveNext();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
