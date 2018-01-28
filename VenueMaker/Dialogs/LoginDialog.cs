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
using VenueMaker.KwendaService;
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

        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            
            KwendaService.KwendaService cli = new KwendaService.KwendaService();
            
            LoginRequest req = new LoginRequest();
            req.Email = Item.Email;
            req.Password = Item.Password.Encrypt();
            req.AppID = "se.mawingu.venuemaker";

            LoginResult res = cli.Login(req);

            if (res.Result == LoginResultMethodResult.Ok)
            {
                DataController.Me.Email = Item.Email;
                DataController.Me.Password = Item.Password;

                SystemSounds.Asterisk.Play();
                DialogResult = DialogResult.OK;
                
            } // Ok
            else
            {
                MessageBox.Show(res.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                    }

    }
}
