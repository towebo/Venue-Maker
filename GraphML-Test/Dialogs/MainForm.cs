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
                VenueBS.DataSource = Venue;

                VenueNameTB.DataBindings.Add("Text", VenueBS, "Name");
                VenueIDTB.DataBindings.Add("Text", VenueBS, "Id");





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
            try
            {
                Venue = new WFVenue();
                SaveVenueDialog.FileName = "";

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
                Venue = new WFVenue();

                InitUI();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
