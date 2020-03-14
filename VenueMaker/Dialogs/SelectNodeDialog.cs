using System;
using System.Linq;
using System.Windows.Forms;
using WayfindR.Helpers;
using WayfindR.Models;

namespace VenueMaker.Dialogs
{
    public partial class SelectNodeDialog : Form
    {


        public WFVenue Venue { get; set; }

        public WFNode SelectedNode
        {
            get
            {
                WFNode result = NodesBS.Current as WFNode;
                return result;

            } // get
        } // SelectedNode


        public SelectNodeDialog()
        {
            InitializeComponent();
        }

        private void SelectNodeDialog_Load(object sender, System.EventArgs e)
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

        private void InitUI()
        {
            try
            {
                NodesBS.DataSource = Venue.NodesGraph.GetNodesAlphabetical(false).OrderBy(w => w, new FloorComparer()).ToArray();
                NodesLB.DataSource = NodesBS;
                NodesLB.DisplayMember = nameof(WFNode.TextInList);
                NodesLB.ValueMember = nameof(WFNode.Guid);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



    } // class
}
