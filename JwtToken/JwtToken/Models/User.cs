namespace JwtToken.Models
{
    public class User
    {
        public string UserName { get; set; } = string.Empty;
        public string Passwordhash { get; set; } = string.Empty;
    }
}
