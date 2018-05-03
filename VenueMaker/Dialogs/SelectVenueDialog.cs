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
using System.Linq;
using VenueMaker.Helpers;

namespace VenueMaker.Dialogs
{
    public partial class SelectVenueDialog : Form
    {
        private Dictionary<string,string> listdict;
        private Dictionary<string, KwendaFileListItem> filesdict;


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

                filesdict = files.ToDictionary(w => w.VenueId);
                listdict = new Dictionary<string, string>();
                files.ToList().ForEach(w =>
                {
                    string venid = w.VenueId;
                    while (listdict.ContainsKey(venid))
                    {                    
                        venid = venid + "_";

                    } // while

                    listdict.Add(
                        venid,
                        !string.IsNullOrWhiteSpace(w.FileTitle) ?
                            w.FileTitle :
                            w.FileName
                            );

                });
                                
                VenuesBS.DataSource = listdict.OrderBy(w => w.Value);

                VenuesLB.DataSource = VenuesBS;
                VenuesLB.DisplayMember = "Value";
                VenuesLB.ValueMember = "Key";

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
                return filesdict[Convert.ToString(VenuesLB.SelectedValue)];
            }
        }


        
    }
}
