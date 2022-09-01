using System;
using SpearSharp.Models.DTOs;

namespace SpearSharp.Services
{
    public interface IBuildingsService
    {
        BuildingDTO GetBuildingById(int buildingId);
        bool HasEnoughGoldForBuildingUpgrade(int buildingId, int kingdomId);
        BuildingDTO UpgradeBuilding(int buildingId, int kingdomId);
    }
}
