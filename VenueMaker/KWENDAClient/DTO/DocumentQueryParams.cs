using System.Web;

namespace KWENDA.DTO
{
    public class DocumentFilterParams
    {
        public string AppId { get; set; }
        public string Title { get; set; }
        public string Device { get; set; }
        public string UserName { get; set; }
        
        public string AsQueryString()
        {
            var query = HttpUtility.ParseQueryString("");

            if (!string.IsNullOrWhiteSpace(AppId))
            {
                query["appid"] = AppId;
                
            } // AppId

            if (!string.IsNullOrWhiteSpace(Title))
            {
                query["title"] = Title;

            } // Title

            if (!string.IsNullOrWhiteSpace(Device))
            {
                query["device"] = Device;

            } // Device

            if (!string.IsNullOrWhiteSpace(UserName))
            {
                query["username"] = UserName;

            } // UserName

            return query.ToString();

        }

    }
}
