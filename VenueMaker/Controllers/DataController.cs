using Mawingu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VenueMaker.Kwenda;

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
            // Make sure we use a newer version of SSL.
            // https://stackoverflow.com/questions/6232746/c-sharp-httpwebrequest-sec-i-renegotiate-intermittent-errors
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        }


        public KwendaFileListItem[] ListFiles(string token)
        {
            try
            {
                using (KwendaService cli = new KwendaService())
                {
                    ListKwendaFilesRequest req = new ListKwendaFilesRequest();
                    req.Token = token;

                    ListKwendaFilesResponse result = cli.ListKwendaFiles(req);

                    if (result.Result == ListKwendaFilesResponseMethodResult.OtherError)
                    {
                        throw new Exception(result.Message);

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

        public KwendaFileItem GetKwendaFile(string token, KwendaFileId fid)
        {
            try
            {
                using (KwendaService cli = new KwendaService())
                {
                    GetKwendaFileRequest req = new GetKwendaFileRequest();
                    req.Token = token;
                    req.FileIds = new KwendaFileId[] { fid };

                    GetKwendaFileResponse resp = cli.GetKwendafiles(req);

                    if (resp.Result == GetKwendaFileResponseMethodResult.OtherError)
                    {
                        throw new Exception(resp.Message);

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

        public void SetPermissions(string token, KwendaPermissionItem[] permissionItems)
        {
            try
            {
                using (KwendaService cli = new KwendaService())
                {
                    SetKwendaPermissionsRequest req = new SetKwendaPermissionsRequest();
                    req.Token = token;
                    req.Items = permissionItems;
                                        

                    SetKwendaPermissionsResponse result = cli.SetKwendaPermissions(req);

                    if (result.Result == SetKwendaPermissionsResponseMethodResult.Ok)
                    {
                        throw new Exception(result.Message);
                        
                    } // Ok
                    else if (result.Result == SetKwendaPermissionsResponseMethodResult.NoPermission)
                    {
                        throw new Exception("Du har inte rättighet att utföra denna åtgärd. Logga in med en användare med tillräckliga rättigheter och försök igen.");

                    } // No permissions
                    else if (result.Result == SetKwendaPermissionsResponseMethodResult.NotLoggedIn)
                    {
                        throw new Exception("Du är inte iloggad.");

                    } // Not logged in
                    else if (result.Result == SetKwendaPermissionsResponseMethodResult.OtherError)
                    {
                        throw new Exception(result.Message);


                    } // Ok
                                        

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

        public void UpdateKwendaFiles(string token, KwendaFileItem[] items)
        {
            try
            {
                using (KwendaService cli = new KwendaService())
                {
                    UpdateKwendaFileRequest req = new UpdateKwendaFileRequest();
                    req.Token = token;
                    req.InactivateAllForVenue = true;
                    req.InactivateAllForVenueSpecified = true;
                    req.Files = items;

                    UpdateKwendaFileResponse response = cli.UpdateKwendaFiles(req);
                                        
                    if (response.Result == UpdateKwendaFileResponseMethodResult.Ok)
                    {
                        return;

                    } // Ok
                    else if (response.Result == UpdateKwendaFileResponseMethodResult.NoPermission)
                    {
                        throw new Exception("Du har inte rättighet att utföra denna åtgärd. Logga in med en användare med tillräckliga rättigheter och försök igen.");

                    } // No permissions
                    else if (response.Result == UpdateKwendaFileResponseMethodResult.NotLoggedIn)
                    {
                        throw new Exception("Du är inte iloggad.");

                    } // Not logged in
                    else if (response.Result == UpdateKwendaFileResponseMethodResult.OtherError)
                    {
                        throw new Exception(response.Message);


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

        public bool IsTokenValid()
        {
            try
            {
                using (KwendaService cli = new KwendaService())
                {
                    ValidateTokenRequest req = new ValidateTokenRequest();
                    req.Email = Email;
                    req.Token = Token;

                    ValidateTokenResponse response = cli.ValidateToken(req);

                    switch (response.Result)
                    {
                        case ValidateTokenResponseMethodResult.Expired:
                            return false;

                        case ValidateTokenResponseMethodResult.Invalid:
                            return false;

                        case ValidateTokenResponseMethodResult.Ok:
                            return true;

                        case ValidateTokenResponseMethodResult.OtherError:
                            return false;

                        default:
                            return false;

                    } // switch

                } // using

            }
            catch (Exception ex)
            {
                LogCenter.Error("IsTokenValid", ex.Message);
                throw new Exception($"Fel uppstod i IsTokenValid: {ex.Message}");

            }

        }

        public bool AutoLogin()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Email) ||
                    string.IsNullOrWhiteSpace(Password))
                {
                    return false;

                } // Haven't logged in yet
                using (KwendaService cli = new KwendaService())
                {
                    LoginRequest req = new LoginRequest();
                    req.Email = Email;
                    req.Password = Password;
                    req.AppID = "se.mawingu.venuemaker";

                    LoginResponse res = cli.Login(req);

                    if (res.Result == LoginResponseMethodResult.Ok)
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

                using (KwendaService cli = new KwendaService())
                {
                    LogoutRequest req = new LogoutRequest();
                    req.Email = Email;
                    req.Token = Token;
                    bool result, resspecified;
                    cli.Logout(req, out result, out resspecified);

                    Password = string.Empty;
                    Token = string.Empty;

                    return result;
                    
                } // using


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
                using (KwendaService cli = new KwendaService())
                {
                    string result = cli.Version();

                    //throw new Exception("Artificiellt fel.");
                    return result;

                } // using

            }
            catch
            {
                throw;

            }

        }



    }
}
