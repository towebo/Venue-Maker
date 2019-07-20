using System;
using System.Collections.Generic;
using System.Text;

namespace Kwenda.Common.Models
{
    public class AppMessages
    {
        public const int KWERR_OK = 0;

        public const int KWERR_DownloadInfrastructureError = 10;
        public const string KWERR_DownloadInfrastructureError_Msg = "Fel när data skulle hämtas.";

        public const int KWERR_ListFilesError = 11;
        public const string KWERR_ListFilesError_Msg = "Fel när listan över filer skulle hämtas.";

        public const int KWERR_GetKwendaFilesError = 12;
        public const string KWERR_GetKwendaFilesError_Msg = "Fel när filer skulle hämtas.";

        public const int KWERR_LoadInfrastructureError = 13;
        public const string KWERR_LoadInfrastructureError_Msg = "Fel när data skulle laddas.";

        public const int KWERR_HostUnreachable = 14;
        public const string KWERR_HostUnreachable_Msg = "Kan inte nå servern som Kwenda finns på. Kontrollera så inte ditt nätverk blockerar {0}";


    }
}
