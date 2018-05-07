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

            CheckPws();

        }

        private void CreateAccountDialog_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private void VerifyPwTB_TextChanged(object sender, EventArgs e)
        {
            CheckPws();
        }

        private bool CheckPws()
        {
            CreateBtn.Enabled = !string.IsNullOrWhiteSpace(PwTB.Text) &&
                PwTB.Text == VerifyPwTB.Text;

            if (!string.IsNullOrEmpty(PwTB.Text) &&
                !string.IsNullOrEmpty(VerifyPwTB.Text))
            {
                if (CreateBtn.Enabled)
                {
                    PwTB.BackColor = SystemColors.Window;
                    PwTB.ForeColor = SystemColors.WindowText;
                    PwTB.AccessibleName = string.Empty;

                    VerifyPwTB.BackColor = PwTB.BackColor;
                    VerifyPwTB.ForeColor = PwTB.ForeColor;
                    VerifyPwTB.AccessibleName = PwTB.AccessibleName;

                }
                else
                {
                    PwTB.BackColor = Color.Red;
                    PwTB.ForeColor = Color.White;
                    PwTB.AccessibleName = "Lösenorden stämmer inte överens";

                    VerifyPwTB.BackColor = PwTB.BackColor;
                    VerifyPwTB.ForeColor = PwTB.ForeColor;
                    VerifyPwTB.AccessibleName = PwTB.AccessibleName;

                } // else Are equal

            } // Alert only when text in both pw boxes

            return CreateBtn.Enabled;

        }

        private void PwTB_TextChanged(object sender, EventArgs e)
        {
            CheckPws();

        }
    }
}
