namespace SpearSharp.Models.DTOs
{
    public class KingdomDetailsDTO
    {
        public KingdomDTO KingdomDTO { get; set; }
        public ResourcesDTO ResourceDTO { get; set; }
        public List<BuildingDTO> BuildingsDTO { get; set; }
        public List<TroopDTO> TroopsDTO { get; set; }

        public KingdomDetailsDTO(KingdomDTO kingdomDTO, ResourcesDTO resourceDTO, List<BuildingDTO>? buildingsDTO, List<TroopDTO>? troopsDTO)
        {
            KingdomDTO = kingdomDTO;
            ResourceDTO = resourceDTO;
            BuildingsDTO = buildingsDTO;
            TroopsDTO = troopsDTO;
        }
    }
}
