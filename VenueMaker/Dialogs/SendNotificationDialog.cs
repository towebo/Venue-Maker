using Kwenda.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenueMaker.Dialogs
{
    public partial class SendNotificationDialog : Form
    {
        public SendNotificationDialog()
        {
            InitializeComponent();
        }


        public static void SendPushNotification(string venueId)
        {
            try
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();

                using (SendNotificationDialog dlg = new SendNotificationDialog())
                {
                    dlg.VenueIdTB.Text = venueId;
                    dlg.StatusCombo.Text = "info";

                    if (DialogResult.OK != dlg.ShowDialog())
                    {
                        return;

                    } // Cancelled

                    Dictionary<string, object> msgparams = new Dictionary<string, object>();
                    msgparams["message"] = dlg.MessageTB.Text;
                    //msgparams["sound"] = "default";
                    //msgparams["venueId"] = dlg.VenueIdTB.Text;
                    //msgparams["status"] = dlg.StatusCombo.Text;
                    NotificationController.SendTemplateNotificationREST(msgparams);

                } // using

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel när pushnotis skulle skickas: {ex.Message}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Application.UseWaitCursor = false;

            }

        }





    }
}
