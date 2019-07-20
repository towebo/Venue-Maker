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
using System.Security.Cryptography.X509Certificates;


namespace Kwenda
{
	
	public class HttpClient
	{
		//AppDelegate ad;

		private static int activedownloads;


		private string filename;
		private string url;
        private DateTime? filedate;
		
		public HttpClient ()//AppDelegate ad)
		{
		}

		

		public void DownloadFile (string aUrl, string aFileName, DateTime? fileDateToApply = null)
		{
			if (HttpClient.activedownloads == 0)
			{
				//tmp Application.NetActivity (true);
			}

			HttpClient.activedownloads++;

            filedate = fileDateToApply;
			filename = aFileName;
			url = aUrl;
            WebRequest request = WebRequest.Create(url);
            
			request.BeginGetResponse (FeedDownloaded, request);
            

        }
		
		private void FeedDownloaded(IAsyncResult result)
		{
			var request = result.AsyncState as HttpWebRequest;

			try
            {
				var response = request.EndGetResponse (result);
                try
                {
                    if (File.Exists(filename))
                    {
                        File.Delete(filename);

                    } // Delete existing file

                    Stream webstream = response.GetResponseStream();
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        webstream.CopyTo(ms);
                        File.WriteAllBytes(
                            filename,
                            ms.ToArray()
                        );

                        if (filedate.HasValue)
                        {
                            FileInfo fi = new FileInfo(filename);
                            fi.LastWriteTimeUtc = filedate.Value.ToUniversalTime();

                        } // Set the file date

                    }
                    finally
                    {
                        webstream.Close();

                    } // try

                    HttpClient.activedownloads--;

                    if (DownloadComplete != null)
                    {
                        DownloadComplete(this, new EventArgs());

                    } // Call DownloadComplete event

                }
                finally
                {
                    response.Close();

                } // try

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				HttpClient.activedownloads--;

                if (DownloadError != null)
                {
                    DownloadError(this, new EventArgs());

                } // Call DownloadError event

            }

			//HttpClient.activedownloads--;
			if (HttpClient.activedownloads == 0)
			{
				//tmp Application.NetActivity (false);

				if (AllDownloadsComplete != null )
				{
					AllDownloadsComplete(this, new EventArgs());

				} // Call AllDownloadsComplete event

			}

		}



		// Properties
		public static int ActiveDownloads
		{
			get { return activedownloads; }
		}

        public string Url { get { return url; }}
        public string LocalFile { get { return filename; } }


		public event EventHandler<EventArgs> DownloadComplete;
        public event EventHandler<EventArgs> DownloadError;
        public event EventHandler<EventArgs> AllDownloadsComplete;
	}
}
