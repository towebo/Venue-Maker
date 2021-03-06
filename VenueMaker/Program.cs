using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VenueMaker.Dialogs;

namespace WayfindR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
