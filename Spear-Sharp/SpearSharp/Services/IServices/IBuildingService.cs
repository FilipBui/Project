using System;
using SpearSharp.Models;
using SpearSharp.Models.DTOs;
namespace SpearSharp.Services
{
    public interface IBuildingService
    {
        bool AreBuildingRequirementsMet(int id, string buildingType);
        public BuildingDTO AddBuilding(int id, string buildingType);
        List<Building> GetBuildingsByKingdomId(int id);
    }
}

