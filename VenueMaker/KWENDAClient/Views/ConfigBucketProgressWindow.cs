using ConfigBucketClient.ServiceManagers;
using Mawingu.Helpers;
using MAWINGU.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigBucket.Views
{
    public partial class ConfigBucketProgressWindow : Form
    {
        private static ConfigBucketProgressWindow _me;

        private BucketClient _client;

        private const string CBLogo = "ConfigBucket_White_48.png";



        public BucketClient Client
        {
            get { return _client; }
            set
            {
                _client = value;
                _client.OnStatus += _client_OnStatus;
            }
        }

        public static ConfigBucketProgressWindow Me
        {
            get
            {
                if (_me == null)
                {
                    _me = new ConfigBucketProgressWindow();
                }
                return _me;
            }
        }


        public ConfigBucketProgressWindow()
        {
            InitializeComponent();
        }

        public static ConfigBucketProgressWindow ViewProgress(BucketClient theClient)
        {
            ConfigBucketProgressWindow result = new ConfigBucketProgressWindow();
            _me = result;
            result.Client = theClient;
            result.TopMost = true;
            result.Show();

            return result;

        }

        private void _client_OnStatus(object sender, BucketClientStatusEventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        _client_OnStatus(sender, e);
                        return;

                    }); // Invoke

                } // Invoke required

                InfoLabel.Text = e.StatusMessage;

            }
            catch (Exception ex)
            {
                string msg = $"Fel när status för ConfigBucket skulle visas: {ex.Message}";
                LogCenter.Error(msg, ex);
                MessageBox.Show(msg, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ConfigBucketProgressWindow_Load(object sender, EventArgs e)
        {
            try
            {
                InfoLabel.Text = string.Empty;

                LogoPB.Image = ResourceHelper.GetImage(CBLogo);

            }
            catch (Exception ex)
            {
                string msg = $"Fel när fönstret skulle initieras: {ex.Message}";
                LogCenter.Error(msg, ex);
                MessageBox.Show(msg, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



    } // class

}