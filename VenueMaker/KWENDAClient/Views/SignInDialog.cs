using KWENDA.DTO;
using System;
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

                //await Client.SignUp(Client.UserName);

                await Client.SignInToAccount();
                
                if (SignUpChk.Checked)
                {
                    await Client.SignUp(
                        Client.UserName
                        );

                }

                SignInResponse signin_data = await Client.SignIn(
                    Client.UserName
                    );


                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during sign in: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
