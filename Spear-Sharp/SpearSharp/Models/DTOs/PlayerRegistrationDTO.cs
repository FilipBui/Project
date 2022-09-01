namespace SpearSharp.Models.DTOs
{
    public class PlayerRegistrationDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string KingdomName { get; set; }
        public string Email { get; set; }
        public int KingdomId { get; set; }

        public PlayerRegistrationDTO(string username, int kingdomId)
        {
            Username = username;
            KingdomId = kingdomId;
        }

        public PlayerRegistrationDTO()
        {
        }
    }
}
