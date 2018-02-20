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
using VenueMaker.Kwenda;

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
                        ).Where(w =>
                            w.FileExt.ToLower() == ".venue"
                        );

                
                VenuesBS.DataSource = files;

                VenuesLB.DataSource = VenuesBS;
                VenuesLB.DisplayMember = "FileName";
                VenuesLB.ValueMember = "VenueId";

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
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public KwendaFileListItem SelectedFile
        {
            get
            {
                return VenuesBS.Current as KwendaFileListItem;
            }
        }



    }
}
