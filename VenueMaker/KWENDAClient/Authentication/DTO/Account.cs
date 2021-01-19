namespace MAWINGU.Authentication.DTO
{
    public class Account
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }
        public string Organization { get; set; }
        public bool Inactive { get; set; }
        public bool Verified { get; set; }

        //public AccountLevel Level { get; set; }


    }
}