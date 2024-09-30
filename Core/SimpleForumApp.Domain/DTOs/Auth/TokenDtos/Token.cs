namespace SimpleForumApp.Domain.DTOs.Auth.TokenDtos
{
    public class Token
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime RefreshTokenExpirationDate { get; set; }
    }
}
