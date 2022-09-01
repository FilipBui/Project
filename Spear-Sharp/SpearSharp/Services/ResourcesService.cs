using SpearSharp.Database;
using SpearSharp.Models.DTOs;
using System;
namespace SpearSharp.Services
{
    public class ResourcesService : IResourcesService
    {
        private ApplicationDbContext data;

        public ResourcesService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public ResourcesDTO GetKingdomsResourcesByKingdomId(int kingdomId)
        {
            return new ResourcesDTO(
                kingdomId,
                data.Kingdoms.Single(x => x.Id == kingdomId).GoldAmount,
                data.Kingdoms.Single(x => x.Id == kingdomId).FoodAmount);
        }
    }
}