using SQLite;

namespace WayfindR.Models
{
    [Table("CacheFiles")]
    public class CacheFile
    {

        [Indexed]
        public string GraphId { get; set; }
        [Indexed]
        public string VenueId { get; set; }

        public string FileName { get; set; }

        [Indexed]
        public string FileExt { get; set; }



    }
}
