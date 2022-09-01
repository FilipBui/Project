namespace SpearSharp.Services
{
    public interface IRulesService
    {
        int GetBuildingCost(string type, int level);
        int GetBuildingGenerationPerMinute(string type, int level);
        int GetBuildingHP(string type, int level);
        int GetBuildingTime(string type, int level);
        int GetTroopCost(string type, int level);
        int GetTroopDamage(string type, int level);
        int GetTroopHP(string type, int level);
        int GetTroopUpkeep(string type, int level);
    }
}