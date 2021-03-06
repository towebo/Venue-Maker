using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VenueMaker.Models;
using WayfindR.Helpers;
using WayfindR.Models;

namespace VenueMaker.Dialogs
{
    public partial class NewEdgeDialog : Form
    {

        public NewEdgeItem Item { get; set; }
        public WFNode[] AvailibleNodes { get; set; }


        public NewEdgeDialog()
        {
            InitializeComponent();
        }


        private void InitUI()
        {
            try
            {
                InfoBS.DataSource = Item ?? new NewEdgeItem();
                SourcesBS.DataSource = AvailibleNodes;
                TargetsBS.DataSource = AvailibleNodes;

                FromNodeCombo.DataSource = SourcesBS;
                FromNodeCombo.DisplayMember = "TextInList";
                FromNodeCombo.ValueMember = "Name";
                FromNodeCombo.DataBindings.Add("SelectedItem", InfoBS, "Source");

                ToNodeCombo.DataSource = TargetsBS;
                ToNodeCombo.DisplayMember = "TextInList";
                ToNodeCombo.ValueMember = "Name";
                ToNodeCombo.DataBindings.Add("SelectedItem", InfoBS, "Target");

                BeginningTB.DataBindings.Add("Text", InfoBS, "Beginning");
                StartHeadingTB.DataBindings.Add("Text", InfoBS, "StartHeading");
                EndHeadingTB.DataBindings.Add("Text", InfoBS, "EndHeading");
                TravelTimeTB.DataBindings.Add("Text", InfoBS, "TravelTime");

                TravelTypeCombo.DataSource = TravelTypeHelper.ToDisplayList();
                TravelTypeCombo.DisplayMember = nameof(TravelTypeListItem.DisplayName);
                TravelTypeCombo.ValueMember = nameof(TravelTypeListItem.Name);
                TravelTypeCombo.DataBindings.Add("SelectedValue", InfoBS, "TravelType", true, DataSourceUpdateMode.OnPropertyChanged);


                InfoBS.ResetBindings(true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void NewEdgeDialog_Load(object sender, EventArgs e)
        {
            InitUI();

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

        }
    }
}
