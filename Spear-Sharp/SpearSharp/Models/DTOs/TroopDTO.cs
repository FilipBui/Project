using System;
namespace SpearSharp.Models.DTOs
{
	public class TroopDTO
	{
		public int Id { get; set; }
        public string TroopType { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public Kingdom Kingdom { get; set; }

        public TroopDTO(int id, string troopType, int level, int hp, int attack, int defense, DateTime startedAt, DateTime finishedAt)
        {
            this.Id = id;
            this.TroopType = troopType;
            this.Level = level;
            this.Hp = hp;
            this.Attack = attack;
            this.Defense = defense;
            this.StartedAt = startedAt;
            this.FinishedAt = finishedAt;
        }

        public TroopDTO()
        {

        }
    }
}