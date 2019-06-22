//
// This file contains the sample code to use System.Net.WebRequest
// on the iPhone to communicate with HTTP and HTTPS servers
//
// Author:
//   Miguel de Icaza
//

using System;
using System.Net;
using System.IO;


namespace VenueMaker.Utils
{
	public delegate void NotifyEvent( object o, EventArgs e );

	public class HttpClient {
		//AppDelegate ad;

		private static int activedownloads;


		private string filename;
		private string url;
		

        public static int ActiveDownloads
        {
            get { return activedownloads; }
        } // ActiveDownloads

		public HttpClient ()//AppDelegate ad)
		{
		}

		

		public void DownloadFile (string aUrl, string aFileName)
		{
			if (HttpClient.activedownloads == 0)
			{
				//tmp Application.NetActivity (true);
			}

			HttpClient.activedownloads++;

			filename = aFileName;
			url = aUrl;
			var request = WebRequest.Create (url);

			request.BeginGetResponse (FeedDownloaded, request);
		}
		
		void FeedDownloaded (IAsyncResult result)
		{
			var request = result.AsyncState as HttpWebRequest;

			try {
				var response = request.EndGetResponse (result);

				FileInfo fi = new FileInfo(filename);
				if (fi.Exists) 
				{
					fi.Delete();
				}

				Stream webstream = response.GetResponseStream();
				FileStream filestream = new System.IO.FileStream (filename, FileMode.CreateNew);

				webstream.CopyTo(filestream);
				filestream.Close();
				webstream.Close();

				if (DownloadComplete != null )
				{
					DownloadComplete(this, null);
				}

			} catch {
				// Error				
			}

			HttpClient.activedownloads--;
			if (HttpClient.activedownloads == 0)
			{
				//tmp Application.NetActivity (false);

				if (AllDownloadsComplete != null )
				{
					AllDownloadsComplete(this, null);
				}
			}

		}



		// Properties
		public event NotifyEvent DownloadComplete;
		public event NotifyEvent AllDownloadsComplete;
	}
}
