using Microsoft.Azure.NotificationHubs;
using System;

namespace KWENDAPushLib
{
    public class PushController
    {
        private const string FullAccessConnectionString = "Endpoint=sb://kwenda.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=NiB5Uun8HKtpvNyrG21w/iI1IuN9f8Xy67Bnc8p+Vtg=";
        private const string NotificationHubName = "mawingu";

        private const string AppleSampleNotificationContent = "{\"aps\":{\"alert\":\"{0}\"}}";
        private const string AppleSampleSilentNotificationContent = "{\"aps\":{\"content-available\":1}, \"foo\": 2 }";


        public async static void PushMessageApple(string msg)
        {
            try
            {
                NotificationHubClient nhClient = NotificationHubClient.CreateClientFromConnectionString(
                    FullAccessConnectionString,
                    NotificationHubName
                    );

                Notification notification = new AppleNotification(
                    string.Format(AppleSampleNotificationContent, msg)
                    );

                NotificationOutcome outcomeApns = await nhClient.SendNotificationAsync(notification);

            }
            catch (Exception ex)
            {
                string errmsg = $"PushMessageApple({msg}): {ex.Message}";
                throw new Exception(errmsg);

            }

        }





    }
}
