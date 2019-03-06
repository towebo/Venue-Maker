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
    public partial class ChangeBeaconForNodeDialog : Form
    {
        private ChangeBeaconInfo info;

        public ChangeBeaconInfo Info
        {
            get { return info; }
        } // Info


        public ChangeBeaconForNodeDialog()
        {
            InitializeComponent();
            info = new ChangeBeaconInfo();

        }

        private void ChangeBeaconForNodeDialog_Load(object sender, EventArgs e)
        {
            try
            {
                InitUI();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private void InitUI()
        {
            try
            {
                InputBS.DataSource = info;

                UuidTB.DataBindings.Add("Text", InputBS, nameof(info.Uuid), false, DataSourceUpdateMode.OnPropertyChanged);
                MajorTB.DataBindings.Add("Text", InputBS, nameof(info.Major), false, DataSourceUpdateMode.OnPropertyChanged);
                MinorTB.DataBindings.Add("Text", InputBS, nameof(info.Minor), false, DataSourceUpdateMode.OnPropertyChanged);

            }
            catch (Exception ex)
            {
                throw new Exception($"InitUI(): {ex.Message}");

            }
        }




    } // class


    public class ChangeBeaconInfo
    {
        public string Uuid { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }

    }


}
