using SpearSharp.Database;

namespace SpearSharp.Services
{
    public class RulesService : IRulesService
    {
        private IApplicationDbContext data;

        public RulesService(IApplicationDbContext data)
        {
            this.data = data;
        }

        public int GetBuildingGenerationPerMinute(string type, int level)
        {
            var generation = level * data.BuildingsTemplate.First(b => b.Type == type).Generation;
            return (level * generation) + generation;
        }

        public int GetBuildingCost(string type, int level)
        {
            return String.IsNullOrEmpty(type) ? 0 : level * data.BuildingsTemplate.FirstOrDefault(b => b.Type == type).Cost;
        }

        public int GetBuildingHP(string type, int level)
        {
            return String.IsNullOrEmpty(type) ? 0 : level * data.BuildingsTemplate.First(b => b.Type == type).HP;
        }

        public int GetBuildingTime(string type, int level)
        {
            return String.IsNullOrEmpty(type) ? 0 : level * data.BuildingsTemplate.First(b => b.Type == type).BuildingTime;
        }

        public int GetTroopCost(string type, int level)
        {
            return level * data.TroopsTemplate.First(b => b.TroopType == type).Cost;
        }

        public int GetTroopHP(string type, int level)
        {
            return level * data.TroopsTemplate.First(b => b.TroopType == type).HP;
        }

        public int GetTroopDamage(string type, int level)
        {
            return level * data.TroopsTemplate.First(b => b.TroopType == type).Damage;
        }

        public int GetTroopUpkeep(string type, int level)
        {
            return level * -data.TroopsTemplate.First(b => b.TroopType == type).Upkeep;
        }
    }
}
