using System;
using System.Collections.Generic;
using System.Linq;
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




        public KwendaFileListItem[] ListFiles(string token)
        {
            try
            {
                using (KwendaServiceClient cli = new KwendaServiceClient())
                {
                    ListKwendaFilesRequest req = new ListKwendaFilesRequest();
                    req.Token = token;

                    ListKwendaFilesResponse result = cli.ListKwendaFiles(req);

                    if (result.Result == ListKwendaFilesResponse.MethodResult.OtherError)
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

        public void SetPermissions(string token, KwendaPermissionItem[] permissionItems)
        {
            try
            {
                using (KwendaServiceClient cli = new KwendaServiceClient())
                {
                    SetKwendaPermissionsRequest req = new SetKwendaPermissionsRequest();
                    req.Token = token;
                    req.Items = permissionItems;
                                        

                    SetKwendaPermissionsResult result = cli.SetKwendaPermissions(req);

                    if (result.Result == SetKwendaPermissionsResult.MethodResult.Ok)
                    {
                        throw new Exception(result.Message);
                        return;

                    } // Ok
                    else if (result.Result == SetKwendaPermissionsResult.MethodResult.NoPermission)
                    {
                        throw new Exception("Du har inte rättighet att utföra denna åtgärd. Logga in med en användare med tillräckliga rättigheter och försök igen.");

                    } // No permissions
                    else if (result.Result == SetKwendaPermissionsResult.MethodResult.NotLoggedIn)
                    {
                        throw new Exception("Du är inte iloggad.");

                    } // Not logged in
                    else if (result.Result == SetKwendaPermissionsResult.MethodResult.OtherError)
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
                using (KwendaServiceClient cli = new KwendaServiceClient())
                {
                    UpdateKwendaFileRequest req = new UpdateKwendaFileRequest();
                    req.Token = token;
                    req.InactivateAllForVenue = true;
                    req.Files = items;

                    UpdateKwendaFileResponse response = cli.UpdateKwendaFiles(req);
                                        
                    if (response.Result == UpdateKwendaFileResponse.MethodResult.Ok)
                    {
                        throw new Exception(response.Message);
                        //return;

                    } // Ok
                    else if (response.Result == UpdateKwendaFileResponse.MethodResult.NoPermission)
                    {
                        throw new Exception("Du har inte rättighet att utföra denna åtgärd. Logga in med en användare med tillräckliga rättigheter och försök igen.");

                    } // No permissions
                    else if (response.Result == UpdateKwendaFileResponse.MethodResult.NotLoggedIn)
                    {
                        throw new Exception("Du är inte iloggad.");

                    } // Not logged in
                    else if (response.Result == UpdateKwendaFileResponse.MethodResult.OtherError)
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




    }
}
