using Microsoft.EntityFrameworkCore;
using SpearSharp.Database;
using SpearSharp.Models;
using SpearSharp.Models.DTOs;

namespace SpearSharp.Services
{
    public class BuildingsService : IBuildingsService
    {
        private ApplicationDbContext data;
        private readonly IResourcesService resourcesService;
        private readonly ITimeService timeService;
        private readonly IRulesService rulesService;


        public BuildingsService(ApplicationDbContext data, IResourcesService resourcesService, ITimeService timeService, IRulesService rulesService)
        {
            this.data = data;
            this.resourcesService = resourcesService;
            this.timeService = timeService;
            this.rulesService = rulesService;
        }

        public BuildingDTO GetBuildingById(int buildingId)
        {
            Building building = data.Buildings.FirstOrDefault(b => b.Id == buildingId);
            return new BuildingDTO(
                building.Id,
                building.Level,
                building.Type,
                building.StartedAt,
                building.FinishedAt,
                building.HP
                );
        }

        public bool HasEnoughGoldForBuildingUpgrade(int buildingId, int kingdomId)
        {
            Building building = data.Buildings.FirstOrDefault(b => b.Id == buildingId);
            ResourcesDTO kingdomsResources = resourcesService.GetKingdomsResourcesByKingdomId(kingdomId);
            return rulesService.GetBuildingCost(building.Type, building.Level) < kingdomsResources.GoldAmount;
        }

        public BuildingDTO UpgradeBuilding(int buildingId, int kingdomId)
        {
            var buildingDb = data.Buildings.FirstOrDefault(b => b.Id == buildingId);
            var kingdom = data.Kingdoms.Include(k => k.Buildings).FirstOrDefault(k => k.Id == kingdomId);
            string message = "Your building is being upgraded";

            if (buildingDb == null)
            {
                message = "The building you are trying to upgrade doesn't exist. Please check the building ID";
                BuildingDTO upgradeError = new(message);
                return upgradeError;
            }

            if (buildingDb.FinishedAt != null && timeService.IsBuildingUnderUpgradeProcess((DateTime)buildingDb.FinishedAt))
            {
                message = "You can not upgrade this building because it's currently under upgrade";
                BuildingDTO upgradeError = new(message);
                return upgradeError;
            }

            if (buildingDb.Level >= kingdom.Buildings.FirstOrDefault(b => b.Type == "Townhall").Level && buildingDb.Type != "Townhall")
            {
                message = "You must upgrade townhall first";
                BuildingDTO upgradeError = new(message);
                return upgradeError;
            }

            if (!HasEnoughGoldForBuildingUpgrade(buildingId, kingdomId))
            {
                message = "You don't have enough gold to upgrade that!";
                BuildingDTO upgradeError = new(message);
                return upgradeError;
            }

            var cost = rulesService.GetBuildingCost(buildingDb.Type, buildingDb.Level);

            buildingDb.Level++;
            buildingDb.HP = rulesService.GetBuildingHP(buildingDb.Type, buildingDb.Level);
            kingdom.GoldAmount -= cost;
            buildingDb.StartedAt = DateTime.Now;
            buildingDb.FinishedAt = DateTime.Now.AddMinutes(rulesService.GetBuildingTime(buildingDb.Type, buildingDb.Level));

            BuildingDTO upgradedBuilding = new(
                buildingId,
                buildingDb.Level,
                buildingDb.Type,
                buildingDb.StartedAt,
                buildingDb.FinishedAt,
                buildingDb.HP,
                message
                );

            data.SaveChanges();
            return upgradedBuilding;
        }
    }
}
