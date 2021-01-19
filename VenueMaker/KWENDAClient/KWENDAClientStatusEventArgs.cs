using System;

namespace KWENDA
{
    public class KWENDAClientStatusEventArgs : EventArgs
    {
        public string StatusMessage { get; set; }


        public KWENDAClientStatusEventArgs()
        {
        }

        public KWENDAClientStatusEventArgs(string msg)
            : this()
        {
            StatusMessage = msg;

        }

    } // class

}