using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Mawingu;

namespace VenueMaker.Utils
{
	public class FtpClient
	{
		private FtpWebRequest request;


		public delegate void NotifyEvent( object o, EventArgs e );

		public FtpClient ( string aHost, string aUser, string aPw )
		{
			this.Host = aHost;
			this.UserName = aUser;
			this.Password = aPw;

		}


		public string[] GetList( string aFolder)
		{
			List<string> files = new List<string> ();
			string weburl = this.Host;
			weburl += aFolder;

						request = (FtpWebRequest)WebRequest.Create (weburl);
			request.Method = WebRequestMethods.Ftp.ListDirectory;
			request.KeepAlive = this.KeepAlive;
			request.Credentials = new NetworkCredential (this.UserName, this.Password);

			try
			{
				FtpWebResponse response = (FtpWebResponse)request.GetResponse ();
				Stream stream = response.GetResponseStream ();
				StreamReader reader = new StreamReader (stream);

				while (!reader.EndOfStream)
				{
					string item = reader.ReadLine ();
					if (item != "." && item != "..")
					{
						files.Add (item);

					}

				}

				reader.Close ();

				return files.ToArray ();

			}
			catch (Exception e)
			{
                LogCenter.Error($"FtpClient.GetList({aFolder}", e.Message);
				return files.ToArray ();

			}


		}


		public void DownloadFile(string aFtpFile, string aFtpFolder, string aLocalFolder)
		{
			string weburl = this.Host;
			weburl += aFtpFolder;
			weburl += aFtpFile;

			request = (FtpWebRequest)WebRequest.Create (weburl);
			request.UseBinary = true;
			request.Method = WebRequestMethods.Ftp.DownloadFile;
			request.KeepAlive = this.KeepAlive;
			request.Credentials = new NetworkCredential ( this.UserName, this.Password );

			FtpWebResponse response = (FtpWebResponse)request.GetResponse ();
			Stream responsestream = response.GetResponseStream ();


			string localfile = Path.Combine (aLocalFolder, aFtpFile);
			FileInfo fi = new FileInfo (localfile);
			if (fi.Exists)
			{
				fi.Delete();

			}

			try {
				FileStream file = new FileStream (localfile, FileMode.Create);
				responsestream.CopyTo (file);
				file.Close ();
				file = null;
				responsestream.Close ();
				response.Close ();

				// Se till så vi har rätt fildatum.
				DateTime ftpdate = FtpFileDate(aFtpFile, aFtpFolder);
				File.SetLastWriteTime(localfile, ftpdate.ToLocalTime());

			}
			catch (Exception e)
			{
				Console.Write (e.Message);
				responsestream.Close ();
				response.Close ();
			}

		}

		public DateTime FtpFileDate( string aFtpFile, string aFtpFolder )
		{
			string weburl = this.Host;
			weburl += aFtpFolder;
			weburl += aFtpFile;

			request = (FtpWebRequest)WebRequest.Create (weburl);
			request.UseBinary = true;
			request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
			request.KeepAlive = this.KeepAlive;
			request.Credentials = new NetworkCredential ( this.UserName, this.Password );

			try
			{
				FtpWebResponse response = (FtpWebResponse)request.GetResponse ();
				return response.LastModified;

			}
			catch (Exception ex)
			{
                LogCenter.Error($"FtpFileDate({aFtpFile})", ex.Message);
				return new DateTime ();

			}




		}

		public void UploadFile( string aLocalFile, string aFtpFolder, bool aIsTextFile )
		{
			string tmpurl = this.Host + this.TempFolder + Path.GetFileName (aLocalFile);
			string desturl = "/" + aFtpFolder + Path.GetFileName (aLocalFile);


			request = (FtpWebRequest)WebRequest.Create (tmpurl);

			request.UseBinary = true;
			request.Method = WebRequestMethods.Ftp.UploadFile;						request.KeepAlive = this.KeepAlive;
			request.Credentials = new NetworkCredential (this.UserName, this.Password);

			try
			{

				byte[] filecontents;
				if (aIsTextFile)
				{
					StreamReader sourcestream = new StreamReader (aLocalFile);
					filecontents = Encoding.UTF8.GetBytes (sourcestream.ReadToEnd ());
					sourcestream.Close ();
				}
				else {
					filecontents = File.ReadAllBytes (aLocalFile);
				}


				request.ContentLength = filecontents.Length;

				Stream requeststream = request.GetRequestStream ();
				requeststream.Write (filecontents, 0, filecontents.Length);
				requeststream.Close ();

				FtpWebResponse response = (FtpWebResponse)request.GetResponse ();

				response.Close ();
				response = null;
				request = null;

				// Move from tmp to real destination.
				MoveFile(tmpurl, desturl);


			}
			catch ( Exception e)
			{
				throw e;
			}

		}


		public void MoveFile( string aFrom, string aTo )
		{
			request = (FtpWebRequest)WebRequest.Create (aFrom);
			request.Method = WebRequestMethods.Ftp.Rename;
			request.Credentials = new NetworkCredential (this.UserName, this.Password);

			try
			{
				request.RenameTo = aTo;
				request.GetResponse();

			}
			catch (Exception ex)
			{
                LogCenter.Error($"FtpClient.MoveFile({aFrom}, {aTo})", ex.Message);

			}

		}


		// Properties
		public string Host { get; set; }
		public Boolean KeepAlive { get; set; }
		public string Password { get; set; }
		public string UserName { get; set; }
		public string TempFolder { get; set; }

	}
}

