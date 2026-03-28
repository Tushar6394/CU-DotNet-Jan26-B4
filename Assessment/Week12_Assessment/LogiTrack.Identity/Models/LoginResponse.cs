namespace LogiTrack.Identity.Models
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; } = "Bearer";
    }
}
