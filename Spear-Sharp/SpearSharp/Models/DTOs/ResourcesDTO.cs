using System;
namespace SpearSharp.Models.DTOs
{
    public class ResourcesDTO
    {
        public int KingdomId { get; set; }
        public string Resource1 { get; set; }
        public int GoldAmount { get; set; }
        public string Resource2 { get; set; }
        public int FoodAmount { get; set; }

        public ResourcesDTO(int kingdomId, int goldAmount, int foodAmount)
        {
            KingdomId = kingdomId;
            Resource1 = "Gold";
            Resource2 = "Food";
            GoldAmount = goldAmount;
            FoodAmount = foodAmount;
        }
    }
}