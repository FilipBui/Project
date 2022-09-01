using System;
using SpearSharp.Models.DTOs;
using SpearSharp.Database;
using SpearSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace SpearSharp.Services
{
    public class KingdomService : IKingdomService
    {
        private IApplicationDbContext data;
        public KingdomService(IApplicationDbContext data)
        {
            this.data = data;
        }

        public Kingdom ReturnKingdom(int id)
        {
            return (Kingdom)data.Kingdoms.Where(k => k.Id == id);
        }

        public List<Kingdom> ReturnKingdoms()
        {
            return data.Kingdoms.Include(k => k.Ruler).Include(k => k.Buildings).Include(k => k.Army).ToList();
        }
        public List<KingdomDTO> GetKingdoms()
        {
            List<KingdomDTO> kingdoms = new List<KingdomDTO>();
            foreach (var kingdom in ReturnKingdoms())
            {
                kingdoms.Add(new KingdomDTO(kingdom.Id, kingdom.KingdomName, kingdom.Army.Count(), kingdom.CoordinateX, kingdom.CoordinateY));
            }
            return kingdoms;
        }

        public Kingdom GetKingdomById(int id)
        {
            return data.Kingdoms.Include(k => k.Army).Include(k => k.Buildings).FirstOrDefault(b => b.Id == id);
        }
        public Kingdom GetKingdomName(int id)
        {
            return data.Kingdoms.SingleOrDefault(k => k.Id == id);
        }

        public KingdomDetailsDTO GetKingdomDetails(int id)
        {
            Kingdom kingdom = GetKingdomById(id);

            if (kingdom == null)
                return null;

            KingdomDTO kingdomDTO = new KingdomDTO(kingdom.Id, kingdom.KingdomName, kingdom.Army.Count, kingdom.CoordinateX, kingdom.CoordinateY);

            ResourcesDTO resourceDTO = new ResourcesDTO(kingdom.Id, kingdom.GoldAmount, kingdom.FoodAmount);

            List<BuildingDTO> buildingsDTO = kingdom.Buildings.Select(b => new BuildingDTO(b.Id, b.Level, b.Type,b.Cost, b.StartedAt, b.FinishedAt, b.Cost)).ToList();
            
            List<TroopDTO> troopsDTO = kingdom.Army.Select(x => new TroopDTO(x.Id, x.TroopType, x.TroopLevel, x.HP, x.Damage, x.Armor, x.StartedAt, x.FinishedAt)).ToList();

            KingdomDetailsDTO kingdomDetails = new KingdomDetailsDTO(kingdomDTO, resourceDTO, buildingsDTO, troopsDTO);
            return kingdomDetails;
        }
        public KingdomNameChangeDTO RenameKingdom(int id, string kingdomName)
        {
            data.Kingdoms.SingleOrDefault(k => k.Id == id).KingdomName = kingdomName;
            data.SaveChanges();
            return new KingdomNameChangeDTO(id, kingdomName);
        }

        public int GetKingdomIdByName(string kingdomName)
        {
            return data.Kingdoms.FirstOrDefault(k => k.KingdomName == kingdomName).Id;
        }

  

        public bool IsKingdomNameTaken(PlayerRegistrationDTO player)
        {
            if (player.KingdomName == null)
                return false;
            return data.Kingdoms.Any(k => k.KingdomName.ToLower().Equals(player.KingdomName.ToLower()));
        }

        public bool AreCoordinatesTaken(int kingdomId, int coordinateX, int coordinateY)
        {
            return data.Kingdoms.Where(k => k.Id == kingdomId).Any(k => k.CoordinateY == coordinateY && k.CoordinateX == coordinateX);
        }

        public void SetCoordinates(int kingdomId, int coordinateX, int coordinateY)
        {
            var kingdom = data.Kingdoms.First(k => k.Id == kingdomId);
            kingdom.CoordinateX = coordinateX;
            kingdom.CoordinateY = coordinateY;
            data.SaveChanges();
        }

        public Kingdom GetKingdomByUserName(Player player)
        {
            return data.Kingdoms.Include(k => k.Army).Include(k => k.Buildings).FirstOrDefault(b => b.Ruler.Username == player.Username);
        }

        public KingdomDTO GetKingdomDTOById(int id)
        {
            var kingdom = data.Kingdoms.Include(k => k.Army).FirstOrDefault(k => k.Id == id);
            return new KingdomDTO() { KingdomId = kingdom.Id, KingdomName = kingdom.KingdomName, Ruler = kingdom.Ruler, CoordinateX = kingdom.CoordinateX, CoordinateY = kingdom.CoordinateY, Population = kingdom.Army.Count };
        }
    }
}
