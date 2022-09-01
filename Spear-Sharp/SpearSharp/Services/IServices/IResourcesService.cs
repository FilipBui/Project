using SpearSharp.Models.DTOs;
using System;
namespace SpearSharp.Services
{
    public interface IResourcesService
    {
        ResourcesDTO GetKingdomsResourcesByKingdomId(int userId);
    }
}