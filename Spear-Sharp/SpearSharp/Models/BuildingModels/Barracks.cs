using System;
namespace SpearSharp.Models.BuildingModels
{
    public class Barracks : Building
    {
        public int Id { get; set; }
        public int Level = 1;
        public int HP = 1000;
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public int Cost = 300;
        public int FoodCost = 300;
        public string Type = "Barracks";

        public Barracks(DateTime startedAt, DateTime finishedAt)
        {
            StartedAt = startedAt;
            FinishedAt = finishedAt;
        }
        public Barracks()
        {

        }
    }
}
