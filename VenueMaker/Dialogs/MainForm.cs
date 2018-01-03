#define WITHADMINRIGHTS

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VenueMaker.Controllers;
using VenueMaker.Utils;
using WayfindR.Controllers;
using WayfindR.Models;
using VenueMaker.Helpers;
using VenueMaker.Models;
using WayfindR.Helpers;
using WayfindR.Helpers;
using WayfindR;
using WayfindR.Helpers;
using Mawingu;


namespace VenueMaker.Dialogs
{
    public partial class MainForm : Form
    {
        private WFNode[] elevators;
        private const double ElevatorTravelTime = 20.0;



        public WFVenue Venue { get; set; }


        public MainForm()
        {
            InitializeComponent();
        }



        private void InitUI()
        {
            try
            {
                this.Text = AssemblyInfo.GetProductAndVersion();

                // Disable stuff for nomal users
                bool hasadminrights = false;
#if WITHADMINRIGHTS
                hasadminrights = true;
#endif
                newVenueToolStripMenuItem.Visible = hasadminrights;
                saveVenueFileAsToolStripMenuItem.Visible = hasadminrights;




                VenueBS.DataSource = new WFVenue();
                VenueBS.CurrentChanged += (s1, e1) =>
                {
                    WFVenue v = VenueBS.Current as WFVenue;
                    RefreshUIForVenue(v);

                };

                

                VenueNameTB.DataBindings.Add("Text", VenueBS, "Name");
                VenueIDTB.DataBindings.Add("Text", VenueBS, "Id");
                AddressTB.DataBindings.Add("Text", VenueBS, "Address");
                ZipTB.DataBindings.Add("Text", VenueBS, "Zip");
                CityTB.DataBindings.Add("Text", VenueBS, "City");
                CountryTB.DataBindings.Add("Text", VenueBS, "Country");
                VenueDescriptionTB.DataBindings.Add("Text", VenueBS, "Description");

                VisibilityCombo.DataSource = VenueVisibilityItem.GetPossibleVisibilities();
                VisibilityCombo.DisplayMember = "Title";
                VisibilityCombo.ValueMember = "Visibility";
                VisibilityCombo.DataBindings.Add("SelectedValue", VenueBS, "Visibility");
                               


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
                    POIInfosBS.ResetBindings(false);

                }; // Current Changed

                POIsLB.DataSource = POIsBS;
                POIsLB.DisplayMember = "TextInList";
                POIsLB.ValueMember = "Name";


                POIInfosBS.DataSource = new WFPOIInformation[] { };
                

                POIInfosLB.DataSource = POIInfosBS;
                POIInfosLB.DisplayMember = "Information";
                POIInfosLB.ValueMember = "Information";
                POIInformationTB.DataBindings.Add("Text", POIInfosBS, "Information");
                POIInfoStartsTB.DataBindings.Add("Text", POIInfosBS, "StartsAt", true);
                POIInfoEndsTB.DataBindings.Add("Text", POIInfosBS, "EndsAt", true);
                MediaFileTB.DataBindings.Add("Text", POIInfosBS, "MediaFile");
                MediaDescrTB.DataBindings.Add("Text", POIInfosBS, "MediaDescription");
                AutoPlayMediaCB.DataBindings.Add("Checked", POIInfosBS, "AutoPlayMedia");

                POIInfoCatCombo.DataSource = InfoCategoryItem.GetAll();
                POIInfoCatCombo.DisplayMember = "Name";
                POIInfoCatCombo.ValueMember = "Category";
                POIInfoCatCombo.DataBindings.Add("SelectedValue", POIInfosBS, "Category");

                ElevatorsBS.DataSource = new WFNode[] { };
                ElevatorsLB.DataSource = ElevatorsBS;
                ElevatorsLB.DisplayMember = "TextInList";
                ElevatorsLB.ValueMember = "Id";


                EdgesPOIsBS.DataSource = new WFPointOfInterest[] { };
                EdgesPOIsBS.CurrentChanged += (s3, e3) =>
                {
                    WFPointOfInterest p = EdgesPOIsBS.Current as WFPointOfInterest;
                    if (p != null)
                    {
                        WFNode node = Venue.NodesGraph.FindNode(
                            p.BeaconUuid,
                            p.BeaconMajor,
                            p.BeaconMinor
                            );
                        if (node != null)
                        {
                            var nodeedges = Venue.NodesGraph.GetEdgesFor(node);

                            EdgesForPOIBS.DataSource = EdgeForPOI.EdgesFor(nodeedges);
                                

                        } // Node not null
                        else
                        {
                            EdgesForPOIBS.DataSource = new EdgeForPOI[] { };

                        }
                        

                    }
                    else
                    {
                        EdgesForPOIBS.DataSource = new EdgeForPOI[] { };

                    }
                    EdgesForPOIBS.ResetBindings(false);

                }; // Current Changed

                EdgesPOIsLB.DataSource = EdgesPOIsBS;
                EdgesPOIsLB.DisplayMember = "TextInList";
                EdgesPOIsLB.ValueMember = "Name";

                EdgesForPOIBS.DataSource = new EdgeForPOI[] { };
                EdgesForPOIBS.CurrentChanged += (s4, e4) =>
                {
                    EdgeForPOI efp = EdgesForPOIBS.Current as EdgeForPOI;
                    
                    if (efp != null)
                    {
                        WFEdge<WFNode> edge = efp.Edge;
                        EdgeBS.DataSource = edge;

                    }
                    else
                    {
                        EdgeBS.DataSource = new WFEdge<WFNode>(new WFNode(), new WFNode(), "");

                    } // Is null
                    EdgeBS.ResetBindings(true);

                };


                EdgesForPOILB.DataSource = EdgesForPOIBS;
                EdgesForPOILB.DisplayMember = "TextInList";
                EdgesForPOILB.ValueMember = "Edge";

                EdgeBS.DataSource = new WFEdge<WFNode>(new WFNode(), new WFNode(), "");
                EdgeBeginningTB.DataBindings.Add("Text", EdgeBS, "Beginning");
                EdgeStartHeadingTB.DataBindings.Add("Text", EdgeBS, "StartHeading");
                EdgeEndHeadingTB.DataBindings.Add("Text", EdgeBS, "EndHeading");
                EdgeTravelTimeTB.DataBindings.Add("Text", EdgeBS, "TravelTime");

                EdgeTravelTypeCombo.DataBindings.Add("Text", EdgeBS, "TravelType");


                NodesBS.DataSource = new WFNode[] { };
                NodesLB.DataSource = NodesBS;
                NodesLB.DisplayMember = "TextInList";
                NodesLB.ValueMember = "Id";
                
                NodeNameTB.DataBindings.Add("Text", NodesBS, "Name");
                NodeWaypointTypeCombo.DataBindings.Add("Text", NodesBS, "WaypointType");
                NodeFloorTB.DataBindings.Add("Text", NodesBS, "Floor");
                NodeUuidTB.DataBindings.Add("Text", NodesBS, "Uuid");
                NodeMajorTB.DataBindings.Add("Text", NodesBS, "Major");
                NodeMinorTB.DataBindings.Add("Text", NodesBS, "Minor");
                NodeIdTagTB.DataBindings.Add("Text", NodesBS, "IdTag");
                NodeActiveChk.DataBindings.Add("Checked", NodesBS, "Active", true);
                NodeAccuracyTB.DataBindings.Add("Text", NodesBS, "Accuracy");
                NodeMagneticOffsetTB.DataBindings.Add("Text", NodesBS, "MagneticOffset");
                NodeInfo1HeadingTB.DataBindings.Add("Text", NodesBS, "Heading1Info");
                NodeInfo2HeadingTB.DataBindings.Add("Text", NodesBS, "Heading2Info");
                NodeInfo3HeadingTB.DataBindings.Add("Text", NodesBS, "Heading3Info");
                NodeInfo4HeadingTB.DataBindings.Add("Text", NodesBS, "Heading4Info");
                NodeInfo5HeadingTB.DataBindings.Add("Text", NodesBS, "Heading5Info");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void RefreshUIForVenue(WFVenue v)
        {
            try
            {
                if (v != null)
                {
                    if (v.PointsOfInterest != null)
                    {
                        POIsBS.DataSource = v.PointsOfInterest.ToArray().OrderBy(w => w, new FloorComparer());

                        EdgesPOIsBS.DataSource = v.PointsOfInterest.ToArray().OrderBy(w => w, new FloorComparer());

                    }
                    else
                    {
                        POIsBS.DataSource = v.PointsOfInterest;
                        EdgesPOIsBS.DataSource = v.PointsOfInterest;

                    }

                }
                else
                {
                    POIsBS.DataSource = new WFPointOfInterest[] { };
                    EdgesPOIsBS.DataSource = new WFPointOfInterest[] { };

                }


                elevators = Venue.NodesGraph.GetNodesAlphabetical().Where(w => w.WaypointType == "elevator").OrderBy(w => w, new FloorComparer()).ToArray();
                ElevatorsBS.DataSource = elevators;
                ElevatorsBS.ResetBindings(false);

                NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical().OrderBy(w => w, new FloorComparer()).ToArray();
                NodesBS.ResetBindings(false);
            }
            catch (Exception ex)
            {
                throw;

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

                Venue.NodesGraph = new WFGraph();

                VenueBS.DataSource = Venue;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void openVenueFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (OpenVenueDialog.ShowDialog() != DialogResult.OK)
            {
                return;

            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                DoOpenVenue(OpenVenueDialog.FileName);

                SystemSounds.Asterisk.Play();

            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }

        }

        private void DoOpenVenue(string fileName)
        {
            try
            {
                OpenVenueDialog.FileName = fileName;
                SaveVenueDialog.FileName = fileName;

                Venue = WFVenue.LoadFromFile(fileName);
                string graphfile = Path.ChangeExtension(
                    fileName,
                    OpenGraphMLDialog.DefaultExt
                    );                
                if (File.Exists(graphfile))
                {
                    OpenGraphMLDialog.FileName = graphfile;

                    WFGraph g = WFGraph.LoadFromGraphML(graphfile);
                    Venue.NodesGraph = g;
                    Venue.AddPOIsFromGraph(true);

                }
                                
                VenueBS.DataSource = Venue;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void SaveMenuItems_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender == saveVenueFileAsToolStripMenuItem ||
                    string.IsNullOrEmpty(SaveVenueDialog.FileName))
                {
                    if (SaveVenueDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;

                    } // DialogResult = Ok

                    OpenGraphMLDialog.FileName = Path.ChangeExtension(
                        SaveVenueDialog.FileName,
                        OpenGraphMLDialog.DefaultExt
                        );

                } // Save as or not saved

                
                Venue.SaveToFile(SaveVenueDialog.FileName);


                // Set properties based on venue properties.
                Venue.NodesGraph.VenueId = Venue.Id;
                Venue.NodesGraph.VenueName = Venue.Name;
                Venue.NodesGraph.GraphId = string.Format("{0}-01",
                    Venue.Id
                    );
                var gkuuid = Venue.NodesGraph.GraphMLKeys.Where(w =>
                    w.ForType == "node" &&
                    w.Name == "uuid"
                    ).FirstOrDefault();
                if (gkuuid != null)
                {
                    gkuuid.DefaultValue = "bc8c0035-823e-4948-8695-1e11a1954211";
                    
                } // Found
                var gkmajor = Venue.NodesGraph.GraphMLKeys.Where(w =>
                    w.ForType == "node" &&
                    w.Name == "major"
                    ).FirstOrDefault();
                if (gkmajor != null)
                {
                    gkmajor.DefaultValue = Venue.Id;

                } // Found

                Venue.NodesGraph.Save(OpenGraphMLDialog.FileName);
                
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

                string[] cmdline = Environment.GetCommandLineArgs();
                if (cmdline.Length >= 2)
                {
                    string vnu = cmdline[1];
                    if (File.Exists(vnu))
                    {
                        DoOpenVenue(vnu);

                    } // Open it

                } // Perhaps?



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

                POIInfosBS.DataSource = p.Information;
                POIInfosBS.MoveLast();
                POIInfosBS.ResetBindings(false);
                
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

                string msg = "Vill du ta bort den markerade informationen?";
                DialogResult mr = MessageBox.Show(msg, "Ta bort", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (DialogResult.Yes != mr)
                {
                    return;

                } // Anything but Yes
                
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

        private void pushToCloudMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMenuItems_Click(sender, new EventArgs());

                if (string.IsNullOrEmpty(SaveVenueDialog.FileName))
                {
                    MessageBox.Show("Det gick inte att ladda upp filen eftersom den inte sparats.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                } // Has a file name


                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();


                try
                {
                    string[] currentfiles = FtpController.Me.DownloadFileList();

                }
                catch (Exception dlex)
                {
                    Console.WriteLine(dlex.Message);

                }
                

                string localfile = OpenVenueDialog.FileName;
                FtpController.Me.AddToUploadQueue(localfile);

                localfile = Path.ChangeExtension(localfile, ".graphml");
                if (File.Exists(localfile))
                {
                    FtpController.Me.AddToUploadQueue(localfile);

                } // graphl exists


                string fldr = Path.GetDirectoryName(localfile);

                if (Venue.PointsOfInterest != null)
                {
                    foreach (WFPointOfInterest poi in Venue.PointsOfInterest)
                    {
                        if (poi.Information != null)
                        {
                            foreach (WFPOIInformation poii in poi.Information)
                            {
                                if (!string.IsNullOrWhiteSpace(poii.MediaFile))
                                {
                                    FtpController.Me.AddToUploadQueue(
                                        Path.Combine(fldr, poii.MediaFile)
                                        );

                                } // Has media file

                            } // foreach poii

                        } // Has infos

                    } // foreach Pois

                } // Has pois



                FtpController.Me.UploadFiles();
                

                SystemSounds.Asterisk.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }

        }

        private void PickMediaFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                WFPOIInformation poii = POIInfosBS.Current as WFPOIInformation;
                if (poii == null)
                {
                    MessageBox.Show("Det måste finnas en Point Of Interest Information som mediafilen ska knytas till.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                } // No poii selected

                if (OpenMediaFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;

                } // No file selected

                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                
                string mediafile = Path.GetDirectoryName(SaveVenueDialog.FileName);

                string newfn = Path.GetFileName(OpenMediaFileDialog.FileName);
                if (!newfn.StartsWith(this.Venue.Id))
                {
                    newfn = string.Format("{0}_{1}",
                        Venue.Id,
                        newfn
                        );
                }

                mediafile = Path.Combine(mediafile, newfn);

                if (File.Exists(mediafile) &&
                    mediafile != OpenMediaFileDialog.FileName)
                {
                    DialogResult dr = MessageBox.Show(
                        string.Format("Det finns redan en fil som heter \"{0}\". Vill du ersätta den befintliga?",
                        Path.GetFileName(mediafile)),
                        "Ersätt befintlig fil",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                        );
                    if (dr != DialogResult.Yes)
                    {
                        return;

                    } // Don't replace

                    File.Delete(mediafile);

                } // Replace old file

                File.Copy(
                    OpenMediaFileDialog.FileName,
                    mediafile
                    );


                poii.MediaFile = newfn;
                MediaFileTB.Text = poii.MediaFile;


                SystemSounds.Asterisk.Play();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }

        }

        private void CreateElevatorEdgesButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ElevatorStartHeadingTB.Text) ||
                    !ElevatorStartHeadingTB.Text.IsNumeric())
                {
                    throw new Exception("Du måste ange en kompassriktning mellan 0 och 359 för startriktningen.");
                }
                if (string.IsNullOrWhiteSpace(ElevatorEndHeadingTB.Text) ||
                    !ElevatorEndHeadingTB.Text.IsNumeric())
                {
                    throw new Exception("Du måste ange en kompassriktning mellan 0 och 359 för slutriktningen.");
                }

                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                int startheading = Convert.ToInt32(ElevatorStartHeadingTB.Text);
                int endheading = Convert.ToInt32(ElevatorEndHeadingTB.Text);
                

                int idxsrc = 0;
                
                foreach (WFNode sourceelevator in elevators)
                {
                    idxsrc++;
                    int idxdst = 0;

                    foreach (WFNode targetelevator in elevators)
                    {
                        idxdst++;

                        if (sourceelevator == targetelevator)
                        {
                            continue;

                        } // The same elevator
                                                
                        WFEdge<WFNode> edg = Venue.NodesGraph.NewEdge(sourceelevator, targetelevator);
                        edg.StartHeading = startheading;
                        edg.EndHeading = endheading;
                        edg.TravelTime = Math.Abs(idxdst - idxsrc) * ElevatorTravelTime;
                        edg.TravelType = "elevator";
                        edg.Beginning = string.Format(ElevatorMessageTB.Text,
                            targetelevator.Floor
                            );
                        
                        Venue.NodesGraph.AddEdge(edg);
                        
                    } // foreach target
                    
                } // foreach source elevator

                
                SystemSounds.Asterisk.Play();


                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        private void AddEdgeButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                NewEdgeItem nei = new NewEdgeItem();

                WFPointOfInterest psrc = EdgesPOIsBS.Current as WFPointOfInterest;
                if (psrc != null)
                {
                    nei.Source = Venue.NodesGraph.FindNode(
                        psrc.BeaconUuid,
                        psrc.BeaconMajor,
                        psrc.BeaconMinor
                        );
                    nei.Target = nei.Source;

                } // Not null
                                
                nei.TravelTime = 15;

                NewEdgeDialog dlg = new NewEdgeDialog();
                dlg.Item = nei;
                dlg.AvailibleNodes = Venue.NodesGraph.GetNodesAlphabetical().OrderBy(w => w, new FloorComparer()).ToArray();


                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;

                } // User canceled

                
                WFEdge<WFNode> edge = Venue.NodesGraph.NewEdge(
                    nei.Source,
                    nei.Target
                    );
                edge.TravelTime = nei.TravelTime;
                edge.StartHeading = nei.StartHeading;
                edge.EndHeading = nei.EndHeading;
                edge.Beginning = nei.Beginning;

                Venue.NodesGraph.AddEdge(edge);
                                
                WFEdge<WFNode> returnedge = Venue.NodesGraph.NewEdge(
                    nei.Target,
                    nei.Source
                    );
                returnedge.TravelTime = nei.TravelTime;
                returnedge.StartHeading = HeadingHelper.ValidHeading(nei.EndHeading - 180);
                returnedge.EndHeading = HeadingHelper.ValidHeading(nei.StartHeading - 180);
                returnedge.Beginning = nei.Beginning;

                Venue.NodesGraph.AddEdge(returnedge);

                EdgesPOIsBS.ResetBindings(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }

        }

        private void DeleteEdgeButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                EdgeForPOI efp = EdgesForPOIBS.Current as EdgeForPOI;
                if (efp == null)
                {
                    return;

                } // Is null

                string msg = "Vill du verkligen ta bort den valda vägbeskrivningen?";
                DialogResult mr = MessageBox.Show(msg, "Ta bort vägbeskrivning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (DialogResult.Yes != mr)
                {
                    return;

                } // Anything but Yes

                Venue.NodesGraph.RemoveEdge(efp.Edge);
                EdgesPOIsBS.ResetBindings(false);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        private void testRoutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RouteTestForm dlg = new RouteTestForm();
                dlg.Venue = this.Venue;

                dlg.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void DeleteAllElevatorEdgesButton_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Vill du ta bort alla vägbeskrivningar mellan hissarna?";
                DialogResult mr = MessageBox.Show(msg, "Ta bort", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (DialogResult.Yes != mr)
                {
                    return;

                } // Anything but Yes

                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                WFEdge<WFNode>[] elevedges = Venue.NodesGraph.Edges.ToArray();

                for (int idx = elevedges.Count() - 1; idx >= 0; idx--)
                {
                    WFEdge<WFNode> edge = elevedges[idx];
                    if (edge.Source.WaypointType == "elevator" &&
                        edge.Target.WaypointType == "elevator")
                    {
                        Venue.NodesGraph.RemoveEdge(edge);
                        
                        
                    } // Is elevator edge

                } // for

                SystemSounds.Asterisk.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            try
            {

                WFNode n = Venue.NodesGraph.NewNode();
                n.Name = "Ny nod";
                Venue.NodesGraph.AddVertex(n);
                NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical().OrderBy(w => w, new FloorComparer()).ToArray();
                NodesBS.ResetBindings(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void DeleteNodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                WFNode thenode = NodesBS.Current as WFNode;
                if (thenode == null)
                {
                    return;

                } // No node selected

                string MSG = string.Format("Är du säkerk på att du vill ta bort noden \"{0}\"?",
                    thenode.Name
                    );
                DialogResult mr = MessageBox.Show(MSG, "Ta bort nod", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (DialogResult.Yes != mr)
                {
                    return;

                } // Anything but Yes
                
                Venue.NodesGraph.RemoveVertex(thenode);
                NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical().OrderBy(w => w, new FloorComparer()).ToArray();
                NodesBS.ResetBindings(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImportBeaconsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenCSVFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;

                } // User cancelled

                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();


                ImportBeaconsFromCSV(OpenCSVFileDialog.FileName);

                NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical().OrderBy(w => w, new FloorComparer()).ToArray();
                NodesBS.ResetBindings(false);

                SystemSounds.Asterisk.Play();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }

        }


        private void ImportBeaconsFromCSV(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);

                if (lines.Length < 2)
                {
                    return;

                } // No data

                string[] colnames = lines[0].Split(',');

                for (long idx = 1; idx < lines.Length; idx++)
                {
                    string[] values = TSVHelper.SplitCSVLine(lines[idx]);

                    WFNode n = Venue.NodesGraph.NewNode();
                    n.IdTag = TSVHelper.StringByColumn(colnames, values, "uniqueId");
                    n.Uuid = TSVHelper.StringByColumn(colnames, values, "proximity");
                    n.Major = TSVHelper.IntByColumn(colnames, values, "major");
                    n.Minor = TSVHelper.IntByColumn(colnames, values, "minor");
                    n.Name = n.IdTag;

                    Venue.NodesGraph.AddVertex(n);
                    

                } // for all lines

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("ImportBeaconsFromCSV({1}): {0}",
                    ex.Message,
                    fileName
                    );
                throw new Exception(errmsg);
            }

        }

        private void Tabs_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {                
                // Refresh stuff?
                if (e.TabPage == NodesTab)
                {
                    Venue.AddPOIsFromGraph(true);
                    RefreshUIForVenue(Venue);


                } // Nodes
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void EditHeadingInfoButtonsClick(object sender, EventArgs e)
        {
            try
            {
                TextBox tb = null;
                
                if (sender == EditHeadingInfo1Btn)
                {
                    tb = NodeInfo1HeadingTB;
                }
                else if (sender == EditHeadingInfo2Btn)
                {
                    tb = NodeInfo2HeadingTB;
                }
                else if (sender == EditHeadingInfo3Btn)
                {
                    tb = NodeInfo3HeadingTB;
                }
                else if (sender == EditHeadingInfo4Btn)
                {
                    tb = NodeInfo4HeadingTB;
                }
                else if (sender == EditHeadingInfo5Btn)
                {
                    tb = NodeInfo5HeadingTB;
                }
                
                EditHeadingInfoDialog dlg = new EditHeadingInfoDialog();
                dlg.HeadingInfo = new WFHeadingInfo(tb.Text);
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;

                } // User canceled

                tb.Text = dlg.HeadingInfo.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
