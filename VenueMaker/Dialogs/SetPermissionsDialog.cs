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

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (KwendaService cli = new KwendaService())
                {
                    KwendaPermissionItem perm = new KwendaPermissionItem();
                    perm.Email = EmailTB.Text;
                    perm.VenueId = VenueIdTB.Text;
                    perm.GrantPermission = PermitChk.Checked;
                    perm.ReadOnly = ReadOnlyChk.Checked;

                    SetKwendaPermissionsRequest req = new SetKwendaPermissionsRequest();
                    req.Token = DataController.Me.Token;
                    req.Items = new KwendaPermissionItem[]
                    {
                        perm
                    };

                    SetKwendaPermissionsResponse response = cli.SetKwendaPermissions(req);

                    switch (response.Result)
                    {
                        case SetKwendaPermissionsResponseMethodResult.NoPermission:
                            MessageBox.Show("Du har inte behörighet att utföra denna åtgärd. Logga in med en användare som har tillräckliga behörigheter.", "Otillräckliga rättigheter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case SetKwendaPermissionsResponseMethodResult.NotLoggedIn:
                            MessageBox.Show("Du är inte inloggad.", "Inte inloggad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case SetKwendaPermissionsResponseMethodResult.Ok:
                            DialogResult = DialogResult.OK;
                            break;

                        case SetKwendaPermissionsResponseMethodResult.OtherError:
                            MessageBox.Show(response.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                    } // switch

                } // using

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
