using System;
using SpearSharp.Models.DTOs;
using SpearSharp.Models;
using SpearSharp.Database;
namespace SpearSharp.Services
{
    public interface IKingdomService
    {
        Kingdom ReturnKingdom(int id);
        List<KingdomDTO> GetKingdoms();
        Kingdom GetKingdomById(int Id);
        int GetKingdomIdByName(string kingdomName);
        KingdomNameChangeDTO RenameKingdom(int id, string kingdomName);
        KingdomDetailsDTO GetKingdomDetails(int id);
        bool IsKingdomNameTaken(PlayerRegistrationDTO player);
        bool AreCoordinatesTaken(int id, int coordinateX, int coordinateY);
        void SetCoordinates(int kingdomId, int coordinateX, int coordinateY);
        Kingdom GetKingdomByUserName(Player player);
        KingdomDTO GetKingdomDTOById(int id);
    }
}
