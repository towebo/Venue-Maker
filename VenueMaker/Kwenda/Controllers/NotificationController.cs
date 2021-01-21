using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kwenda.Controllers
{
    public class NotificationController
    {


        public static async Task<string> SendNativeNotificationREST(string message, string nativeType)
        {
            var connectionSaSUtil = new ConnectionStringUtility(
                Kwenda.Common.Models.Constants.FullAccessConnectionString
                );
            string location = null;

            var hubResource = "messages/?";
            var apiVersion = "api-version=2015-04";
            var notificationId = "Failed to get Notification Id";

            //=== Generate SaS Security Token for Authentication header ===
            // Determine the targetUri that we will sign
            var uri = connectionSaSUtil.Endpoint + Common.Models.Constants.NotificationHubName + "/" + hubResource + apiVersion;

            // 10 min expiration
            var sasToken = connectionSaSUtil.GetSaSToken(uri, 10);

            WebHeaderCollection headers = new WebHeaderCollection();
            string body;
            HttpWebResponse response = null;

            switch (nativeType.ToLower())
            {
                case "apns":
                    headers.Add("ServiceBusNotification-Format", "apple");
                    body = "{\"aps\":{\"alert\":\"" + message + "\"}}";
                    response = await ExecuteREST("POST", uri, sasToken, headers, body);
                    break;

                case "template":
                    headers.Add("ServiceBusNotification-Format", "template");
                    body = "{\"message\":\"" + message + "\"}";
                    response = await ExecuteREST("POST", uri, sasToken, headers, body);
                    break;

                case "gcm":
                    headers.Add("ServiceBusNotification-Format", "gcm");
                    body = "{\"data\":{\"message\":\"" + message + "\"}}";
                    response = await ExecuteREST("POST", uri, sasToken, headers, body);
                    break;

                case "wns":
                    headers.Add("X-WNS-Type", "wns/toast");
                    headers.Add("ServiceBusNotification-Format", "windows");
                    body = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                            "<toast>" +
                                "<visual>" +
                                    "<binding template=\"ToastText01\">" +
                                        "<text id=\"1\">" +
                                            message +
                                        "</text>" +
                                    "</binding>" +
                                "</visual>" +
                            "</toast>";
                    response = await ExecuteREST("POST", uri, sasToken, headers, body, "application/xml");
                    break;
            }

            char[] seps1 = { '?' };
            char[] seps2 = { '/' };

            if (response == null)
            {
                return "Didn't get any response.";
            }

            if (response != null && response.StatusCode != HttpStatusCode.Created)
            {
                return string.Format("Failed to get notification message id - Http Status {0} : {1}", (int)response.StatusCode, response.StatusCode.ToString());
            }

            if ((location = response.Headers.Get("Location")) != null)
            {
                var locationUrl = location.Split(seps1);
                var locationParts = locationUrl[0].Split(seps2);

                notificationId = locationParts[locationParts.Length - 1];

                return notificationId;
            }

            return null;
        }
                
        public static async Task<string> SendTemplateNotificationREST(Dictionary<string, object> messageParams)
        {
            var connectionSaSUtil = new ConnectionStringUtility(
                Kwenda.Common.Models.Constants.FullAccessConnectionString
                );
            string location = null;

            var hubResource = "messages/?";
            var apiVersion = "api-version=2015-04";
            var notificationId = "Failed to get Notification Id";

            //=== Generate SaS Security Token for Authentication header ===
            // Determine the targetUri that we will sign
            var uri = connectionSaSUtil.Endpoint + Common.Models.Constants.NotificationHubName + "/" + hubResource + apiVersion;

            // 10 min expiration
            var sasToken = connectionSaSUtil.GetSaSToken(uri, 10);

            WebHeaderCollection headers = new WebHeaderCollection();
            StringBuilder body = new StringBuilder();
            foreach (string key in messageParams.Keys)
            {
                if (body.Length > 0)
                {
                    body.Append(", ");

                } // Add separator

                Dictionary<string, string> dict = messageParams[key] as Dictionary<string, string>;
                if (dict != null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string dictkey in dict.Keys)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(", ");

                        } // Add separator

                        sb.Append($"\"{dictkey}\": \"{dict[dictkey]}\"");
                        
                    } // foreach

                    body.Append($"\"{key}\": {{ {sb.ToString()} }}");

                }
                else
                {
                    body.Append($"\"{key}\": \"{messageParams[key]}\"");

                }

                

            } // foreach
            body.Insert(0, "{");
            body.Append("}");

            HttpWebResponse response = null;

            headers.Add("ServiceBusNotification-Format", "template");
            response = await ExecuteREST("POST", uri, sasToken, headers, body.ToString());
            
            char[] seps1 = { '?' };
            char[] seps2 = { '/' };

            if (response == null)
            {
                return "Didn't get any response.";
            }

            if (response != null && response.StatusCode != HttpStatusCode.Created)
            {
                return string.Format("Failed to get notification message id - Http Status {0} : {1}", (int)response.StatusCode, response.StatusCode.ToString());
            }

            if ((location = response.Headers.Get("Location")) != null)
            {
                var locationUrl = location.Split(seps1);
                var locationParts = locationUrl[0].Split(seps2);

                notificationId = locationParts[locationParts.Length - 1];

                return notificationId;
            }

            return null;
        }

        private static async Task<HttpWebResponse> ExecuteREST(string httpMethod, string uri, string sasToken, WebHeaderCollection headers = null, string body = null, string contentType = "application/json")
        {
            //=== Execute the request 
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            HttpWebResponse response = null;
            request.Method = httpMethod;
            request.ContentType = contentType;
            request.ContentLength = 0;

            if (sasToken != null)
                request.Headers.Add("Authorization", sasToken);

            if (headers != null)
            {
                request.Headers.Add(headers);
            }

            if (body != null)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(body);

                try
                {
                    request.ContentLength = bytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            try
            {
                await request.GetResponseAsync();
            }
            catch (WebException we)
            {
                if (we.Response != null)
                {
                    response = (HttpWebResponse)we.Response;
                }
                else
                    Console.WriteLine(we.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return response;
        }



    } // class

}
