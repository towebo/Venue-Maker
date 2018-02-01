using VenueMaker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VenueMaker.Kwenda;
using VenueMaker.Helpers;
using VenueMaker.Controllers;
using System.Media;

namespace VenueMaker.Dialogs
{
    public partial class LoginDialog : Form
    {

        public LoginInfoModel Item { get; set; }


        public event EventHandler<LoginInfoModel> AttemtToLogin;


        public LoginDialog()
        {
            InitializeComponent();
        }

        private void InitUI()
        {
            InfoBS.DataSource = Item;

            EmailTB.DataBindings.Add("Text", InfoBS, "Email");
            PwTB.DataBindings.Add("Text", InfoBS, "Password");

            VerificationCodeLabel.Visible = false;
            VerificationCodeTB.Visible = VerificationCodeLabel.Visible;


        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {

            using (KwendaServiceClient cli = new KwendaServiceClient())
            {
                if (VerificationCodeLabel.Visible)
                {
                    VerifyAccountRequest vreq = new VerifyAccountRequest();
                    vreq.Email = Item.Email;
                    vreq.Code = Convert.ToInt32(VerificationCodeTB.Text);
                    VerifyAccountResponse vres = cli.VerifyAccount(vreq);

                    if (vres.Result == VerifyAccountResponse.MethodResult.Ok)
                    {
                        VerificationCodeLabel.Visible = false;
                        VerificationCodeTB.Visible = VerificationCodeLabel.Visible;

                    }
                    else
                    {
                        MessageBox.Show(vres.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    } // Not ok
                    
                } // Verify account first
                

                LoginRequest req = new LoginRequest();
                req.Email = Item.Email;
                req.Password = Item.Password.Encrypt();
                req.AppID = "se.mawingu.venuemaker";

                LoginResponse res = cli.Login(req);

                if (res.Result == LoginResponse.MethodResult.Ok)
                {
                    DataController.Me.Email = Item.Email;
                    DataController.Me.Password = Item.Password;
                    DataController.Me.Token = res.Token;

                    SystemSounds.Asterisk.Play();
                    DialogResult = DialogResult.OK;

                } // Ok
                else if (res.Result == LoginResponse.MethodResult.AccountNotVerified)
                {
                    cli.RequestVerificationCode(Item.Email);
                    MessageBox.Show(
                        "Ditt konto behöver verifieras och en verifikationskod har nu skickats till dig.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );

                    VerificationCodeLabel.Visible = true;
                    VerificationCodeTB.Visible = VerificationCodeLabel.Visible;

                } // Not verified


            } // using

        }

    }
}
