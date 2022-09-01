using SpearSharp.Models.DTOs;
using SpearSharp.Database;

namespace SpearSharp.Services
{
    public class LeaderboardsService : ILeaderboardsService
    {
        private IApplicationDbContext data;

        public LeaderboardsService(IApplicationDbContext data)
        {
            this.data = data;
        }

        public List<KingdomsLeaderboardDTO> GetKingdomsLeaderboardDTOs()
        {
            return data.Kingdoms.Select(k => new KingdomsLeaderboardDTO()
            {
                Kingdom = k.KingdomName,
                Ruler = k.Ruler.Username,
                Buildings = k.Buildings.Count,
                Troops = k.Army.Count,
                Points = k.Army.Select(k => k.Upkeep).Sum() + k.Buildings.Select(k => k.Level).Sum()
            }).OrderByDescending(k => k.Points).ToList();
        }

        public List<TroopsLeaderboardDTO> GetTroopsLeaderboardDTOs()
        {
            return data.Kingdoms.Select(t => new TroopsLeaderboardDTO()
            {
                Kingdom = t.KingdomName,
                Ruler = t.Ruler.Username,
                Troops = t.Army.Count,
                Points = t.Army.Select(t => t.Upkeep).Sum()
            }).OrderByDescending(t => t.Points).ToList();
        }

        public List<BuildingsLeaderboardDTO> GetBuildingsLeaderboardDTOs()
        {
            return data.Kingdoms.Select(b => new BuildingsLeaderboardDTO()
            {
                Kingdom = b.KingdomName,
                Ruler = b.Ruler.Username,
                Buildings = b.Buildings.Count,
                Points = b.Buildings.Select(b => b.Level).Sum()
            }).OrderByDescending(b => b.Points).ToList();
        }
    }
}
