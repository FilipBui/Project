namespace SpearSharp.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public Kingdom Kingdom { get; set; }

        public UserDTO(int id, string userName, string password, Kingdom kingdom)
        {
            Id = id;
            UserName = userName;
            PassWord = password;
            Kingdom = kingdom;
        }

        public UserDTO() { }
    }
}
