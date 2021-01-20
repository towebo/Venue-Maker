using KWENDA.DTO;
using MAWINGU.Authentication.DTO;
using MAWINGU.Logging;
using System;
using System.Net;
using System.Windows.Forms;

namespace KWENDA.Views
{
    public partial class SignInDialog : Form
    {

        public KWENDARestClient Client { get; set; }

        public SignInDialog()
        {
            InitializeComponent();
        }

        private async void SignInBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Client.UserName = UserNameTB.Text;
                Client.Password = PwTB.Text;

                if (string.IsNullOrWhiteSpace(Client.UserName))
                {
                    throw new Exception("Användarnamnet får inte vara tomt.");
                } // No user
                if (string.IsNullOrWhiteSpace(Client.Password))
                {
                    throw new Exception("Inget lösenord har angetts..");
                } // No user

                AuthenticateResponse authres = await Client.SignInToAccount();
                if (authres.Error != null)
                {
                    throw new Exception(authres.Error.Message);
                } // Error
                
                
                if (SignUpChk.Checked)
                {
                    await Client.SignUp(
                        Client.UserName
                        );

                } // Sign up

                SignInResponse signin_data = await Client.SignIn(
                    Client.UserName
                    );

                if (signin_data.Error != null)
                {
                    throw new Exception(signin_data.Error.Message);

                } // Error

                    DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during sign in: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void SignInDialog_Load(object sender, EventArgs e)
        {
            try
            {
                if (Client != null)
                {
                    UserNameTB.Text = Client.UserName;
                    PwTB.Focus();

                } // Client assigned

            }
            catch (Exception ex)
            {
                string msg = $"Fel när inloggningsfönstret initierades: {ex.Message}";
                LogCenter.Error(msg, ex);
                MessageBox.Show(msg, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    } // class

}