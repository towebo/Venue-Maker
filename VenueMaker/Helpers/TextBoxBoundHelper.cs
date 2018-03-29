using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenueMaker.Helpers
{
    public static class TextBoxBoundHelper
    {

        // Call AllowEmptyValueForTextbox() for each TextBox during initialization. 
        public static void AllowEmptyValue(this TextBox textBox)
        {
            if (textBox.DataBindings["Text"] != null)
            {
                textBox.DataBindings["Text"].Format += OnTextBoxBindingFormat;
                textBox.DataBindings["Text"].Parse += OnTextBoxBindingParse;

            }

        }

        public static void OnTextBoxBindingParse(object sender, ConvertEventArgs e)
        {
            string value = Convert.ToString(e.Value);
            if (String.IsNullOrEmpty(value))
            {
                e.Value = null;

            }

        }

        public static void OnTextBoxBindingFormat(object sender, ConvertEventArgs e)
        {
            // Convert the value from the dataset to a value in the textbox. 
            if (e.Value == null)
            {
                e.Value = String.Empty;

            }

        }



    }
}
