using KWENDA;
using KWENDA.DTO;
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
    public partial class SetPermissionsDialog : Form
    {

        public string VenueId
        {
            get { return VenueIdTB.Text; }
            set { VenueIdTB.Text = value; }
        } // VenueId



        public SetPermissionsDialog()
        {
            InitializeComponent();
        }

        private async void ApplyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                KWENDARestClient cli = new KWENDARestClient();
                {
                    PermissionItem perm = new PermissionItem();
                    perm.Email = EmailTB.Text;
                    perm.VenueId = VenueIdTB.Text;
                    perm.GrantPermission = PermitChk.Checked;
                    perm.ReadOnlyAccess = ReadOnlyChk.Checked;

                    SetKWENDAFilePermissionsRequest req = new SetKWENDAFilePermissionsRequest();
                    cli.AccountToken = DataController.Me.Token;
                    
                    req.Items = new PermissionItem[]
                    {
                        perm
                    };

                    SetKWENDAFilePermissionsResponse response = await cli.SetPermissions(req);

                    if (response.Error != null)
                    {
                        throw new Exception(response.Error.Message);
                    } // Error

                    MessageBox.Show("Rättigheter satta.", "Ändra rättigheter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    
                } // using

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
