using System;
using SpearSharp.Models;
using SpearSharp.Database;
using SpearSharp.Models.BuildingModels;
using SpearSharp.Models.DTOs;
using System.Linq;

namespace SpearSharp.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IApplicationDbContext data;
        private readonly IRulesService rulesService;
        public BuildingService(IApplicationDbContext data, IRulesService rulesService)
        {
            this.data = data;
            this.rulesService = rulesService;
        }

        public BuildingDTO AddBuilding(int id, string buildingType)
        {
            DateTime startTime = DateTime.Now;
            DateTime finishTime = DateTime.Now;

            switch (buildingType)
            {
                case "Farm":
                    if (AreBuildingRequirementsMet(id, "Farm") == true)
                    {
                        data.Buildings.Add(new Farm(startTime, finishTime.AddMinutes(10)));
                    }
                    return new BuildingDTO(id, 1, "Farm", rulesService.GetBuildingCost("Farm",1), startTime, finishTime.AddMinutes(10), 100);
                    break;
                case "Townhall":
                    if (AreBuildingRequirementsMet(id, "Townhall") == true)
                    {
                        data.Buildings.Add(new Townhall(startTime, finishTime.AddMinutes(45)));
                    }
                    return new BuildingDTO(id, 1, "Townhall", rulesService.GetBuildingCost("Townhall", 1), startTime, finishTime.AddMinutes(45), 200);
                    break;
                case "Barracks":
                    if (AreBuildingRequirementsMet(id, "Barracks") == true)
                    {
                        data.Buildings.Add(new Barracks(startTime, finishTime.AddMinutes(30)));
                    }
                    return new BuildingDTO(id, 1, "Barracks", rulesService.GetBuildingCost("Barracks", 1), startTime, finishTime.AddMinutes(30), 300);
                    break;
                default:
                    return new BuildingDTO();
                    break;
            }
        }
        public bool FarmRequirements(Kingdom kingdom)
        {
            return data.Kingdoms.Contains(kingdom) && kingdom.GoldAmount > 100 && kingdom.Buildings.Select(b => b.Type = "Farm").Count() < 5;
        }
        public bool TownhallRequirements(Kingdom kingdom)
        {
            return data.Kingdoms.Contains(kingdom) && kingdom.GoldAmount > 200 && kingdom.FoodAmount > 100 && kingdom.Buildings.Select(b => b.Type = "Townhall").Count() < 2;
        }
        public bool BarracksRequirements(Kingdom kingdom)
        {
            return data.Kingdoms.Contains(kingdom) && kingdom.GoldAmount > 300 && kingdom.FoodAmount > 300 && kingdom.Buildings.Select(b => b.Type = "Barracks").Count() < 2;
        }

        public bool AreBuildingRequirementsMet(int id, string buildingType)
        {
            var kingdom = data.Kingdoms.SingleOrDefault(k => k.Id == id);
            bool areRequirementsMet;
            switch (buildingType)
            {
                case "Farm":
                    areRequirementsMet = FarmRequirements(kingdom);
                    break;
                case "Townhall":
                    areRequirementsMet = TownhallRequirements(kingdom);
                    break;
                case "Barracks":
                    areRequirementsMet = BarracksRequirements(kingdom);
                    break;
                default:
                    return false;
                    break;
            }
            return areRequirementsMet;
        }
        public List<Building> GetBuildingsByKingdomId(int id)
        {
            return data.Buildings.Where(k => k.KingdomId == id).ToList();
        }
    }
}

