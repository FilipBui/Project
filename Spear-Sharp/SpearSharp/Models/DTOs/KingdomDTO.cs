using System;
namespace SpearSharp.Models.DTOs
{
    public class KingdomDTO
    {
        public int KingdomId { get; set; }
        public string KingdomName { get; set; }
        public Player Ruler { get; set; }
        public int Population { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }

        public KingdomDTO(int id, string kingdomName, int pop, double coorX, double coorY)
        {
            KingdomId = id;
            KingdomName = kingdomName;
            Population = pop;
            CoordinateX = coorX;
            CoordinateY = coorY;
        }
        public KingdomDTO()
        {
        }
    }
}