namespace SpearSharp.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Kingdom Kingdom { get; set; }
        public int KingdomId { get; set; }

        public Player(string name, string password, string email)
        {
            Username = name;
            Password = password;
            Email = email;
        }
        public Player()
        {
        }
    }
}