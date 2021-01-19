namespace MAWINGU.Authentication.DTO
{
    public class AuthenticateResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public ErrorResponse Error { get; set; }


    } // class
}
