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

namespace VenueMaker.Dialogs
{
    public partial class CreateAccountDialog : Form
    {

        public CreateAccountInfoModel Item { get; set; }


        public CreateAccountDialog()
        {
            InitializeComponent();
        }


        private void InitUI()
        {
            InfoBS.DataSource = Item;

            EmailTB.DataBindings.Add("Text", InfoBS, "Email");
            PwTB.DataBindings.Add("Text", InfoBS, "Password");
            VerifyPwTB.DataBindings.Add("Text", InfoBS, "VerifyPassword");

        }

        private void CreateAccountDialog_Load(object sender, EventArgs e)
        {
            InitUI();
        }
    }
}
