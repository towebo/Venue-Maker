using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WayfindR.Models;

namespace VenueMaker.Dialogs
{
    public partial class MapPropertiesDialog : Form
    {
        private WFMap _map;



        public WFMap Map
        {
            get { return _map; }
            set
            {
                _map = value;
                MapBS.DataSource = _map;
                MapBS.ResetBindings(false);
            } // set
        } // Map



        public MapPropertiesDialog()
        {
            InitializeComponent();
        }


        private void InitUI()
        {
            try
            {
                //MapBS.DataSource = new WFMap();

                MapTitleTB.DataBindings.Add("Text", MapBS, nameof(WFMap.Title), false, DataSourceUpdateMode.OnPropertyChanged);


            }
            catch (Exception ex)
            {
                string errmsg = $"Fel när formuläret skulle initieras: {ex.Message}";
                throw new Exception(errmsg);

            }
        }

        private void MapPropertiesDialog_Load(object sender, EventArgs e)
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
