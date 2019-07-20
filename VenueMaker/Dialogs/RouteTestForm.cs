using WayfindR.Models;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.ShortestPath;
using QuickGraph.Algorithms.Observers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using WayfindR.Controllers;
using SQLite;

namespace WayfindR
{

    public partial class RouteTestForm : Form
    {

        public WFVenue Venue { get; set; }
        

        public RouteTestForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            InitUI();

        }


        private void InitUI()
        {
            try
            {
                this.Text = Venue.Name;

                NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical(false);
                TargetNodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical(false);
                                

                SourceCB.DataSource = NodesBS;
                SourceCB.DisplayMember = "Name";
                SourceCB.ValueMember = "Id";

                TargetCB.DataSource = TargetNodesBS;
                TargetCB.DisplayMember = "Name";
                TargetCB.ValueMember = "Id";
                     

                RouteLB.DataSource = PathBS;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }



        
        private void CalcRouteButton_Click(object sender, EventArgs e)
        {
            try
            {
                WFNode source = NodesBS.Current as WFNode;
                WFNode target = TargetNodesBS.Current as WFNode;
                                
                DirectionsList dl = new DirectionsList(
                    Venue.NodesGraph.CalculateRoute(
                        source,
                        target
                        )
                    );

                PathBS.DataSource = dl.Directions;
                RouteLB.DisplayMember = "Text";
                RouteLB.ValueMember = "Text";
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void BuildCacheButton_Click(object sender, EventArgs e)
        {
            try
            {
                string folder = @"C:\Users\Karl-otto\Dropbox\src\Wayfindr\graphmltest\Data";
                
                VenueController.Me.AddFromFolder(folder, true);
                GraphController.Me.AddFromFolder(folder, false);
                GraphController.Me.BuildNodeCache();

                System.Media.SystemSounds.Asterisk.Play();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }

}