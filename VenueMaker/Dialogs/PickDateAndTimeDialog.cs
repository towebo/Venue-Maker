using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenueMaker.Dialogs
{
    public partial class PickDateAndTimeDialog : Form
    {


        public DateTime? SelectedDateTime
        {
            get
            {
                DateTime? result = MonthCal.SelectionRange.Start.Date +
                    TimePicker.Value.TimeOfDay;
                return result;

            } // get
            set
            {
                if (value.HasValue)
                {
                    MonthCal.SelectionRange.Start = value.Value.Date;
                    MonthCal.SelectionRange.End = MonthCal.SelectionRange.Start;
                    TimePicker.Value = value.Value;

                } // Has value
                else
                {
                    MonthCal.SelectionRange.Start = DateTime.Today;
                    MonthCal.SelectionRange.End = MonthCal.SelectionRange.Start;
                    MonthCal.SelectionRange.Start = DateTime.Today;
                    MonthCal.SelectionRange.End = MonthCal.SelectionRange.Start;
                    TimePicker.Checked = true;
                    TimePicker.Value = DateTime.Now;

                } // No value

            } // set

        } // SelectedDateTime

        public PickDateAndTimeDialog()
        {
            InitializeComponent();
        }

        private void PickDateAndTimeDialog_Load(object sender, EventArgs e)
        {
            try
            {
                TimePicker.CustomFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
