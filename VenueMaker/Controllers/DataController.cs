using KWENDA;
using KWENDA.DTO;
using Mawingu;
using MAWINGU.Authentication;
using MAWINGU.Authentication.DTO;
using MAWINGU.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VenueMaker.Controllers
{
    public class DataController
    {
        private static DataController me;



        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public static DataController Me
        {
            get
            {
                if (me == null)
                {
                    me = new DataController();

                } // Is null
                return me;
            } // get
        } // Me

        public const string RemoteFileUrl = "https://services.mawingu.se/kwenda/data/";

        public DataController()
        {
        }


        public async Task<KWENDAFileItem[]> ListFiles(string token)
        {
            try
            {
                KWENDARestClient cli = new KWENDARestClient();
                {
                    ListKWENDAFilesRequest req = new ListKWENDAFilesRequest();

                    ListKWENDAFilesResponse result = await cli.ListFiles(req);

                    if (result.Error != null)
                    {
                        throw new Exception(result.Error.Message);

                    } // Got an error

                    return result.Files;                    

                } // using

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("Shit(): {0}",
                    ex.Message
                    );
                throw new Exception(errmsg);

            }
        }

        public async Task<KWENDAFileItem> GetKwendaFile(string token, KWENDAFileId fid)
        {
            try
            {
                KWENDARestClient cli = new KWENDARestClient();
                {
                    cli.AccountToken = token;
                    GetKWENDAFilesRequest req = new GetKWENDAFilesRequest();
                    req.FileIds = new KWENDAFileId[] { fid };

                    GetKWENDAFilesResponse resp = await cli.GetFiles(req);

                    if (resp.Error != null)
                    {
                        throw new Exception(resp.Error.Message);

                    } // Got an error

                    return resp.Files.FirstOrDefault();
                    
                } // using

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("Shit(): {0}",
                    ex.Message
                    );
                throw new Exception(errmsg);

            }
        }

        public async Task SetPermissions(string token, PermissionItem[] permissionItems)
        {
            try
            {
                KWENDARestClient cli = new KWENDARestClient();
                {
                    SetKWENDAFilePermissionsRequest req = new SetKWENDAFilePermissionsRequest();
                    cli.AccountToken = token;
                    req.Items = permissionItems;
                                        
                    SetKWENDAFilePermissionsResponse result = await cli.SetPermissions(req);

                    if (result.Error != null)
                    {
                        throw new Exception(result.Error.Message);
                        
                    } // Error
                              
                } // using
            
            }
            catch (Exception ex)
            {
                string errmsg = string.Format("Sätt rättigheter: {0}",
                    ex.Message
                    );
                throw new Exception(errmsg);

            }
        }

        public async Task UpdateKwendaFiles(string token, KWENDAFileItem[] items)
        {
            try
            {
                KWENDARestClient cli = new KWENDARestClient();
                {
                    UpdateKWENDAFilesRequest req = new UpdateKWENDAFilesRequest();
                    cli.AccountToken = token;
                    req.InactivateAllForVenue = true;
                    req.Files = items;

                    UpdateKWENDAFilesResponse response = await cli.UpdateFiles(req);
                                        
                    if (response.Error != null)
                    {
                        throw new Exception(response.Error.Message);

                    } // Ok
                    } // using

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("Uppdatera fil: {0}",
                    ex.Message
                    );
                throw new Exception(errmsg);

            }
        }

        public async Task<bool> IsTokenValid()
        {
            try
            {
                return true;
                

            }
            catch (Exception ex)
            {
                LogCenter.Error("IsTokenValid", ex.Message);
                throw new Exception($"Fel uppstod i IsTokenValid: {ex.Message}");

            }

        }

        public async Task<bool> AutoLogin()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Email) ||
                    string.IsNullOrWhiteSpace(Password))
                {
                    return false;

                } // Haven't logged in yet
                AccountClient cli = new AccountClient();
                {
                    AuthenticateResponse res = await cli.AuthenticateAsync(Email, Password);
                    
                    if (res.Error == null)
                    {
                        Token = res.Token;
                        return true;
                    } // Ok
                    else
                    {
                        return false;
                    } // Unlucky

                } // using


            }
            catch (Exception ex)
            {
                string errmsg = $"Det gick inte att logga in automatiskt med e-postadressen {Email} och det angivna lösenordet. {ex.Message}";
                throw new Exception(errmsg);

            }
        }

        public bool LogOut()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Email) ||
                    string.IsNullOrWhiteSpace(Password))
                {
                    return true;

                } // Haven't logged in yet

                Token = string.Empty;
                return true;

            }
            catch (Exception ex)
            {
                string errmsg = $"Det gick inte att logga in automatiskt med e-postadressen {Email} och det angivna lösenordet. {ex.Message}";
                throw new Exception(errmsg);

            }
        }


        public string ServiceVersion()
        {
            try
            {
#warning This isn't implemented in the service.
                return "Not Implemented";
                /*
                using (KwendaService cli = new KwendaService())
                {
                    string result = cli.Version();

                    //throw new Exception("Artificiellt fel.");
                    return result;

                } // using
                */
            }
            catch
            {
                throw;

            }

        }



    } // class

}