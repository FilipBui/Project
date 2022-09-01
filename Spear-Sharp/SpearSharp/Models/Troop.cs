using SpearSharp.Models.TroopsType;

namespace SpearSharp.Models
{
    public class Troop
    {
        public int Id { get; set; }
        public int HP { get; set; }
        public int Cost { get; set; }
        public string TroopType { get; set; }
        public int TroopLevel { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Upkeep { get; set; }
        public Kingdom Kingdom { get; set; }
        public int KingdomId { get; set; } //?//
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
    }
 }
