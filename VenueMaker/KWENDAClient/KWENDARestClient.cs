using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using KWENDA.DTO;
using KWENDA.Helpers;
using MAWINGU.Authentication;
using Newtonsoft.Json;

namespace KWENDA
{
    public class KWENDARestClient
    {
        private static HttpClient _client = new HttpClient();

        private const string ServiceInfoPath = "api/v1/KWENDA/serviceinfo";
        private const string SignupPath = "api/v1/KWENDA/signup";
        private const string SignInPath = "api/v1/KWENDA/signin";
        private const string ListFilesPath = "api/v1/KWENDA/listfiles";
        private const string GetFilesPath = "api/v1/KWENDA/getfiles";
        private const string UpdateFilesPath = "api/v1/KWENDA/updatefiles";
        private const string SetPermissionsPath = "api/v1/KWENDA/setpermissions";




        public const string Local_BaseAddress = "https://localhost";
        public const int Local_BasePort = 44320;
        public const string StandardBaseUrl = "https://kwenda.services.mawingu.se";

        public string BaseAddress { get; set; }
        public int? Port { get; set; }


        public string AccountToken { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string OnBehalfOf { get; set; }
        public string ClientName { get; set; }

        public event EventHandler<KWENDAClientStatusEventArgs> OnStatus;


        public KWENDARestClient()
            : this(StandardBaseUrl, null)
            //: this(Local_BaseAddress, Local_BasePort)
        {
        }

        public KWENDARestClient(string baseUrl, int? thePort)
        {
            BaseAddress = baseUrl;
            Port = thePort;

            ClientName = "Default";

            RefreshHeaders();

        }
        
        private void RefreshHeaders()
        {
            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/problem+json"));

            if (!string.IsNullOrWhiteSpace(Token))
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
            }
            else if (!string.IsNullOrWhiteSpace(AccountToken))
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccountToken);
            }

        }

        private string AddOnBehalfOfToQuery(string queryString)
        {
            var query = HttpUtility.ParseQueryString(queryString);

            if (!string.IsNullOrWhiteSpace(this.OnBehalfOf))
            {
                query["email"] = OnBehalfOf;

            } // AppId

            return query.ToString();

        }

        public async Task<ServiceInfo> GetServiceInfo()
        {
            try
            {
                RefreshHeaders();

                UriBuilder builder = new UriBuilder($"{BaseAddress}:{Port}/");
                builder.Path = ServiceInfoPath;
                
                OnStatus?.Invoke(this, new KWENDAClientStatusEventArgs("Signing up..."));

                HttpResponseMessage response = await _client.GetAsync(builder.ToString());
                if (response.IsSuccessStatusCode)
                {
                    ServiceInfo res = await response.Content.ReadAsAsync<ServiceInfo>();
                    return res;
                }

                throw new Exception(response.ReasonPhrase);

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }


        public async Task<MAWINGU.Authentication.DTO.AuthenticateResponse> SignInToAccount()
        {
            AccountClient ac = new AccountClient();
            this.OnStatus?.Invoke(this, new KWENDAClientStatusEventArgs("Signing in..."));

            MAWINGU.Authentication.DTO.AuthenticateResponse ar = await ac.AuthenticateAsync(
                UserName,
                Password
                );

            AccountToken = ar.Token;

            return ar;

        }

        public async Task<WebAPIError> SignUp(string eMail)
        {
            try
            {
                RefreshHeaders();

                UriBuilder builder = new UriBuilder($"{BaseAddress}:{Port}/");
                builder.Path = SignupPath;
                if (string.IsNullOrEmpty(eMail))
                {
                    throw new Exception("E-post får inte vara tomt.");

                } // Is null

                builder.Query = eMail.AsQueryString("email");

                OnStatus?.Invoke(this, new KWENDAClientStatusEventArgs("Signing up..."));

                HttpResponseMessage response = await _client.GetAsync(builder.ToString());
                if (response.IsSuccessStatusCode)
                {
                    WebAPIError res = await response.Content.ReadAsAsync<WebAPIError>();
                    return res;
                }

                throw new Exception(response.ReasonPhrase);

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<SignInResponse> SignIn(string eMail)
        {
            try
            {
                RefreshHeaders();

                UriBuilder builder = new UriBuilder($"{BaseAddress}:{Port}/");
                builder.Path = SignInPath;
                SignInRequest request = new SignInRequest()
                {
                    Email = eMail,
                    Client = ClientName
                };

                OnStatus?.Invoke(this, new KWENDAClientStatusEventArgs("Signing in..."));
                HttpResponseMessage response = await _client.PostAsJsonAsync<SignInRequest>(builder.ToString(), request);

                SignInResponse result = null;

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<SignInResponse>();

                    Token = result.Token;
                    RefreshHeaders();
                    
                    return result;

                } // Success

                HandleStandardErrors(response);

                WebAPIError err = null;
                string errstr = response.Content.ReadAsStringAsync().Result;
                try
                {
                    err = JsonConvert.DeserializeObject<WebAPIError>(errstr);

                }
                catch
                {

                    err = new WebAPIError();
                    err.Message = errstr;
                }

                result = new SignInResponse();
                result.Error = err;
                return result;
                //throw new Exception($"Felkod {err.Code}: {err.Message}");


            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<ListKWENDAFilesResponse> ListFiles(ListKWENDAFilesRequest req)
        {
            try
            {
                RefreshHeaders();

                UriBuilder builder = new UriBuilder($"{BaseAddress}:{Port}/");
                builder.Path = ListFilesPath;
                
                builder.Query = AddOnBehalfOfToQuery(builder.Query);

                OnStatus?.Invoke(this, new KWENDAClientStatusEventArgs("Getting list of files..."));

                HttpResponseMessage response = await _client.PostAsJsonAsync(builder.ToString(), req);
                if (response.IsSuccessStatusCode)
                {
                    ListKWENDAFilesResponse resp = await response.Content.ReadAsAsync<ListKWENDAFilesResponse>();
                    return resp;

                } // Success

                HandleStandardErrors(response);


                WebAPIError err = null;
                string errstr = response.Content.ReadAsStringAsync().Result;
                try
                {
                    err = JsonConvert.DeserializeObject<WebAPIError>(errstr);

                }
                catch (Exception cex)
                {
                    err = new WebAPIError();
                    err.Message = cex.Message;
                }

                throw new Exception($"Felkod {err.Code}: {err.Title} ({err.Message})");

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<GetKWENDAFilesResponse> GetFiles(GetKWENDAFilesRequest req)
        {
            try
            {
                RefreshHeaders();

                UriBuilder builder = new UriBuilder($"{BaseAddress}:{Port}/");
                builder.Path = GetFilesPath;
                builder.Query = AddOnBehalfOfToQuery(builder.Query);

                //OnStatus?.Invoke(this, new BucketClientStatusEventArgs($"Uploading file {doc.FileName}"));

                HttpResponseMessage response = await _client.PostAsJsonAsync(builder.ToString(), req);
                if (response.IsSuccessStatusCode)
                {
                    GetKWENDAFilesResponse resp = await response.Content.ReadAsAsync<GetKWENDAFilesResponse>();
                    return resp;

                }

                WebAPIError err = null;
                string errstr = response.Content.ReadAsStringAsync().Result;
                try
                {
                    err = JsonConvert.DeserializeObject<WebAPIError>(errstr);

                }
                catch (Exception cex)
                {
                    err = new WebAPIError();
                    err.Message = cex.Message;
                }

                throw new Exception($"Felkod {err.Code}: {err.Title} ({err.Message})");

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<UpdateKWENDAFilesResponse> UpdateFiles(UpdateKWENDAFilesRequest req)
        {
            try
            {
                RefreshHeaders();

                UriBuilder builder = new UriBuilder($"{BaseAddress}:{Port}/");
                builder.Path = UpdateFilesPath;
                builder.Query = AddOnBehalfOfToQuery(builder.Query);

                //OnStatus?.Invoke(this, new BucketClientStatusEventArgs($"Updating file {doc.FileName}"));

                HttpResponseMessage response = await _client.PostAsJsonAsync(builder.ToString(), req);
                if (response.IsSuccessStatusCode)
                {
                    UpdateKWENDAFilesResponse resp = await response.Content.ReadAsAsync<UpdateKWENDAFilesResponse>();
                    return resp;

                }

                WebAPIError err = null;
                string errstr = response.Content.ReadAsStringAsync().Result;
                try
                {
                    err = JsonConvert.DeserializeObject<WebAPIError>(errstr);

                }
                catch (Exception cex)
                {
                    err = new WebAPIError();
                    err.Message = cex.Message;
                }

                throw new Exception($"Felkod {err.Code}: {err.Message}");

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<SetKWENDAFilePermissionsResponse> SetPermissions(SetKWENDAFilePermissionsRequest req)
        {
            try
            {
                if (req == null)
                {
                    throw new ArgumentNullException("Kan inte ta bort ett dokument som är null.");

                } // Null

                RefreshHeaders();

                UriBuilder builder = new UriBuilder($"{BaseAddress}:{Port}/");
                builder.Path = SetPermissionsPath;

                //OnStatus?.Invoke(this, new BucketClientStatusEventArgs($"Deleting file {doc.FileName}"));

                HttpResponseMessage response = await _client.PostAsJsonAsync(builder.ToString(), req);
                if (response.IsSuccessStatusCode)
                {
                    SetKWENDAFilePermissionsResponse  resp = await response.Content.ReadAsAsync<SetKWENDAFilePermissionsResponse>();
                    return resp;

                }

                WebAPIError err = null;
                string errstr = response.Content.ReadAsStringAsync().Result;
                try
                {
                    err = JsonConvert.DeserializeObject<WebAPIError>(errstr);

                }
                catch (Exception cex)
                {
                    err = new WebAPIError();
                    err.Message = cex.Message;
                }
                throw new Exception($"Felkod {err.Code}: {err.Title} ({err.Message})");



            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public void HandleStandardErrors(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    throw new Exception("Behörighet saknas.");

            } // switch

        }



    } // class


}