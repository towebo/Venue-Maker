// install-package Microsoft.AspNet.WebApi.Client
// install-package Newtonsoft.Json

using MAWINGU.Authentication.DTO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MAWINGU.Authentication
{
    public class AccountClient
    {
        private static HttpClient client = new HttpClient();

        private const string AuthenticatePath = "api/account/authenticate";
        private const string CreateAccountPath = "api/Account";
        private const string RequestVerificationPath = "api/account/requestverificationcode";
        private const string VerifyAccountPath = "api/account/verifyaccount";
        private const string ChangePasswordPath = "api/account/changepw";

        public string BaseAddress { get; set; }
        public int? Port { get; set; }

        public string Token { get; set; }

        public string BaseUrl
        {
            get
            {
                StringBuilder result = new StringBuilder(BaseAddress);
                
                if (Port.HasValue)
                {
                    if (BaseAddress.EndsWith("/"))
                    {
                        result.Remove(result.Length - 1, 1);

                    } // Remove ending slash

                    result.Append($":{Port}/");

                } // Has Port

                return result.ToString();
            }
        }


        public AccountClient()
            : this("https://account.services.mawingu.se/", null)
        {
        }

        public AccountClient(string baseAddr, int? httpPort)
        {
            this.BaseAddress = baseAddr;
            this.Port = httpPort;

        }

        private void RefreshHeaders()
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrWhiteSpace(Token))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

            } // Authorized

        }

        public async Task<AuthenticateResponse> AuthenticateAsync(string eMail, string pw)
        {
            try
            {
                RefreshHeaders();

                UriBuilder builder = new UriBuilder(BaseUrl);
                builder.Path = AuthenticatePath;
                AuthenticateRequest req = new AuthenticateRequest
                {
                    Email = eMail,
                    Password = pw
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(builder.ToString(), req);

                AuthenticateResponse result;

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<AuthenticateResponse>();
                    this.Token = result.Token;
                    RefreshHeaders();
                    return result;

                } // Success

                string errstr = response.Content.ReadAsStringAsync().Result;
                ErrorResponse err = JsonConvert.DeserializeObject<ErrorResponse>(errstr);
                
                result = new AuthenticateResponse();
                result.Error = err;
                return result;

                //throw new Exception($"{err.title}: {err.Message}");

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<bool> CreateAccountAsync(string eMail, string pw)
        {
            try
            {
                RefreshHeaders();

                UriBuilder builder = new UriBuilder(BaseUrl);
                builder.Path = CreateAccountPath;

                Account a = new Account
                {
                    Email = eMail,
                    Password = pw
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(builder.ToString(), a);
                if (response.IsSuccessStatusCode)
                {
                    return true;

                } // Success

                string errstr = response.Content.ReadAsStringAsync().Result;
                ErrorResponse err = JsonConvert.DeserializeObject<ErrorResponse>(errstr);

                throw new Exception($"Felkod {err.Code}: {err.Message} ({response.ReasonPhrase})");

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<bool> RequestVerificationAsync(string eMail)
        {
            try
            {
                RefreshHeaders();

                UriBuilder builder = new UriBuilder(BaseUrl);
                builder.Path = RequestVerificationPath;
                var query = HttpUtility.ParseQueryString(builder.Query);
                if (!string.IsNullOrWhiteSpace(eMail))
                {
                    query["email"] = eMail;
                    builder.Query = query.ToString();

                } // Email provided


                HttpResponseMessage response = await client.GetAsync(builder.ToString());
                if (response.IsSuccessStatusCode)
                {
                    return true;

                }

                string errstr = response.Content.ReadAsStringAsync().Result;
                ErrorResponse err = JsonConvert.DeserializeObject<ErrorResponse>(errstr);

                throw new Exception($"{err.Message}");

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<bool> VerifyAccountAsync(string eMail, int code)
        {
            try
            {
                RefreshHeaders();

                UriBuilder builder = new UriBuilder(BaseUrl);
                builder.Path = VerifyAccountPath;

                VerifyAccountRequest request = new VerifyAccountRequest
                {
                    Email = eMail,
                    Code = code
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(builder.ToString(), request);
                if (response.IsSuccessStatusCode)
                {
                    return true;

                } // Success

                string errstr = response.Content.ReadAsStringAsync().Result;
                ErrorResponse err = JsonConvert.DeserializeObject<ErrorResponse>(errstr);

                throw new Exception($"{err.Message}");

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<bool> ChangePasswordAsync(string eMail, string newPassword, int code)
        {
            try
            {
                RefreshHeaders();

                UriBuilder builder = new UriBuilder(BaseUrl);
                builder.Path = ChangePasswordPath;

                PasswordChangeRequest request = new PasswordChangeRequest
                {
                    Email = eMail,
                    NewPassword = newPassword,
                    Code = code.ToString()
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(builder.ToString(), request);
                if (response.IsSuccessStatusCode)
                {
                    return true;

                } // Success

                string errstr = response.Content.ReadAsStringAsync().Result;
                ErrorResponse err = JsonConvert.DeserializeObject<ErrorResponse>(errstr);

                throw new Exception($"{err.Message}");

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }


    }


}
