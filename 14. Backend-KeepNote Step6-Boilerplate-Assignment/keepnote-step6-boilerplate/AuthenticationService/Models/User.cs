namespace AuthenticationService.Models
{
    public class User
    {
        public string UserId { get; set; }

        public string Password { get; set; }

        public User(string userId, string password)
        {
            UserId = userId;
            Password = password;
        }
    }
}
