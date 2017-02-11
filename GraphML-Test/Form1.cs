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

    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //InitUI();

        }


        private void InitUI()
        {
            try
            {
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



        private void LoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                string folder = @"C:\Users\Karl-otto\Dropbox\src\Wayfindr\graphmltest\Data";

                /*
                VenueController.Me.Current = VenueController.Me.Add(
                    OpenGraphMLDialog.FileName
                    );                                                                
                    */

                SQLiteConnection db = SQLiteController.Me.Db;


                VenueController.Me.AddFromFolder(folder);
                GraphController.Me.AddFromFolder(folder);
                GraphController.Me.BuildNodeCache();

                VenueController.Me.Current = VenueController.Me.Venues.FirstOrDefault();
                this.Text = VenueController.Me.Current.Name;



                WFGraph[] venugraphs = GraphController.Me.RelatedToVenue(
                    VenueController.Me.Current.Id
                    );
                VenueController.Me.Current.NodesGraph = venugraphs.FirstOrDefault();



                NodesBS.DataSource = VenueController.Me.Current.NodesGraph.GetNodesAlphabetical();
                TargetNodesBS.DataSource = VenueController.Me.Current.NodesGraph.GetNodesAlphabetical();

                InitUI();

                
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
                    VenueController.Me.Current.NodesGraph.CalculateRoute(
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
        
    }

}