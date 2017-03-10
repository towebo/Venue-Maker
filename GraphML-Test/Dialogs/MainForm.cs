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
    public partial class MainForm : Form
    {



        public WFVenue Venue { get; set; }


        public MainForm()
        {
            InitializeComponent();
        }

        private void closeAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
