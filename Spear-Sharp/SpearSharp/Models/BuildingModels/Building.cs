namespace SpearSharp.Models
{

    public class Building
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public int Cost { get; set; }
        public string Type { get; set; }
        public int KingdomId { get; set; }

        public Building()
        {
        }
    }
}
