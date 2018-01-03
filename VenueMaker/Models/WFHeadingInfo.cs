using System;

namespace WayfindR.Models
{
    public class WFHeadingInfo
    {
        
        public int Heading { get; set; }
        public string Info { get; set; }
        public string Image { get; set; }
        public string ImageDescription { get; set; }



        public WFHeadingInfo()
            : this("")
        {
        }

        public WFHeadingInfo(string data)
        {
            Heading = -1;

            string[] parts = data.Split(';');
            if (parts.Length >= 1)
            {
                int value;
                if (int.TryParse(parts[0], out value))
                {
                    Heading = value;
                }
            } // Heading

            if (parts.Length >= 2)
            {
                Info = parts[1];

            } // Info

            if (parts.Length >= 3)
            {
                Image = parts[2];

            } // Image

            if (parts.Length >= 4)
            {
                ImageDescription = parts[3];

            } // Image Description
        }



        public override string ToString()
        {
            string result = string.Format("{0};{1};{2};{3}",
                Heading,
                Info,
                Image,
                ImageDescription
                );

            if (Heading == -1 &&
                string.IsNullOrWhiteSpace(Info) &&
                string.IsNullOrWhiteSpace(Image) &&
                string.IsNullOrWhiteSpace(ImageDescription))
            {
                result = string.Empty;

            } // Nothing

            return result;
        }

    }
}
