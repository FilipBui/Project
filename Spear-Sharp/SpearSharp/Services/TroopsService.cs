using System;
using SpearSharp.Database;
using SpearSharp.Models;
using SpearSharp.Models.DTOs;

namespace SpearSharp.Services
{
    public class TroopsService : ITroopsService
    {
        private readonly ApplicationDbContext database;
        public TroopsService(ApplicationDbContext data)
        {
            database = data;
        }

        public List<TroopDTO> GetTroopsListDTOByKingdomId(int id)
        {
            List<TroopDTO> troops = database.Troops.Select(t => new TroopDTO()
            {
                Id = t.Id,
                Level = t.TroopLevel,
                Hp = t.HP,
                Attack = t.Damage,
                Defense = t.Armor,
                StartedAt = t.StartedAt,
                FinishedAt = t.FinishedAt,
            }).Where(t => t.Kingdom.Id == id).ToList();
            return troops;
        }
    }
}