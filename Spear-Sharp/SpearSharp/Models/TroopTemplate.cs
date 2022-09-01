namespace SpearSharp.Models
{
    public class TroopTemplate
    {
        public int Id { get; set; }
        public int HP { get; set; }
        public int Cost { get; set; }
        public string TroopType { get; set; }
        public int TrainingTime { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Upkeep { get; set; }
    }
}
