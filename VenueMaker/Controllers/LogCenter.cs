using System;
using System.Windows.Forms;

namespace Mawingu
{
	public class LogCenter
	{
		private static LogCenter lc;

		public LogCenter ()
		{
		}

		public static void Debug(string aMsg)
		{

		}


		public static void Error(string aIdentifyer, string aMsg, bool aDisplay = false)
		{
            Log(aIdentifyer, aMsg);
            
			if (aDisplay)
			{
                MessageBox.Show(aMsg, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

			}

		}


		public static void Log(string aIdentifyer, string aMsg)
		{

		}



		// Properties
		public static LogCenter Me {
			get {
				if (lc == null)
				{
					lc = new LogCenter ();

				}
				return lc;

			}
		}

	}
}

