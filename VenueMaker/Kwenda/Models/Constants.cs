using System;
using System.Collections.Generic;
using System.Text;


namespace Kwenda.Common.Models
{
    public class Constants
    {

        // Common colors
        public const string MAWINGU_Text_Color = "#004899";
        public const string MAWINGU_Cloud_Color = "#ACFFFF";

        public const string KWENDA_i_Color = "#E41F13";
        public const string KWENDA_Arrow_Color = "#1D1D1B";
        public const string KWENDA_Frame_Color = "#706F6F";
        public const string KWENDA_Frame_Contrast_Color = "#FFFFFF";



        public const string TitleBackColor = KWENDA_Frame_Color;
        public const string TitleTextColor = KWENDA_Frame_Contrast_Color;


        public const string ForestGreenColor = "#228b22";
        public const string BlueColor = "#0000FF";
        public const string LightBlueColor = "#ADD8E6";
        public const string OrangeColor = "#FFA500";
        public const string RedColor = "#FF0000";


        public const string BlueDotColor = BlueColor;
        public const string AlmostBlueDotColor = LightBlueColor;
        public const string InfoPointColor = ForestGreenColor;
        public const string StartingPointColor = OrangeColor;
        public const string DestinationPointColor = RedColor;


        public const double ExtendedLineSpacing = 12f;

        public const int RefreshIntervalForNearbyBeacons = 2000;
        public const int StickyBeaconTime = 7000;


        
        // Azure app-specific connection string and hub path
        public const string ListenConnectionString = "Endpoint=sb://kwenda.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=mFmbgvt72li++gNCQIXyCSMhFjExyxjT1o2aO5m2ogQ=";
        public const string FullAccessConnectionString = "Endpoint=sb://kwenda.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=NiB5Uun8HKtpvNyrG21w/iI1IuN9f8Xy67Bnc8p+Vtg=";
        public const string NotificationHubName = "mawingu";



    }
}
