namespace SpearSharp.Models
{
    public class Kingdom
    {  
        public int Id { get; set; }
        public string KingdomName { get; set; }
        public int RulerId { get; set; }
        public Player Ruler { get; set; }
        public List<Building> Buildings { get; set; }
        public List<Troop> Army { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public int GoldAmount { get; set; }
        public int FoodAmount { get; set; }
        public Kingdom()
        {
        }

        public Kingdom(string kingdomName)
        {
            KingdomName = kingdomName;
        }

        public Kingdom(int kingdomId, string kingdomName)
        {
            KingdomName = kingdomName;
            Id = kingdomId;
        }

        public Kingdom(int kingdomId, string kingdomName, int coordinateX, int coordinateY)
        {
            KingdomName = kingdomName;
            Id = kingdomId;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
    }
}