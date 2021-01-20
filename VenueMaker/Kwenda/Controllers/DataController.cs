using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Threading.Tasks;
using WayfindR.Controllers;
using WayfindR.Models;
using System.Text;
using Kwenda;
using Mawingu;
using Kwenda.Common.Models;
using MAWINGU.Logging;
using KWENDA;
using MAWINGU.Authentication;
using MAWINGU.Authentication.DTO;
using KWENDA.DTO;
#if __IOS__
using Radar.Kwenda;
#else
#endif
//tmp using Kwenda.Common.Models;
using System.Net;
#if __IOS__
using UIKit;
using AudioToolbox;
#elif __ANDROID__
using Android.Content;

#endif

namespace Kwenda
{
	public enum AppFile
	{
		PoisXml_Included,
		PoisXml_Local,
		PoisXml_Remote,
		FileListXml_Local,
		FileListXml_Remote,
		FilesFolder_Local,
		FilesFolder_Remote,
		SQLiteDb,
		Prefs,
        RoutePrefs,
        InfoCatPrefs,
        DropboxLocal,
        DropboxRemote,
		AboutHtml,
		MediaFolder,
        PingOnServer,
        ServicesMawinguHost
	}

	public class DataController
	{
        private static bool loadingdata;

        private static string token;


        public DataController ()
        {            
		}



        public static string GetAppFile(AppFile apf, bool fileNameOnly = false)
		{
			string filename = "";
			string folder = "";

			switch (apf)
			{
			case AppFile.PoisXml_Included:
				filename = "Pois.xml";
				break;

			case AppFile.PoisXml_Local:
				filename = "Pois.xml";
				folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				break;

			case AppFile.PoisXml_Remote:
				filename = "http://mawingu.se/radar/pois.xml";
				break;

			case AppFile.FileListXml_Local:
				filename = "files.xml";
				folder = GetAppFile(AppFile.FilesFolder_Local);
				break;

			case AppFile.FileListXml_Remote:
				filename = "http://mawingu.se/radar/files.xml";
				break;

			case AppFile.FilesFolder_Local:
				folder = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
				folder = Path.Combine(folder, "Data");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
				break;

			case AppFile.FilesFolder_Remote:
				//tmp filename = "http://mawingu.se/radar/";
                    filename = "https://services.mawingu.se/kwenda/data/";
                    break;

			case AppFile.SQLiteDb:
				filename = "data.db3";
				folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				break;
				
			case AppFile.Prefs:
				filename = "Prefs.xml";
				folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				break;

                case AppFile.RoutePrefs:
                    filename = "RoutePrefs.xml";
                    folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    break;

                case AppFile.DropboxLocal:
                    folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    folder = Path.Combine(folder, "Dropbox");
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    break;

                case AppFile.DropboxRemote:
                    folder = "";
                    break;
                    
				case AppFile.AboutHtml:
					folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
					filename = "About.html";
					break;

				case AppFile.MediaFolder:
					folder = GetAppFile(AppFile.FilesFolder_Local);
					break;

                case AppFile.InfoCatPrefs:
                    filename = "POICategoriesPrefs.xml";
                    folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    break;

                case AppFile.PingOnServer:
                    filename = "https://services.mawingu.se/kwenda/ping.html";
                    break;

                case AppFile.ServicesMawinguHost:
                    filename = "https://services.mawingu.se";
                    break;

            } // switch


			if (!fileNameOnly &&
                !string.IsNullOrEmpty(folder))
			{
				filename = Path.Combine (folder, filename);

			}

			return filename;

		}


        /*tmp
		public static string[] DownloadFiles(string xmlFiles, bool forceDownload)
		{
			List<string> result = new List<string> ();
			try
			{
				XDocument xdoc = XDocument.Load(xmlFiles);

                var lmattr = xdoc.Root.Attribute("lastmodified");
                if (lmattr != null)
                {
                    DateTime lastmodified;
                    if (DateTime.TryParse(lmattr.Value, out lastmodified))
                    {
						//Preferences.Load();

						if (lastmodified < Preferences.Me.LastFileCheck &&
						    !forceDownload)
                        {
                            return result.ToArray();

                        } // No new info to download
                        
                    } // TryParse
                    
                } // Last updated node not null

				Preferences.Me.LastFileCheck = DateTime.Now.ToUniversalTime();
                Preferences.Save();

				var files = (
					from x in xdoc.Root.Elements("file")
					select x.Value
				);

				foreach (string fn in files)
				{
					string webfile = GetAppFile(AppFile.FilesFolder_Remote) + fn;
					string localfile = Path.Combine(
						GetAppFile(AppFile.FilesFolder_Local),
						fn
					);
					HttpClient hc = new HttpClient();
					hc.DownloadComplete += (o, e) =>
					{
						result.Add(
							Path.Combine(
								GetAppFile(AppFile.FilesFolder_Local),
								fn
							)
						);

					};

					try
					{
						hc.DownloadFile(webfile, localfile);

					}
					catch (Exception ex)
					{
                        LogCenter.Error(
                            string.Format(
                                "DownloadFile({0})",
                                webfile
                                ),
                            ex.Message
                            );

					} // catch

				} // foreach file


				while (HttpClient.ActiveDownloads > 0)
				{
				}

			}
			catch (Exception ex)
			{
                LogCenter.Error(
                    "DownloadFiles()",
                    ex.Message
                    );
				
			}

			return result.ToArray();

		}
        */

        public static async Task SignIn(string usr, string pw)
        {
            try
            {
                AccountClient cli = new AccountClient();
                {
                    AuthenticateResponse res = await cli.AuthenticateAsync(usr, pw);

#warning Check this up.
                    /*
                    if (res == null)
                    {
                        throw new Exception(string.Format("Unable to sign in. Service version is {0}.",
                            cli.Version()
                            ));

                    } // Response is null
                    */

                    if (res.Error == null)
                    {
                        Preferences.Me.Email = usr;
                        Preferences.Me.Password = pw;
                        Preferences.Save();

                        token = res.Token;

                    } // Ok
                    else
                    {
                        throw new Exception(res.Error.Message);
                    } // Error

                } // using

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("Error occured when signing in: {0}".Translate(),
                    ex.Message
                    );
            }
        }

        public static async Task DownloadInfrastructure(DownloadInfrastructureArgs args)
        {
            try
            {
                KWENDARestClient cli = new KWENDARestClient();
                {
                    ListKWENDAFilesRequest req = new ListKWENDAFilesRequest();
                    cli.AccountToken = ""; // List all files
                    req.NewerThan = args.NewerThan;

                    ListKWENDAFilesResponse resp = await cli.ListFiles(req);
                    Cli_ListKwendaFilesCompleted(args, resp);

                    

                } // using

            }
            catch (Exception ex)
            {
                string errmsg = $"{AppMessages.KWERR_DownloadInfrastructureError_Msg}: {ex.Message}";
                LogCenter.Error("DownloadInfrastructure()", errmsg);
                if (args.AlertWhenComplete != null)
                {
                    args.AlertWhenComplete(
                        AppMessages.KWERR_DownloadInfrastructureError,
                        errmsg
                        );

                } // alertMe


            }

        }

        private static async Task Cli_ListKwendaFilesCompleted(DownloadInfrastructureArgs args, ListKWENDAFilesResponse resp)
        {
            try
            {
                List<KWENDAFileId> fids = new List<KWENDAFileId>();

                // Grab missing or newer files.
                KWENDAFileItem[] files = resp.Files;

            // If we don't get an exception above, it's safe to clear the cache.
            if (args.ClearCache)
            {
                GraphController.Me.ClearLocalData(
                    GetAppFile(AppFile.FilesFolder_Local)
                    );
                VenueController.Me.ClearLocalData(
                    GetAppFile(AppFile.FilesFolder_Local)
                    );

                } // Clear cache

                foreach (var f in resp.Files)
                {
                    string localfile = Path.Combine(
                        GetAppFile(AppFile.FilesFolder_Local),
                        f.FileName
                        );

                    if (File.Exists(localfile))
                    {
                        DateTime fdate = File.GetLastWriteTimeUtc(localfile);
                        if (f.LastModified <= fdate)
                        {
                            continue;

                        } // Local is newer or same

                    } // Local file exists

                    KWENDAFileId fid = new KWENDAFileId();
                    fid.FileName = f.FileName;
                    fid.VenueId = f.VenueId;
                    
                    fids.Add(fid);

                } // foreach

                KWENDARestClient cli = new KWENDARestClient();
                {
                    GetKWENDAFilesRequest req = new GetKWENDAFilesRequest
                        ();
                    cli.AccountToken = ""; // Get anonymously
                    req.FileIds = fids.ToArray();

                    GetKWENDAFilesResponse filesresp = await cli.GetFiles(req);
                    Cli_GetKwendafilesCompleted(filesresp, args);
                } // using service

                Preferences.Me.LastFileCheck = DateTime.Now.AddSeconds(-30);
                Preferences.Save();

                BeaconController.Me.Clear();

            }
            catch (Exception ex)
            {
                string errmsg = $"{AppMessages.KWERR_ListFilesError_Msg}";
                LogCenter.Error("ListKwendaFilesCompleted", ex.Message);
                if (args.AlertWhenComplete != null)
                {
                    if (!CheckIfHostReachable())
                    {
                        args.AlertWhenComplete(
                            AppMessages.KWERR_HostUnreachable,
                            string.Format(AppMessages.KWERR_HostUnreachable_Msg, GetAppFile(AppFile.ServicesMawinguHost))
                            );

                    }
                    else
                    {
                        args.AlertWhenComplete(
                        AppMessages.KWERR_ListFilesError,
                        errmsg
                        );

                    } // else





                    } // alertMe

            }
        }

        private static void Cli_GetKwendafilesCompleted(GetKWENDAFilesResponse resp, DownloadInfrastructureArgs args)
        {
            try
            {
                string folder = GetAppFile(AppFile.FilesFolder_Local);

                foreach (var f in resp.Files)
                {
                    string localfile = Path.Combine(
                        folder,
                        f.FileName
                        );

                    // Embedded data
                    if (f.Data != null &&
                        f.Data.Length > 0)
                    {
                        try
                        {
                            File.WriteAllBytes(
                                localfile,
                                f.Data
                                );

                            FileInfo fi = new FileInfo(localfile);
                            fi.LastWriteTimeUtc = f.LastModified.Value.ToUniversalTime();

                        }
                        catch (Exception fwex)
                        {
                            LogCenter.Error(string.Format("WriteAllBytes({0})",
                                f.FileName
                                ), fwex.Message
                                );

                        } // catch

                    } // f.Data not empty
                    else // Grab via http
                    {
                        string webfile = GetAppFile(AppFile.FilesFolder_Remote);
                        webfile = Path.Combine(webfile, f.VenueId, f.FileName);
                        
                        HttpClient hc = new HttpClient();

                        hc.DownloadComplete += (o, e2) =>
                        {
                            // Do nothing

                        };
                        hc.DownloadError += (sndr, errargs) =>
                        {
                            LogCenter.Error("DownloadError", hc.Url);

                        };


                        try
                        {
                            hc.DownloadFile(webfile, localfile, f.LastModified);

                        }
                        catch (Exception wex)
                        {
                            LogCenter.Error(
                                string.Format(
                                    "DownloadFile({0})",
                                    webfile
                                    ),
                                wex.Message
                                );

                        } // catch

                    } // Get via http

                } // foreach file
                
                if (resp.Files.Any())
        {
                    LoadInfrastructure(
                        args.AlertWhenComplete
#if __IOS__
                        ,args.ViewController
#endif
                        );

                } // New files downloaded
                else if (args.AlertWhenComplete != null)
                {
                    args.AlertWhenComplete(AppMessages.KWERR_OK, string.Empty);

                } // alertMe

                BeaconController.Me.StartMonitoringWaypointType("entrance");

            }
            catch (Exception ex)
            {
                string errmsg = $"{AppMessages.KWERR_GetKwendaFilesError_Msg}: {ex.Message}";
                LogCenter.Error("GetKwendafilesCompleted", errmsg);
                if (args.AlertWhenComplete != null)
                {
                    args.AlertWhenComplete(
                        AppMessages.KWERR_GetKwendaFilesError,
                        errmsg
                        );

                } // alertMe

            }

        }

        public static bool CheckIfHostReachable()
        {
            try
            {
                string url = GetAppFile(AppFile.PingOnServer);

                WebRequest request = WebRequest.Create(url);
                var response = request.GetResponse();
                try
                {
                    return true;

                }
                finally
                {
                    response.Close();

                }

            }
            catch
            {
                return false;

            }

        }

        public static void LoadInfrastructure(
            DownloadCompleteAction alertWhenComplete
#if __IOS__
            , UIViewController viewController
#elif __ANDROID__
            , Context viewController
#endif
            )
        {
            if (loadingdata)
            {
                return;

            } // Loading data guard
            

            try
            {
                loadingdata = true;

                string[] olduuids = BeaconController.Me.Uuids;

                VenueController.Me.AddFromFolder(
                    GetAppFile(AppFile.FilesFolder_Local),
                    false
                );
                GraphController.Me.AddFromVenues(VenueController.Me.Venues, true);
                GraphController.Me.BuildNodeCache();
                
                foreach (WFGraph g in GraphController.Me.Graphs)
                {
                    BeaconController.Me.AddUuids(
                        g.GetUuids()
                        );

                } // foreach graph
                try
                
                {
                    //tmp BeaconController.Me.Clear(true);

                }
                catch
                {
                }

                try
                {
                    BeaconController.Me.StopRangingBeacons(olduuids);

                }
                catch
                {
                }
                try
                {
                    if (!BeaconController.Me.StartRangingBeacons())
                    {
#if __IOS__
                        UIAlertController alert = UIAlertController.Create(
                                "Bluetooth Required".Translate(),
                                "Bluetooth must be turned on in order to detect beacons.".Translate(),
                                UIAlertControllerStyle.Alert
                            );
                        alert.AddAction(UIAlertAction.Create(
                            "Dismiss".Translate(),
                            UIAlertActionStyle.Default,
                            (obj) => { }
                        ));

                        if (viewController != null)
                        {
                            viewController.PresentViewController(alert, true, null);

                        } // Not null
#elif __ANDROID__
#warning Make toast here
#endif
                    }

                }
                catch (Exception liex)
                {
                    string errmsg = $"{AppMessages.KWERR_LoadInfrastructureError_Msg}: {liex.Message}";
                    LogCenter.Error("LoadInfrastructure", errmsg);
                }
                if (alertWhenComplete != null)
                {
                    alertWhenComplete(AppMessages.KWERR_OK, string.Empty); ;

                } // alertMe
                
            }
            catch (Exception ex)
            {
                LogCenter.Error(
                    "LoadInfrastructure()",
                    ex.Message
                    );

            }
            finally
            {
                loadingdata = false;

            }

        }


    } // class


    public delegate void DownloadCompleteAction(int errorCode, string errorMessage);

    public class DownloadInfrastructureArgs
    {
        public DownloadCompleteAction AlertWhenComplete { get; set; }
        public bool ClearCache { get; set; }
        public DateTime? NewerThan { get; set; }
        public bool ForceDownload { get; set; }
#if __IOS__
        public UIViewController ViewController { get; set; }
#elif __ANDROID__
        public Context ViewController { get; set; }
#endif

    } // class


}
