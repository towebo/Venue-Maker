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
            try
            {
                using (KwendaService cli = new KwendaService())
                {
                    if (VerificationCodeLabel.Visible)
                    {
                        if ((string)VerificationCodeLabel.Tag == "ResetPassword")
                        {
                            ChangePasswordRequest pwreq = new ChangePasswordRequest();
                            pwreq.Code = VerificationCodeTB.Text;
                            pwreq.Email = EmailTB.Text;
                            pwreq.Password = PwTB.Text;

                            ChangePasswordResponse pwresp = cli.ChangePassword(pwreq);

                            if (pwresp.Result == ChangePasswordResponseMethodResult.AccountNotFound)
                            {
                                //tmp MessageBox.Show("Kontot kunde inte hittas.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show(pwresp.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }
                            else if (pwresp.Result == ChangePasswordResponseMethodResult.InvalidCode)
                            {
                                MessageBox.Show("Den angivna koden stämmer inte.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }
                            else if (pwresp.Result == ChangePasswordResponseMethodResult.CodeAlreadyUsed)
                            {
                                MessageBox.Show("Den angivna koden har redan använts.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }
                            else if (pwresp.Result == ChangePasswordResponseMethodResult.CodeExpired)
                            {
                                MessageBox.Show("Den angivna koden är för gammal.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }
                            else if (pwresp.Result == ChangePasswordResponseMethodResult.OtherError)
                            {
                                MessageBox.Show(pwresp.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }
                            else if (pwresp.Result == ChangePasswordResponseMethodResult.Ok)
                            {
                                MessageBox.Show("Ditt lösenord har nu ändrats och du kommer loggas in.", "Lösenordet ändrat", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }
                        else if ((string)VerificationCodeLabel.Tag == "VerifyAccount")
                        {
                            VerifyAccountRequest vreq = new VerifyAccountRequest();
                            vreq.Email = Item.Email;
                            vreq.Code = Convert.ToInt32(VerificationCodeTB.Text);
                            VerifyAccountResponse vres = cli.VerifyAccount(vreq);

                            if (vres.Result == VerifyAccountResponseMethodResult.Ok)
                            {
                                VerificationCodeLabel.Visible = false;
                                VerificationCodeTB.Visible = VerificationCodeLabel.Visible;

                            }
                            else
                            {
                                MessageBox.Show(vres.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            } // Not ok

                        } // Verify Account

                    } // Verify account first


                    LoginRequest req = new LoginRequest();
                    req.Email = Item.Email;
                    req.Password = Item.Password;
                    req.AppID = "se.mawingu.venuemaker";

                    LoginResponse res = cli.Login(req);

                    if (res == null)
                    {
                        throw new Exception(cli.Version());
                    }

                    
                    if (res.Result == LoginResponseMethodResult.Ok)
                    {
                        DataController.Me.Email = Item.Email;
                        DataController.Me.Password = Item.Password;
                        DataController.Me.Token = res.Token;

                        SystemSounds.Asterisk.Play();
                        DialogResult = DialogResult.OK;

                    } // Ok
                    else if (res.Result == LoginResponseMethodResult.AccountNotVerified)
                    {
                        bool theresult;
                        bool resspecified;
                        cli.RequestVerificationCode(Item.Email, out theresult, out resspecified);
                        MessageBox.Show(
                            "Ditt konto behöver verifieras och en verifikationskod har nu skickats till dig.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );

                        VerificationCodeLabel.Visible = true;
                        VerificationCodeTB.Visible = VerificationCodeLabel.Visible;
                        if (VerificationCodeTB.Visible)
                        {
                            VerificationCodeTB.Focus();

                        } // Set focus on the verification code
                        VerificationCodeLabel.Tag = "VerifyAccount";

                    } // Not verified

                    else if (res.Result == LoginResponseMethodResult.InvalidCridentials)
                    {
                        DialogResult dr = MessageBox.Show("Användarnamnet eller lösenordet är felaktigt. Har du glömt ditt lösenord?", "Felaktiga inloggningsuppgifter", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (DialogResult.Yes == dr)
                        {
                            bool callres, resspecified;
                            cli.RequestVerificationCode(Item.Email, out callres, out resspecified);
                            MessageBox.Show(
                                "En verifikationskod har nu skickats till dig som ska anges när du väljer ett nytt lösenord.",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                                );

                            VerificationCodeLabel.Visible = true;
                            VerificationCodeTB.Visible = VerificationCodeLabel.Visible;
                            VerificationCodeLabel.Tag = "ResetPassword";

                            PwTB.Text = string.Empty;
                            PwTB.Focus();

                        } // The user admits!

                    } // Forgotten password


                } // using

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}
