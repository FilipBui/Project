using SpearSharp.Models.DTOs;

namespace SpearSharp.Services
{
    public interface ILeaderboardsService
    {
        List<KingdomsLeaderboardDTO> GetKingdomsLeaderboardDTOs();
        List<TroopsLeaderboardDTO> GetTroopsLeaderboardDTOs();
        List<BuildingsLeaderboardDTO> GetBuildingsLeaderboardDTOs();
    }
}
