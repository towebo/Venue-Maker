using System;

namespace WayfindR.Models
{
    public class WFHeadingInfo
    {
        
        public int Heading { get; set; }
        public string Info { get; set; }



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
        }



        public override string ToString()
        {
            return string.Format("{0};{1}",
                Heading,
                Info
                );
        }

    }
}
