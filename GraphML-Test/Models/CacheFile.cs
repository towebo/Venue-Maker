using SQLite;

namespace WayfindR.Models
{
    [Table("CIFiles")]
    public class CacheFile
    {

        [Indexed]
        public string FileId { get; set; }

        public string FileName { get; set; }

        [Indexed]
        public string FileExt { get; set; }



    }
}
