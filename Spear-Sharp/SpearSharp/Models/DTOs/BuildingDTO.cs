using System;
namespace SpearSharp.Models.DTOs
{
    public class BuildingDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int Cost { get; set; }
        public int HP { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public string Message { get; set; }

        public BuildingDTO(int id, int level, string type, int cost, DateTime? startedAt, DateTime? finishedAt, int hp)
        {
            Id = id;
            Level = level;
            Type = type;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            Cost = cost;
        }

        public BuildingDTO(int id, int level, string type, DateTime? startedAt, DateTime? finishedAt, int hp, string message)
        {
            Id = id;
            Type = type;
            Level = level;
            HP = hp;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            Message = message;
        }

        public BuildingDTO(string message)
        {
            this.Message = message;
        }

        public BuildingDTO()
        {
        }

        public BuildingDTO(int id, int level, string type, DateTime? startedAt, DateTime? finishedAt, int hp)
        {
            Id = id;
            Level = level;
            Type = type;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            HP = hp;
        }
    }
}