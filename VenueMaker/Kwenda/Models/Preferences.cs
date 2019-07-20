using System;
using System.IO;
using System.Xml.Serialization;

namespace Kwenda
{
	public class Preferences
	{
		private static Preferences prefs;

		public Preferences()
		{
            DropboxAccessToken = string.Empty;

			ReadMessagesOutLoud = true;
			RefreshIntervalForNearbyBeacons = 5000;
            StickyBeaconTime = 5000;

            UseVoiceOverToSayStuff = true;

			VibrateToAlert = true;
            PlaySoundOnAlert = true;

			ShowNearbyBeaconsInHereView = false;
			ShowUnknownBeaconsInList = false;
			ShowUnknownBeaconInfoOnTouch = false;
			AnnounceEntrances = true;
            ShowIsAtInNearbyBeaconsList = false;

            //karl-otto
		}


		public static Preferences Load()
		{
			Preferences storedprefs;
			try
			{
				string filename = DataController.GetAppFile(AppFile.Prefs);


				if (File.Exists(filename))
				{
					XmlSerializer deserializer = new XmlSerializer(typeof(Preferences));
					using (TextReader textReader = new StreamReader(filename))
					{
						try
						{
							storedprefs = (Preferences)deserializer.Deserialize(textReader);

						}
						finally
						{
							textReader.Close();

						}

					} // using

				}
				else
				{
					storedprefs = new Preferences();
				}

				prefs = storedprefs;

				return prefs;

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return Me;

			}

		}

		public static Preferences Save()
		{
			try
			{
				Preferences myprefs = Me;

				string filename = DataController.GetAppFile(AppFile.Prefs);
				FileInfo fi = new FileInfo(filename);
				if (fi.Exists)
				{
					fi.Delete();
				}

				XmlSerializer serializer = new XmlSerializer(typeof(Preferences));
                using (TextWriter textWriter = new StreamWriter(filename))
                {
                    try
                    {
                        serializer.Serialize(textWriter, myprefs);
                        return myprefs;
                    }
                    finally
                    {
                        textWriter.Close();

                    }
                } // using

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return Me;

			}

		}

		public static Preferences Me
		{
			get
			{
				if (prefs == null)
				{
					prefs = new Preferences();
				}
				return prefs;
			}
		}

		public string DropboxAccessToken { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }


        public bool ReadMessagesOutLoud { get; set; }
		public int RefreshIntervalForNearbyBeacons { get; set; }
        public int StickyBeaconTime { get; set; }
        public bool UseVoiceOverToSayStuff { get; set; }
        public bool VibrateToAlert { get; set; }
        public bool PlaySoundOnAlert { get; set; }

        public bool ShowNearbyBeaconsInHereView { get; set; }
		public bool ShowUnknownBeaconsInList { get; set; }
		public bool ShowUnknownBeaconInfoOnTouch { get; set; }
        public bool ShowHeadingInfo { get; set; }

		public bool? UsageAgreementAccepted { get; set; }
		public bool AnnounceEntrances { get; set; }
        public bool ShowIsAtInNearbyBeaconsList { get; set; }

        public DateTime LastFileCheck { get; set; }

		public string LastStartedVersion { get; set; }


	}
}
