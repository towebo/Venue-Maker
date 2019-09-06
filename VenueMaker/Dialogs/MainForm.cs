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
using WayfindR.Controllers;
using WayfindR.Models;
using VenueMaker.Helpers;
using VenueMaker.Models;
using WayfindR.Helpers;
using WayfindR;
using Mawingu;
using VenueMaker.Kwenda;
using Kwenda.Models;
using Kwenda;

namespace VenueMaker.Dialogs
{
    public partial class MainForm : Form
    {
        private static MainForm me;
        private bool _modified;

        private bool loadguard;
        private WFNode[] elevators;
        private const double ElevatorTravelTime = 20.0;



        public WFVenue Venue { get; set; }


        public static MainForm Me { get { return me; } }

        public MainForm()
        {
            me = this;
            InitializeComponent();
        }

        private void MakeUIReflectUserLevel()
        {
            bool hasadminrights = Controllers.DataController.Me.Email == "admin@mawingu.se";
            MakeVenueActiveChk.Visible = hasadminrights;
            VenueIDTB.ReadOnly = !hasadminrights;
            if (VenueIDTB.ReadOnly)
            {
                VenueIDTB.ForeColor = SystemColors.GrayText;

            } // Dim out

            saveVenueAsToolStripMenuItem.Visible = hasadminrights;
            createAccountToolStripMenuItem.Visible = hasadminrights;
            setPermissionsToolStripMenuItem.Visible = hasadminrights;

        }

        private void InitMenusAndButtons()
        {
            try
            {
                // File
                newVenueToolStripMenuItem.Click += (s1, e1) => CreateNewVenue();
                openVenueToolStripMenuItem.Click += (s2, e2) => OpenVenue();
                saveVenueToolStripMenuItem.Click += (s3, e3) => SaveVenue(false);
                saveVenueAsToolStripMenuItem.Click += (s3, e3) => SaveVenue(true);
                
                selectDataFolderToolStripMenuItem.Click += (s9, e9) => SelectDataFolder();

                // Account
                loginToolStripMenuItem.Click += (s4, e4) => EnsureLogin(true);
                logOutToolStripMenuItem.Click += (s5, e5) => LogOut();
                createAccountToolStripMenuItem.Click += (s6, e6) => createAccount();
                verifyAccountToolStripMenuItem.Click += (s7, e7) => verifyAccount();
                setPermissionsToolStripMenuItem.Click += (s8, e8) => SetPermissions();
                


                // Venue
                VenueImagePB.Click += (s10, e10) => SelectVenueImage();
                
                AddMapBtn.Click += (s11, e11) => AddMap();
                DeleteMapBtn.Click += (s12, e12) => DeleteMap();
                
                // Nodes
                AddNodeButton.Click += (s16, e16) => AddNode();
                DeleteNodeButton.Click += (s17, e17) => DeleteNode();
                ImportBeaconsBtn.Click += (s18, e18) => ImportBeacons();
                NodeMapPointBtn.Click += (s32, e32) => PinNodeOnMap();
                

                // Directions
                AddEdgeButton.Click += (s20, e20) => AddEdge();
                DeleteEdgeButton.Click += (s21, e21) => DeleteEdge();
                MarkEdgeOnMapBtn.Click += (s34, e34) => PinEdgeOnMap();

                // Elevators
                CreateElevatorEdgesButton.Click += (s24, e24) => CreateElevatorEdges();
                DeleteAllElevatorEdgesButton.Click += (s25, e25) => DeleteAllElevatorEdges();

                // Points Of Interest
                AddPOIInfoButton.Click += (s27, e27) => AddPOIInfo();
                RemovePOIInfoButton.Click += (s28, e28) => DeletePOI_Info();
                MoveInfoUpButton.Click += (s29, e29) => MovePOIInfoUpOrDown(true);
                MoveInfoDownButton.Click += (s30, e30) => MovePOIInfoUpOrDown(false);
                PickMediaFileButton.Click += (s31, e31) => PickMediaFile();

            }
            catch (Exception ex)
            {
                string errmsg = $"Fel när verktygsfältet skulle initieras: {ex.Message}";
                throw new Exception(errmsg);
            }
        } // InitRibbon
        
        private void InitUI()
        {
            try
            {
                VenueMaker.Models.Preferences.Load();

                if (!Directory.Exists(VenueMaker.Models.Preferences.Me.DataFolder))
                {
                    Directory.CreateDirectory(VenueMaker.Models.Preferences.Me.DataFolder);

                } // Create folder for data files

                Text = AssemblyInfo.GetProductAndVersion();
                WindowState = FormWindowState.Maximized;
                Tabs.Dock = DockStyle.Fill;

                // Tabs.Alignment = TabAlignment.Bottom;
                // Tabs.TabStop = false;
                // Tabs.Appearance = TabAppearance.Buttons;
                // Tabs.ItemSize = new Size(0, 1);
                // Tabs.SizeMode = TabSizeMode.Fixed;
                // Tabs.Multiline = true;

                InitMenusAndButtons();

                VenueBS.DataSource = new WFVenue();
                VenueBS.CurrentChanged += (s1, e1) =>
                {
                    WFVenue v = VenueBS.Current as WFVenue;
                    RefreshUIForVenue(v);

                };

                MapsBS.DataSource = new WFMap[] { };
                MapsBS.CurrentChanged += (s2, e2) =>
                {
                    WFMap m = MapsBS.Current as WFMap;

                    if (MapPB.Image != null)
                    {
                        MapPB.Image.Dispose();
                        MapPB.Image = null;
                        Application.DoEvents();
                        
                    } // Has image

                    string img = Path.Combine(GetDataFilesFolder(), m.FileName);
                    if (!File.Exists(img))
                    {
                        return;

                    } // Doesn't exists

                    if (!loadguard)
                    {
                        MapPB.Image = Image.FromFile(img);

                    } // Not loading

                };

                MapsLB.DisplayMember = "Title";
                MapsLB.ValueMember = "Id";
                MapsLB.DataSource = MapsBS;


                VenueNameTB.DataBindings.Add("Text", VenueBS, "Name");
                VenueIDTB.DataBindings.Add("Text", VenueBS, "Id");
                AddressTB.DataBindings.Add("Text", VenueBS, "Address");
                ZipTB.DataBindings.Add("Text", VenueBS, "Zip");
                CityTB.DataBindings.Add("Text", VenueBS, "City");
                CountryTB.DataBindings.Add("Text", VenueBS, "Country");
                VenueGPSTB.DataBindings.Add("Text", VenueBS, nameof(WFVenue.GPSCoordinates), false);
                VenuePhoneTB.DataBindings.Add("Text", VenueBS, nameof(WFVenue.Phone), false);
                VenueWebTB.DataBindings.Add("Text", VenueBS, nameof(WFVenue.Web), false);
                VenueEmailTB.DataBindings.Add("Text", VenueBS, nameof(WFVenue.Email), false);
                VenueImageTB.DataBindings.Add("Text", VenueBS, nameof(WFVenue.Image), false);

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
                POIsLB.DisplayMember = nameof(WFPointOfInterest.TextInList);
                POIsLB.ValueMember = nameof(WFPointOfInterest.Guid);


                POIInfosBS.DataSource = new WFPOIInformation[] { };

                POIInfosLB.DataSource = POIInfosBS;
                POIInfosLB.DisplayMember = nameof(WFPOIInformation.Information);
                POIInfosLB.ValueMember = nameof(WFPOIInformation.Guid);
                
                POIInformationTB.DataBindings.Add("Text", POIInfosBS, nameof(WFPOIInformation.Information));
                POIInfoStartsTB.DataBindings.Add("Text", POIInfosBS, nameof(WFPOIInformation.StartsAt), true, DataSourceUpdateMode.OnValidation);
                POIInfoStartsTB.AllowEmptyValue();
                POIInfoEndsTB.DataBindings.Add("Text", POIInfosBS, nameof(WFPOIInformation.EndsAt), true, DataSourceUpdateMode.OnPropertyChanged);
                POIInfoEndsTB.AllowEmptyValue();
                MediaFileTB.DataBindings.Add("Text", POIInfosBS, nameof(WFPOIInformation.MediaFile));
                MediaDescrTB.DataBindings.Add("Text", POIInfosBS, nameof(WFPOIInformation.MediaDescription));
                AutoPlayMediaCB.DataBindings.Add("Checked", POIInfosBS, nameof(WFPOIInformation.AutoPlayMedia));
                POIILinkUrlTB.DataBindings.Add("Text", POIInfosBS, nameof(WFPOIInformation.LinkUrl));

                POIInfosBS.CurrentChanged += POIInfosBS_CurrentChanged1;


                POIInfoCatCombo.DataSource = InfoCategoryItem.GetAll();
                POIInfoCatCombo.DisplayMember = nameof(InfoCategoryItem.Name);
                POIInfoCatCombo.ValueMember = nameof(InfoCategoryItem.Category);
                POIInfoCatCombo.DataBindings.Add("SelectedValue", POIInfosBS, nameof(WFPOIInformation.Category));

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
                        WFNode node = p.LinkedNode;
#warning Delete this when it works.
                        /*tmp
                        WFNode node = Venue.NodesGraph.FindNode(
                            p.BeaconUuid,
                            p.BeaconMajor,
                            p.BeaconMinor
                            );
                        */
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
                EdgesPOIsLB.DisplayMember = nameof(WFPointOfInterest.TextInList);
                EdgesPOIsLB.ValueMember = nameof(WFPointOfInterest.Guid);

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


                EdgeTravelTypeCombo.DataSource = TravelTypeHelper.ToDictionary().Keys.ToList();

                EdgeTravelTypeCombo.DataBindings.Add("Text", EdgeBS, "TravelType");



                NodesFilterBS.DataSource = NodesFilterItem.GetAll();
                NodesFilterBS.CurrentChanged += (sF, eF) =>
                {
                    RefreshNodes();

                }; // Nodes Filter Changed
                NodesFilterCombo.DataSource = NodesFilterBS;
                NodesFilterCombo.DisplayMember = nameof(NodesFilterItem.Name);
                NodesFilterCombo.ValueMember = nameof(NodesFilterItem.Filter);

                NodesBS.DataSource = new WFNode[] { };
                NodesLB.DataSource = NodesBS;
                NodesLB.DisplayMember = "TextInList";
                NodesLB.ValueMember = "Id";

                NodeNameTB.DataBindings.Add("Text", NodesBS, "Name");
                NodeWaypointTypeCombo.DataSource = WaypointTypeHelper.ToDictionary().Keys.ToList();
                NodeWaypointTypeCombo.DataBindings.Add("Text", NodesBS, "WaypointType");
                NodeAreaTB.DataBindings.Add("Text", NodesBS, "Area");
                NodeBuildingTB.DataBindings.Add("Text", NodesBS, "Building");
                NodeFloorTB.DataBindings.Add("Text", NodesBS, "Floor");
                NodeDepartmentTB.DataBindings.Add("Text", NodesBS, "Department");
                NodeRoomTB.DataBindings.Add("Text", NodesBS, "Room");
                NodeSpaceTB.DataBindings.Add("Text", NodesBS, "Space");
                NodeUuidTB.DataBindings.Add("Text", NodesBS, "Uuid");
                NodeMajorTB.DataBindings.Add("Text", NodesBS, "Major");
                NodeMinorTB.DataBindings.Add("Text", NodesBS, "Minor");
                NodeIdTagTB.DataBindings.Add("Text", NodesBS, "IdTag");
                NodeActiveChk.DataBindings.Add("Checked", NodesBS, "Active", true, DataSourceUpdateMode.OnValidation);
                NodeAccuracyTB.DataBindings.Add("Text", NodesBS, "Accuracy");
                NodeMagneticOffsetTB.DataBindings.Add("Text", NodesBS, "MagneticOffset");
                NodeInfo1HeadingTB.DataBindings.Add("Text", NodesBS, "Heading1Info");
                NodeInfo2HeadingTB.DataBindings.Add("Text", NodesBS, "Heading2Info");
                NodeInfo3HeadingTB.DataBindings.Add("Text", NodesBS, "Heading3Info");
                NodeInfo4HeadingTB.DataBindings.Add("Text", NodesBS, "Heading4Info");
                NodeInfo5HeadingTB.DataBindings.Add("Text", NodesBS, "Heading5Info");

                NodeGPSTB.DataBindings.Add("Text", NodesBS, nameof(WFNode.GPSCoordinates), false, DataSourceUpdateMode.OnPropertyChanged);

                NodesBS.CurrentChanged += NodesBS_CurrentChanged;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void NodesBS_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                WFNode n = NodesBS.Current as WFNode;
                if (n == null)
                {
                    return;

                } // Is null

                WFMap m = Venue.Maps.Where(w => w.Id == n.MapPoint.MapId).FirstOrDefault();
                if (m == null)
                {
                    NodeMapPointTB.Text = "";
                    return;

                } // No map

                NodeMapPointTB.Text = $"{m.Title} / x: {n.MapPoint.X}, y: {n.MapPoint.Y}";

            }
            catch
            {
                NodeMapPointTB.Text = "";

            }
        }

        private void POIInfosBS_CurrentChanged1(object sender, EventArgs e)
        {
            try
            {
                WFPOIInformation poii = POIInfosBS.Current as WFPOIInformation;
                if (poii == null)
                {
                    PoiInfoPB.Image = null;
                    return;

                } // Is null

                if (string.IsNullOrWhiteSpace(poii.MediaFile))
                {
                    PoiInfoPB.Image = null;
                    return;

                } // No file

                string img = Path.Combine(GetDataFilesFolder(), poii.MediaFile);
                if (!File.Exists(img))
                {
                    PoiInfoPB.Image = null;
                    return;

                } // Doesn't exists

                PoiInfoPB.Image = Image.FromFile(img);

            }
            catch
            {
            }

        }

        private void POIInfosBS_CurrentChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RefreshUIForVenue(WFVenue v)
        {
            try
            {
                if (v != null)
                {

                    if (VenueImagePB.Image != null)
                    {
                        VenueImagePB.Image.Dispose();
                        VenueImagePB.Image = null;
                        Application.DoEvents();

                    } // Clear image

                    if (!string.IsNullOrWhiteSpace(v.Image))
                    {
                        string img = Path.Combine(GetDataFilesFolder(), v.Image);
                        if (!string.IsNullOrWhiteSpace(v.Image) &&
                            File.Exists(img))
                        {
                            if (!loadguard)
                            {
                                VenueImagePB.Image = Image.FromFile(img);

                            } // Not loading

                        } // Image exists
                    }


                    if (v.PointsOfInterest != null)
                    {
                        POIsBS.DataSource = v.PointsOfInterest.OrderBy(w => w, new FloorComparer()).ToArray();
                        POIsBS.ResetBindings(false);

                        EdgesPOIsBS.DataSource = v.PointsOfInterest.ToArray().OrderBy(w => w, new FloorComparer()).ToArray();

                    }
                    else
                    {
                        POIsBS.DataSource = v.PointsOfInterest;
                        EdgesPOIsBS.DataSource = v.PointsOfInterest;

                    } // Pois is null
                    
                    if (MapPB.Image != null)
                    {
                        MapPB.Image.Dispose();
                        MapPB.Image = null;
                        Application.DoEvents();

                    } // Release image

                    if (v.Maps != null)
                    {
                        MapsBS.DataSource = v.Maps;
                        MapsBS.ResetBindings(false);

                    }
                    else
                    {
                        MapsBS.DataSource = new WFMap[] { };
                        MapsBS.ResetBindings(false);

                    } // Maps is null

                    RefreshNodes();

#warning Perhaps we should have a setting instead of just passing "true".
                    elevators = v.NodesGraph.GetNodesAlphabetical(false).Where(w =>
                        w.WaypointType == WFWaypointType.Elevator.ToString().ToLower()
                        ).OrderBy(w => w, new FloorComparer()).ToArray();
                    ElevatorsBS.DataSource = elevators;
                    ElevatorsBS.ResetBindings(false);


                } // v not null
                else
                {
                    POIsBS.DataSource = new WFPointOfInterest[] { };
                    EdgesPOIsBS.DataSource = new WFPointOfInterest[] { };
                    NodesBS.DataSource = new WFNode[] { };
                    ElevatorsBS.DataSource = new WFNode[] { };



                }

            }
            catch (Exception ex)
            {
                LogCenter.Error("RefreshUIForVenue", ex.Message);
                throw new Exception($"Fel uppstod i RefreshUIForVenue: {ex.Message}");

            }
        }

        private void closeAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void RefreshNodes()
        {
            try
            {
                if (Venue == null ||
                    Venue.NodesGraph == null)
                {
                    return;

                } // No venue or graph


                NodesFilterItem fi = NodesFilterBS.Current as NodesFilterItem;
                if (fi != null)
                {
                    switch (fi.Filter)
                    {
                        case NodesFilter.All:
                            NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical(false).OrderBy(w => w, new FloorComparer()).ToArray();
                            break;

                        case NodesFilter.Active:
                            NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical(true).OrderBy(w => w, new FloorComparer()).ToArray();
                            break;


                        case NodesFilter.Inactive:
                            NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical(false).Where(w => w.Active.ToLower() != "true").OrderBy(w => w, new FloorComparer()).ToArray();
                            break;

                        default:
                            NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical(false).OrderBy(w => w, new FloorComparer()).ToArray();
                            break;

                    } // switch
                }
                else
                {
                    NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical(false).OrderBy(w => w, new FloorComparer()).ToArray();

                } // Nodes Filter

                NodesBS.ResetBindings(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CreateNewVenue()
        {
            try
            {
                Venue = new WFVenue();
                SaveVenueDialog.FileName = "";

                Venue.NodesGraph = new WFGraph();

                VenueBS.DataSource = Venue;
                RefreshUIForVenue(Venue);

                _modified = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void OpenVenue()
        {
            try
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();


                if (!EnsureLogin())
                {
                    return;

                } // Not logged in

                Application.UseWaitCursor = true;
                Application.DoEvents();

                bool didload = LoadVenueFromCloud();

                if (didload)
                {
                    SystemSounds.Asterisk.Play();
                    return;

                } // Loaded from cloud


                if (!MakeVenueActiveChk.Visible)
                {
                    return;

                } // Not an admin

                if (OpenVenueDialog.ShowDialog() != DialogResult.OK)
                {
                    return;

                }


                Application.UseWaitCursor = true;
                Application.DoEvents();

                VenueBS.SuspendBinding();

                DoOpenVenue(OpenVenueDialog.FileName, "");

                SystemSounds.Asterisk.Play();

            }
            finally
            {
                VenueBS.ResumeBinding();

                Application.UseWaitCursor = false;

            }

        }

        private void DoOpenVenue(string fileName, string data)
        {
            try
            {
                OpenVenueDialog.FileName = fileName;
                SaveVenueDialog.FileName = fileName;

                if (string.IsNullOrEmpty(data))
                {
                    Venue = WFVenue.LoadFromFile(fileName);

                    string graphfile = Path.ChangeExtension(
                    fileName,
                    OpenGraphMLDialog.DefaultExt
                    );
                    OpenGraphMLDialog.FileName = graphfile;
                    if (File.Exists(graphfile))
                    {
                        WFGraph g = WFGraph.LoadFromGraphML(graphfile);
                        Venue.GraphML = g.ToString();

                    }

                }
                else
                {
                    Venue = WFVenue.FromJson(data);

                } // From cloud


                VenueBS.DataSource = Venue;

                _modified = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void SaveVenue(bool asFile)
        {
            try
            {
                if (asFile||
                    string.IsNullOrEmpty(SaveVenueDialog.FileName))
                {
                    if (!MakeVenueActiveChk.Visible)
                    {
                        MessageBox.Show("Du kan bara spara ändringar om du öppnat en fil.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    } // Not an admin

                    if (SaveVenueDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;

                    } // DialogResult = Ok

                    OpenGraphMLDialog.FileName = Path.ChangeExtension(
                        SaveVenueDialog.FileName,
                        OpenGraphMLDialog.DefaultExt
                        );

                } // Save as or not saved


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


                if (asFile)
                {

                    Venue.NodesGraph.Save(OpenGraphMLDialog.FileName);

                    Venue.SaveToFile(SaveVenueDialog.FileName);

                }
                else
                {
                    PushToCloud();

                } // Just save

                _modified = false;

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
                        try
                        {
                            VenueBS.SuspendBinding();

                            DoOpenVenue(vnu, "");

                        }
                        finally
                        {
                            VenueBS.ResumeBinding();

                        }

                    } // Open it

                } // Perhaps?

                InitWebService();

                OpenVenue();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        async private void InitWebService()
        {
            try
            {
                string svcver = string.Empty;

                await Task.Run(() =>
                {
                    // Initialize the web service for better performance.
                    svcver = Controllers.DataController.Me.ServiceVersion();

                }); // Task

                Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        ServiceVersionLabel.BackColor = SystemColors.Control;
                        ServiceVersionLabel.ForeColor = SystemColors.ControlText;

                    }
                    catch (Exception verex)
                    {
                        svcver = $"Fel - {verex.Message}";
                        ServiceVersionLabel.BackColor = Color.Red;
                        ServiceVersionLabel.ForeColor = Color.White;
                    }
                    ServiceVersionLabel.Text = $"Serviceversion: {svcver}";

                });
            }
            catch
            {
            }
        }

        private void AddPOIInfo()
        {
            try
            {
                WFPointOfInterest p = POIsBS.Current as WFPointOfInterest;
                if (p == null)
                {
                    return;

                }

                WFPOIInformation newinfo = new WFPOIInformation();
                newinfo.Information = "Skriv text här";

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

                try
                {
                    POIInformationTB.Focus();

                }
                catch
                {
                }

                _modified = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DeletePOI_Info()
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

                _modified = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void MovePOIInfoUpOrDown(bool moveUp)
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

                if (moveUp)
                {
                    swapidx = selidx - 1;

                }
                else
                {
                    swapidx = selidx + 1;

                }


                if (swapidx < 0 ||
                    swapidx >= items.Length)
                {
                    return;

                }

                WFPOIInformation swapone = items[swapidx];
                items[swapidx] = selone;
                items[selidx] = swapone;

                POIInfosBS.ResetBindings(false);
                if (moveUp)
                {
                    POIInfosBS.MovePrevious();

                }
                else
                {
                    POIInfosBS.MoveNext();

                }

                _modified = true;

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
                SaveVenue(false);

                if (string.IsNullOrEmpty(SaveVenueDialog.FileName))
                {
                    MessageBox.Show("Det gick inte att ladda upp filen eftersom den inte sparats.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                } // Has a file name


                Application.UseWaitCursor = true;
                Application.DoEvents();

                PushToCloud();

                SystemSounds.Asterisk.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Application.UseWaitCursor = false;

            }

        }

        private void PickMediaFile()
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

                Application.UseWaitCursor = true;
                Application.DoEvents();

                string mediafile = UseThisFile(OpenMediaFileDialog.FileName);

                poii.MediaFile = mediafile;
                MediaFileTB.Text = poii.MediaFile;

                _modified = true;

                SystemSounds.Asterisk.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Application.UseWaitCursor = false;

            }

        }

        private void CreateElevatorEdges()
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

                Application.UseWaitCursor = true;
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
                        edg.TravelType = WFTravelType.Elevator.ToString().ToLower();
                        edg.Beginning = string.Format(ElevatorMessageTB.Text,
                            targetelevator.Floor
                            );

                        Venue.NodesGraph.AddEdge(edg);

                    } // foreach target

                } // foreach source elevator


                _modified = true;

                SystemSounds.Asterisk.Play();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Application.UseWaitCursor = false;

            }
        }

        private void AddEdge()
        {
            try
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();

                NewEdgeItem nei = new NewEdgeItem();

                WFPointOfInterest psrc = EdgesPOIsBS.Current as WFPointOfInterest;
                if (psrc != null)
                {
                    nei.Source = psrc.LinkedNode;
                    nei.Target = nei.Source;

                } // Not null

                nei.TravelTime = 15;

                NewEdgeDialog dlg = new NewEdgeDialog();
                dlg.Item = nei;
                dlg.AvailibleNodes = Venue.NodesGraph.GetNodesAlphabetical(false).OrderBy(w => w, new FloorComparer()).ToArray();


                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;

                } // User canceled


                WFEdge<WFNode> edge = Venue.NodesGraph.NewEdge(
                    nei.Source,
                    nei.Target
                    );
                edge.TravelTime = nei.TravelTime;
                edge.TravelType = nei.TravelType;
                edge.StartHeading = nei.StartHeading;
                edge.EndHeading = nei.EndHeading;
                edge.Beginning = nei.Beginning;

                Venue.NodesGraph.AddEdge(edge);

                WFEdge<WFNode> returnedge = Venue.NodesGraph.NewEdge(
                    nei.Target,
                    nei.Source
                    );
                returnedge.TravelTime = nei.TravelTime;
                returnedge.TravelType = nei.TravelType;
                returnedge.StartHeading = HeadingHelper.ValidHeading(nei.EndHeading - 180);
                returnedge.EndHeading = HeadingHelper.ValidHeading(nei.StartHeading - 180);
                returnedge.Beginning = nei.Beginning;

                Venue.NodesGraph.AddEdge(returnedge);

                EdgesPOIsBS.ResetBindings(false);

                _modified = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            finally
            {
                Application.UseWaitCursor = false;

            }

        }

        private void DeleteEdge()
        {
            try
            {
                Application.UseWaitCursor = true;
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

                _modified = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Application.UseWaitCursor = false;

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

        private void DeleteAllElevatorEdges()
        {
            try
            {
                string msg = "Vill du ta bort alla vägbeskrivningar mellan hissarna?";
                DialogResult mr = MessageBox.Show(msg, "Ta bort", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (DialogResult.Yes != mr)
                {
                    return;

                } // Anything but Yes

                Application.UseWaitCursor = true;
                Application.DoEvents();

                WFEdge<WFNode>[] elevedges = Venue.NodesGraph.Edges.ToArray();

                for (int idx = elevedges.Count() - 1; idx >= 0; idx--)
                {
                    WFEdge<WFNode> edge = elevedges[idx];
                    if (edge.Source.WaypointType == WFWaypointType.Elevator.ToString().ToLower() &&
                        edge.Target.WaypointType == WFWaypointType.Elevator.ToString().ToLower())
                    {
                        Venue.NodesGraph.RemoveEdge(edge);


                    } // Is elevator edge

                } // for

                _modified = true;

                SystemSounds.Asterisk.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Application.UseWaitCursor = false;

            }
        }

        private void AddNode()
        {
            try
            {

                WFNode n = Venue.NodesGraph.NewNode();
                n.Name = "Ny nod";
                Venue.NodesGraph.AddVertex(n);
                NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical(false).OrderBy(w => w, new FloorComparer()).ToArray();
                NodesBS.ResetBindings(false);

                _modified = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void DeleteNode()
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
                NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical(false).OrderBy(w => w, new FloorComparer()).ToArray();
                NodesBS.ResetBindings(false);

                _modified = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImportBeacons()
        {
            try
            {
                if (OpenCSVFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;

                } // User cancelled

                Application.UseWaitCursor = true;
                Application.DoEvents();


                ImportBeaconsFromCSV(OpenCSVFileDialog.FileName);

                NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical(false).OrderBy(w => w, new FloorComparer()).ToArray();
                NodesBS.ResetBindings(false);

                _modified = true;

                SystemSounds.Asterisk.Play();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Application.UseWaitCursor = false;

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

                using (EditHeadingInfoDialog dlg = new EditHeadingInfoDialog())
                {
                    dlg.HeadingInfo = new WFHeadingInfo(tb.Text);
                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        return;

                    } // User canceled

                    tb.Text = dlg.HeadingInfo.ToString();
                    _modified = true;

                } // using dlg

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public string UseThisFile(string src)
        {
            string mediafile = GetDataFilesFolder();

            if (!Directory.Exists(mediafile))
            {
                Directory.CreateDirectory(mediafile);

            } // Create folder if it doesn't exist

            string newfn = Path.GetFileName(src);
            if (!newfn.StartsWith(this.Venue.Id))
            {
                newfn = string.Format("{0}_{1}",
                    Venue.Id,
                    newfn
                    );

            } // Doesn't start with the Venue Id

            mediafile = Path.Combine(mediafile, newfn);

            if (File.Exists(mediafile) &&
                mediafile != src)
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
                    return mediafile;

                } // Don't replace

            File.Delete(mediafile);

            } // Replace old file

            if (mediafile != src)
            {
                File.Copy(
                    src,
                    mediafile
                    );

            } // Not the same file

            return Path.GetFileName(mediafile);


        }

        private void createAccount()
        {
            try
            {
                using (CreateAccountDialog dlg = new CreateAccountDialog())
                {
                    dlg.Item = new CreateAccountInfoModel();

                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        return;

                    } // User canceled

                    using (KwendaService cli = new KwendaService())
                    {
                        CreateAccountRequest req = new CreateAccountRequest();
                        req.Email = dlg.Item.Email;
                        req.Organization = dlg.Item.Organization;
                        req.Password = dlg.Item.Password;

                        CreateAccountResponse result = cli.CreateAccount(req);

                        switch (result.Result)
                        {
                            case CreateAccountResponseMethodResult.Ok:
                                MessageBox.Show("Kontot skapat!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;

                            case CreateAccountResponseMethodResult.UserAlreadyExists:
                                MessageBox.Show($"En användare med e-postadress {req.Email} finns redan.", "Användare finns redan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;

                            case CreateAccountResponseMethodResult.RequiredInfoMissing:
                                MessageBox.Show("Information som krävs saknas. Kontrollera så allt är ifyllt som det ska och prova igen.", "Information saknas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;

                            case CreateAccountResponseMethodResult.OtherError:
                                MessageBox.Show($"Ett fel inträffade när kontot skulle skapas: {result.Message}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;

                            default:
                                MessageBox.Show($"Ett fel som inte hanteras i programmet inträffade när kontot skulle skapas: {result.Result.ToString()}, {result.Message}");
                                break;

                        } // switch
                        
                    } // using KwendaService 

                } // using dialog

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void verifyAccount()
        {
        }

        private void LogOut()
        {
            try
            {
                if (_modified)
                {
                    DialogResult dr = MessageBox.Show("Vill du spara ändringarna som gjorts?", "Spara ändringar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (DialogResult.Cancel == dr)
                    {
                        return;

                    } // Chickened out
                    else if (DialogResult.Yes == dr)
                    {
                        SaveVenue(false);

                    }

                } // There are changes

                Application.UseWaitCursor = true;
                Application.DoEvents();

                Controllers.DataController.Me.LogOut();

                CreateNewVenue();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Application.UseWaitCursor = false;

            }

        }

        private bool EnsureLogin(bool forceDialog = false)
        {
            try
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();

                bool result = false;

                if (!forceDialog)
                {
                    result = Controllers.DataController.Me.IsTokenValid() ||
                        Controllers.DataController.Me.AutoLogin();

                } // Don't use the force Luke.

                if (!result)
                {
                    Application.UseWaitCursor = false;

                    using (LoginDialog dlg = new LoginDialog())
                    {
                        dlg.Item = new LoginInfoModel();
                        dlg.Item.Email = Controllers.DataController.Me.Email;

                        result = dlg.ShowDialog() == DialogResult.OK;

                    } // using LoginDialog

                } // Not logged in correctly

                return result;

            }
            catch (Exception ex)
            {
                LogCenter.Error("EnsureLogin", ex.Message);
                return false;

            }
            finally
            {
                MakeUIReflectUserLevel();
                Application.UseWaitCursor = false;

            }

        }

        private void SetPermissions()
        {
            try
            {
                if (!EnsureLogin())
                {
                    MessageBox.Show("Du mådate vara inloggad för att utföra denna funktion.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                } // Not logged in

                using (SetPermissionsDialog dlg = new SetPermissionsDialog())
                {
                    dlg.VenueId = Venue.Id;

                    dlg.ShowDialog();

                } // using

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void PushToCloud()
        {
            try
            {
                string venuefile = SaveVenueDialog.FileName;
                if (string.IsNullOrWhiteSpace(venuefile))
                {
                    string safename = Venue.Name.Replace(" ", "_");

                    venuefile = string.Format("{0}_{1}.{2}",
                        Venue.Id,
                        safename,
                        SaveVenueDialog.DefaultExt
                        );

                } // No file name

                List<KwendaFileItem> kfiles = new List<KwendaFileItem>();
                KwendaFileItem kvenue = new KwendaFileItem();
                kvenue.VenueId = Venue.Id;
                kvenue.FileName = Path.GetFileName(venuefile);
                kvenue.FileExt = Path.GetExtension(kvenue.FileName);
                kvenue.Data = Encoding.UTF8.GetBytes(Venue.ToString());
                kvenue.FileTitle = Venue.GetFileTitle();
                kvenue.Active = MakeVenueActiveChk.Checked;
                
                kfiles.Add(kvenue);

                // Add the media files
                string fldr = GetDataFilesFolder();

                if (!string.IsNullOrWhiteSpace(Venue.Image))
                {
                    KwendaFileItem kmediafile = new KwendaFileItem();
                    kmediafile.VenueId = Venue.Id;
                    kmediafile.FileName = Venue.Image;
                    kmediafile.FileExt = Path.GetExtension(kmediafile.FileName);
                    kmediafile.Data = File.ReadAllBytes(
                        Path.Combine(fldr, kmediafile.FileName)
                        );
                    kmediafile.Active = MakeVenueActiveChk.Checked;
                    kfiles.Add(kmediafile);

                } // Has image

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
                                    KwendaFileItem kmediafile = new KwendaFileItem();
                                    kmediafile.VenueId = Venue.Id;
                                    kmediafile.FileName = poii.MediaFile;
                                    kmediafile.FileExt = Path.GetExtension(kmediafile.FileName);
                                    
                                    kmediafile.Data = File.ReadAllBytes(
                                        Path.Combine(fldr, kmediafile.FileName)
                                        );

                                    kmediafile.Active = MakeVenueActiveChk.Checked;
                                    kfiles.Add(kmediafile);

                                } // Has media file

                            } // foreach poii

                        } // Has infos

                    } // foreach Pois

                } // Has pois

                foreach (WFNode n in Venue.NodesGraph.Vertices)
                {
                    if (!string.IsNullOrWhiteSpace(n.Heading1Info))
                    {
                        WFHeadingInfo hi = new WFHeadingInfo(n.Heading1Info);
                        if (!string.IsNullOrWhiteSpace(hi.Image))
                        {
                            KwendaFileItem kmediafile = new KwendaFileItem();
                            kmediafile.VenueId = Venue.Id;
                            kmediafile.FileName = hi.Image;
                            kmediafile.FileExt = Path.GetExtension(kmediafile.FileName);

                            kmediafile.Data = File.ReadAllBytes(
                                        Path.Combine(fldr, kmediafile.FileName)
                                        );

                            kmediafile.Active = MakeVenueActiveChk.Checked;
                            kfiles.Add(kmediafile);

                        } // Image assigned

                    } // Has Headinginfo
                    if (!string.IsNullOrWhiteSpace(n.Heading2Info))
                    {
                        WFHeadingInfo hi = new WFHeadingInfo(n.Heading2Info);
                        if (!string.IsNullOrWhiteSpace(hi.Image))
                        {
                            KwendaFileItem kmediafile = new KwendaFileItem();
                            kmediafile.VenueId = Venue.Id;
                            kmediafile.FileName = hi.Image;
                            kmediafile.FileExt = Path.GetExtension(kmediafile.FileName);

                            kmediafile.Data = File.ReadAllBytes(
                                        Path.Combine(fldr, kmediafile.FileName)
                                        );

                            kmediafile.Active = MakeVenueActiveChk.Checked;
                            kfiles.Add(kmediafile);

                        } // Image assigned

                    } // Has Headinginfo
                    if (!string.IsNullOrWhiteSpace(n.Heading3Info))
                    {
                        WFHeadingInfo hi = new WFHeadingInfo(n.Heading3Info);
                        if (!string.IsNullOrWhiteSpace(hi.Image))
                        {
                            KwendaFileItem kmediafile = new KwendaFileItem();
                            kmediafile.VenueId = Venue.Id;
                            kmediafile.FileName = hi.Image;
                            kmediafile.FileExt = Path.GetExtension(kmediafile.FileName);

                            kmediafile.Data = File.ReadAllBytes(
                                        Path.Combine(fldr, kmediafile.FileName)
                                        );

                            kmediafile.Active = MakeVenueActiveChk.Checked;
                            kfiles.Add(kmediafile);

                        } // Image assigned

                    } // Has Headinginfo
                    if (!string.IsNullOrWhiteSpace(n.Heading4Info))
                    {
                        WFHeadingInfo hi = new WFHeadingInfo(n.Heading4Info);
                        if (!string.IsNullOrWhiteSpace(hi.Image))
                        {
                            KwendaFileItem kmediafile = new KwendaFileItem();
                            kmediafile.VenueId = Venue.Id;
                            kmediafile.FileName = hi.Image;
                            kmediafile.FileExt = Path.GetExtension(kmediafile.FileName);

                            kmediafile.Data = File.ReadAllBytes(
                                        Path.Combine(fldr, kmediafile.FileName)
                                        );

                            kmediafile.Active = MakeVenueActiveChk.Checked;
                            kfiles.Add(kmediafile);

                        } // Image assigned

                    } // Has Headinginfo
                    if (!string.IsNullOrWhiteSpace(n.Heading5Info))
                    {
                        WFHeadingInfo hi = new WFHeadingInfo(n.Heading5Info);
                        if (!string.IsNullOrWhiteSpace(hi.Image))
                        {
                            KwendaFileItem kmediafile = new KwendaFileItem();
                            kmediafile.VenueId = Venue.Id;
                            kmediafile.FileName = hi.Image;
                            kmediafile.FileExt = Path.GetExtension(kmediafile.FileName);

                            kmediafile.Data = File.ReadAllBytes(
                                        Path.Combine(fldr, kmediafile.FileName)
                                        );

                            kmediafile.Active = MakeVenueActiveChk.Checked;
                            kfiles.Add(kmediafile);

                        } // Image assigned

                    } // Has Headinginfo

                } // foreach node


                if (Venue.Maps != null)
                {
                    foreach (WFMap m in Venue.Maps)
                    {
                        if (!string.IsNullOrWhiteSpace(m.FileName))
                        {
                            KwendaFileItem kmediafile = new KwendaFileItem();
                            kmediafile.VenueId = Venue.Id;
                            kmediafile.FileName = m.FileName;
                            kmediafile.FileExt = Path.GetExtension(kmediafile.FileName);

                            kmediafile.Data = File.ReadAllBytes(
                                        Path.Combine(fldr, kmediafile.FileName)
                                        );

                            kmediafile.Active = MakeVenueActiveChk.Checked;
                            kfiles.Add(kmediafile);

                        } // Has file name

                    } // foreach Map

                } // Has Maps


                // Ensure we're logged in.
                if (!EnsureLogin())
                {
                    MessageBox.Show("Kunde inte spara ändringarna eftersom du inte är inloggad.", "Inte inloggad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


                Controllers.DataController.Me.UpdateKwendaFiles(
                    Controllers.DataController.Me.Token,
                    kfiles.ToArray()
                    );

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("PushToCloud(): {0}",
                    ex.Message
                    );
                MessageBox.Show(errmsg, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public bool LoadVenueFromCloud()
        {
            try
            {
                using (SelectVenueDialog dlg = new SelectVenueDialog(Venue.Id))
                {
                    Application.UseWaitCursor = false;
                    Application.DoEvents();

                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        return false;

                    } // User cancelled

                    Application.UseWaitCursor = true;
                    Application.DoEvents();

                    // Clear the UI and release files that might be locked
                    Venue = new WFVenue();
                    VenueBS.ResetBindings(false);

                    loadguard = true;

                    KwendaFileListItem sel = dlg.SelectedFile;
                    if (sel == null)
                    {
                        return false;

                    } // Nothing to load

                    KwendaFileId fid = new KwendaFileId();
                    fid.VenueId = sel.VenueId;
                    fid.FileName = sel.FileName;

                    KwendaFileItem venuefile = Controllers.DataController.Me.GetKwendaFile(
                        Controllers.DataController.Me.Token,
                        fid
                        );

                    if (venuefile == null)
                    {
                        throw new Exception("Något gick fel när filen skulle hämtas.");

                    } // Error

                    //här
                    DoOpenVenue(
                        venuefile.FileName,
                        Encoding.UTF8.GetString(venuefile.Data)
                        );
                    MakeVenueActiveChk.Checked = venuefile.Active;

                    // Download missing files
                    string fldr = GetDataFilesFolder();

                    var files = Controllers.DataController.Me.ListFiles(
                        Controllers.DataController.Me.Token
                        ).Where(w =>
                            w.VenueId == Venue.Id &&
                            w.FileExt.ToLower() != ".venue" &&
                            w.FileExt.ToLower() != ".graphml"
                        ).ToArray();



                    
                    
                    foreach (var f in files)
                    {
                        Application.DoEvents();

                        string localfile = Path.Combine(fldr, f.FileName);
                        FileInfo fi = new FileInfo(localfile);
                        if (!fi.Exists ||
                            (fi.Exists &&
                            fi.LastWriteTimeUtc < f.LastModified)
                            )
                        {
                            string remotefile = Controllers.DataController.RemoteFileUrl
                                .AddToUrl(f.VenueId)
                                .AddToUrl(f.FileName);

                            HttpClient cli = new HttpClient();
                            cli.DownloadFile(
                                remotefile,
                                localfile
                                );

                        } // Need to be downloaded

                    } // foreach file
                    

                    while (HttpClient.ActiveDownloads > 0)
                    {
                        Application.DoEvents();

                    } // Wait for the downloads to complete

                    return true;

                } // using

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            finally
            {
                loadguard = false;
                VenueBS.ResetBindings(false);
                Application.UseWaitCursor = false;

            }

        }

        private void SelectDataFolder()
        {
            try
            {
                DataFolderDialog.SelectedPath = VenueMaker.Models.Preferences.Me.DataFolder;
                if (DialogResult.OK != DataFolderDialog.ShowDialog())
                {
                    return;

                } // Cancelled

                VenueMaker.Models.Preferences.Me.DataFolder = DataFolderDialog.SelectedPath;
                VenueMaker.Models.Preferences.Me.Save();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public string GetDataFilesFolder()
        {
            string folder = Path.Combine(
                VenueMaker.Models.Preferences.Me.DataFolder,
                Venue.Id
                );

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);

            } // Create it

            return folder;
        }

        private void SwitchToTab(TabPage tab)
        {
            try
            {
                Tabs.SelectedTab = tab;

            }
            catch (Exception ex)
            {
                string errmsg = $"Kunde inte växla till fliken {tab.Text}: {ex.Message}";
                MessageBox.Show(errmsg, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void SelectVenueImage()
        {
            try
            {
                if (OpenMediaFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;

                } // No file selected

                Application.UseWaitCursor = true;
                Application.DoEvents();

                VenueImagePB.Image.Dispose();
                VenueImagePB.Image = null;

                string mediafile = UseThisFile(OpenMediaFileDialog.FileName);

                Venue.Image = mediafile;
                VenueImageTB.Text = Venue.Image;

                if (!loadguard)
                {
                    VenueImagePB.Image = Image.FromFile(Path.Combine(GetDataFilesFolder(), mediafile));

                } // Not loading

                _modified = true;

                SystemSounds.Asterisk.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.UseWaitCursor = false;
                Application.DoEvents();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            finally
            {
                Application.UseWaitCursor = false;
            }

        }

        private void AddMap()
        {
            try
            {
                if (OpenMediaFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;

                } // No file selected

                Application.UseWaitCursor = true;
                Application.DoEvents();

                string mediafile = UseThisFile(OpenMediaFileDialog.FileName);

                List<WFMap> mapsl = new List<WFMap>();
                if (Venue.Maps != null)
                {
                    mapsl.AddRange(Venue.Maps);

                } // Not nulls
                WFMap m = new WFMap();
                m.FileName = mediafile;
                m.Id = Guid.NewGuid().ToString();
                m.Title = m.FileName;
                m.Language = "svSE";

                mapsl.Add(m);

                Venue.Maps = mapsl.ToArray();
                MapsBS.DataSource = Venue.Maps;
                MapsBS.ResetBindings(false);

                _modified = true;

                SystemSounds.Asterisk.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Application.UseWaitCursor = false;

            }
        }

        private void DeleteMap()
        {
            try
            {
                // Delete map
                WFMap m = MapsBS.Current as WFMap;
                if (m == null)
                {
                    return;

                } // Is null

                DialogResult dr = MessageBox.Show($"Vill du ta bort \"{m.Title}\"?", "Radera karta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes != dr)
                {
                    return;

                } // Don't sdelete

                Application.UseWaitCursor = true;
                Application.DoEvents();

                List<WFMap> mapsl = Venue.Maps.ToList();
                mapsl.Remove(m);

                Venue.Maps = mapsl.ToArray();
                MapsBS.DataSource = Venue.Maps;
                MapsBS.ResetBindings(false);

                _modified = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Application.UseWaitCursor = false;

            }
        }

        private void MapsLB_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                WFMap m = MapsBS.Current as WFMap;
                if (m == null)
                {
                    return;

                } // Is null

                using (MapPropertiesDialog dlg = new MapPropertiesDialog())
                {
                    dlg.Map = m;
                    if (DialogResult.OK != dlg.ShowDialog())
                    {
                        return;

                    } // Cancelled

                    _modified = true;

                } // using


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PinNodeOnMap()
        {
            try
            {
                if (Venue.Maps == null ||
                    Venue.Maps.Length == 0)
                {
                    MessageBox.Show("Det finns inga kartor inlagda.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                } // No maps

                using (EditMapPointsAndEdgesDialog dlg = new EditMapPointsAndEdgesDialog())
                {
                    dlg.Venue = Venue;
                    dlg.Node = NodesBS.Current as WFNode;

                    dlg.ShowDialog();

                    _modified = true;

                } // using

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PinEdgeOnMap()
        {
            try
            {
                if (Venue.Maps == null ||
                    Venue.Maps.Length == 0)
                {
                    MessageBox.Show("Det finns inga kartor inlagda.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                } // No maps

                using (EditMapPointsAndEdgesDialog dlg = new EditMapPointsAndEdgesDialog())
                {
                    WFEdge<WFNode> edg = (EdgesForPOIBS.Current as EdgeForPOI).Edge;

                    dlg.Venue = Venue;
                    dlg.Edge = edg;

                    dlg.ShowDialog();

                    _modified = true;

                    EdgeForPOI[] dfpis = EdgesForPOIBS.DataSource as EdgeForPOI[];

                    var retrn = dfpis.Where(w =>
                        w.Edge.Start == edg.Destination &&
                        w.Edge.Destination == edg.Start
                        ).FirstOrDefault();
                    if (retrn != null)
                    {
                        var dr = MessageBox.Show("Är det samma väg tillbaks?", "Returväg", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult.Yes == dr)
                        {
                            retrn.Edge.MapPoints = edg.MapPoints.Reverse().ToArray();

                        } // Yes
                        

                    } // Has return path

                } // using

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                foreach (WFNode n in Venue.NodesGraph.GetNodesAlphabetical(false))
                {
                    Brush b = Brushes.ForestGreen;

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
                    if (ShowNodeNamesOnMapChk.Checked)
                    {
                        e.Graphics.DrawString(
                            n.Name,
                            f,
                            b,
                            r.Right + 2,
                            r.Top
                            );

                    } // Show node names

                } // foreach

            }
            catch
            {
            }

        }

        private void ShowNodeNamesOnMapChk_CheckedChanged(object sender, EventArgs e)
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

        private void POIInfoStartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                WFPOIInformation poii = POIInfosBS.Current as WFPOIInformation;
                if (poii == null)
                {
                    return;

                } // Nothing theres

                using (PickDateAndTimeDialog dlg = new PickDateAndTimeDialog())
                {
                    if (sender == POIInfoStartBtn)
                    {
                        dlg.SelectedDateTime = poii.StartsAt;

                    }
                    else
                    {
                        dlg.SelectedDateTime = poii.EndsAt;

                    } // else

                    DateTime? val = null;
                    DialogResult dr = dlg.ShowDialog();

                    switch (dr)
                    {
                        case DialogResult.Cancel:
                            return;

                        case DialogResult.Yes:
                            val = dlg.SelectedDateTime;
                            break;

                        case DialogResult.No:
                            val = null;
                            break;
                    } // switch
                    
                    if (sender == POIInfoStartBtn)
                    {
                        poii.StartsAt = val;

                    }
                    else
                    {
                        poii.EndsAt = val;

                    } // else
                    POIInfosBS.ResetBindings(false);

                    _modified = true;

                } // using

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modified)
            {
                DialogResult dr = MessageBox.Show("Vill du spara ändringarna som gjorts?", "Spara ändringar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (DialogResult.Cancel == dr)
                {
                    e.Cancel = true;

                } // Chickened out
                else if (DialogResult.Yes == dr)
                {
                    SaveVenue(false);

                }

            } // There are changes

        }
    } // class
}

