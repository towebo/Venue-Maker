using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WayfindR.Models;

namespace VenueMaker.Dialogs
{
    public partial class EditHeadingInfoDialog : Form
    {

        public WFHeadingInfo HeadingInfo { get; set; }


        public EditHeadingInfoDialog()
        {
            InitializeComponent();
        }


        private void InitUI()
        {
            HeadingInfoBS.DataSource = this.HeadingInfo;

            HeadingTB.DataBindings.Add("Text", HeadingInfoBS, "Heading");
            InfoTB.DataBindings.Add("Text", HeadingInfoBS, "Info");
            ImageTB.DataBindings.Add("Text", HeadingInfoBS, "Image");
            ImageDescriptionTB.DataBindings.Add("Text", HeadingInfoBS, "ImageDescription");


        }

        private void PickImageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenImageDialog.ShowDialog() != DialogResult.OK)
                {
                    return;

                } // User canceled

                HeadingInfo.Image = Path.GetFileName(OpenImageDialog.FileName);
                ImageTB.Text = HeadingInfo.Image;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void EditHeadingInfoDialog_Load(object sender, EventArgs e)
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
    }
}
