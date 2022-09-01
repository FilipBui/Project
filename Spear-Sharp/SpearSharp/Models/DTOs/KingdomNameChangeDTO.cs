using System;
namespace SpearSharp.Models.DTOs
{
    public class KingdomNameChangeDTO
    {
        public int KingdomId { get; set; }
        public string KingdomName { get; set; }
        public KingdomNameChangeDTO(int kingdomId, string kingdomName)
        {
            KingdomId = kingdomId;
            KingdomName = kingdomName;
        }
    }
}

