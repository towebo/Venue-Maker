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

        private KWENDARestClient cli;



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
        public KWENDARestClient Client
        {
            get { return cli; }
        }

        public string RemoteFileUrl
        {
            get
            {
                string url = Client.BaseAddress
                    .AddToUrl("data");
                return url;
            }
        }


        public DataController()
        {
            cli = new KWENDARestClient();
        }

        public async Task<KWENDAFileItem[]> ListFiles()
        {
            try
            {
                ListKWENDAFilesRequest req = new ListKWENDAFilesRequest();
                ListKWENDAFilesResponse result = await Client.ListFiles(req);

                if (result.Error != null)
                {
                    throw new Exception(result.Error.Message);

                } // Got an error

                return result.Files;

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("ListFiles: {0}",
                    ex.Message
                    );
                throw new Exception(errmsg);

            }
        }

        public async Task<KWENDAFileItem> GetKwendaFile(KWENDAFileId fid)
        {
            try
            {
                GetKWENDAFilesRequest req = new GetKWENDAFilesRequest();
                req.FileIds = new KWENDAFileId[] { fid };

                GetKWENDAFilesResponse resp = await Client.GetFiles(req);

                if (resp.Error != null)
                {
                    throw new Exception(resp.Error.Message);

                } // Got an error

                return resp.Files.FirstOrDefault();

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("GetKWENDAFile: {0}",
                    ex.Message
                    );
                throw new Exception(errmsg);

            }
        }

        public async Task SetPermissions(PermissionItem[] permissionItems)
        {
            try
            {
                SetKWENDAFilePermissionsRequest req = new SetKWENDAFilePermissionsRequest();
                req.Items = permissionItems;

                SetKWENDAFilePermissionsResponse result = await Client.SetPermissions(req);

                if (result.Error != null)
                {
                    throw new Exception(result.Error.Message);

                } // Error

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("Sätt rättigheter: {0}",
                    ex.Message
                    );
                throw new Exception(errmsg);

            }
        }

        public async Task UpdateKwendaFiles(KWENDAFileItem[] items)
        {
            try
            {
                UpdateKWENDAFilesRequest req = new UpdateKWENDAFilesRequest();
                req.InactivateAllForVenue = true;
                req.Files = items;

                UpdateKWENDAFilesResponse response = await Client.UpdateFiles(req);

                if (response.Error != null)
                {
                    throw new Exception(response.Error.Message);

                } // Ok

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("Uppdatera fil: {0}",
                    ex.Message
                    );
                throw new Exception(errmsg);

            }
        }

        public bool IsTokenValid()
        {
            try
            {
                return !string.IsNullOrWhiteSpace(Token);
                
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
                AuthenticateResponse res = await cli.AuthenticateAsync(Email, Password);

                if (res.Error == null)
                {
                    Client.AccountToken = res.Token;
                    SignInResponse signin_res = await Client.SignIn(Email);
                    if (signin_res.Error == null)
                    {
                        Token = signin_res.Token;
                        return true;

                    } // Null

                    WebAPIError signupres = await Client.SignUp(Email);

                    signin_res = await Client.SignIn(Email);
                    if (signin_res.Error == null)
                    {
                        Token = signin_res.Token;
                        return true;

                    } // Null

                    return false;

                } // Ok
                else
                {
                    return false;
                } // Unlucky

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


        public async Task<string> ServiceVersion()
        {
            try
            {
                ServiceInfo info = await Client.GetServiceInfo();
                return info.Version;

            }
            catch
            {
                throw;

            }

        }



    } // class

}