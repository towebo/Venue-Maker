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
                this.Text = AssemblyInfo.GetProductAndVersion();


                VenueBS.DataSource = new WFVenue();
                VenueBS.CurrentChanged += (s1, e1) =>
                {
                    WFVenue v = VenueBS.Current as WFVenue;
                    if (v != null)
                    {
                        if (v.PointsOfInterest != null)
                        {
                            POIsBS.DataSource = v.PointsOfInterest.OrderBy(w => w.TextInList);

                        }
                        else
                        {
                            POIsBS.DataSource = v.PointsOfInterest;

                        }
                        
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

                };

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
                if (sender == saveVenueFileToolStripMenuItem ||
                    string.IsNullOrEmpty(SaveVenueDialog.FileName))
                {
                    if (SaveVenueDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;

                    } // DialogResult = Ok

                } // Save as or not saved

                
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
    }
}
