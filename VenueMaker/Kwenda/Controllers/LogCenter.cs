using Kwenda;
using System;
#if __IOS__
using UIKit;
#endif

namespace Mawingu
{
	public class LogCenter
	{
		private static LogCenter lc;

#if __IOS__
        public static UIViewController CurrentVC
        {
            get
            {
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                while (vc.PresentedViewController != null)
                {
                    vc = vc.PresentedViewController;

                } // while

                return vc;

            } // get

        } // CurrentVC
#endif


        public LogCenter ()
		{
		}

		public static void Debug(string aMsg)
		{

		}


        public static void Error(string aIdentifyer, string aMsg, bool aDisplay = false)
		{
            Log(aIdentifyer, aMsg);

#if __IOS__
            if (aDisplay &&
				CurrentVC != null)
			{
				UIAlertController alert = UIAlertController.Create(
					"Error".Translate(),					                   
					aMsg,					                   
					UIAlertControllerStyle.Alert
				);
				alert.AddAction(UIAlertAction.Create(
					"Dismiss".Translate(),
					UIAlertActionStyle.Default,
					null
				));

				CurrentVC.PresentViewController(alert, true, null);

            }
#endif


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

