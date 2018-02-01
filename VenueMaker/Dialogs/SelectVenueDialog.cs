using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VenueMaker.Controllers;

namespace VenueMaker.Dialogs
{
    public partial class SelectVenueDialog : Form
    {
        public SelectVenueDialog()
        {
            InitializeComponent();
        }


        private void InitUI()
        {
            try
            {
                var files = DataController.Me.ListFiles(
                        DataController.Me.Token
                        );

                VenuesBS.DataSource = files;

                VenuesLB.DataSource = VenuesBS;
                VenuesLB.DisplayMember = "Name";
                VenuesLB.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SelectVenueDialog_Load(object sender, EventArgs e)
        {
            try
            {
                InitUI();

            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
}
