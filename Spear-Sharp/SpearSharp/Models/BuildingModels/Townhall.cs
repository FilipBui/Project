using System;
namespace SpearSharp.Models.BuildingModels
{
    public class Townhall : Building
    {
        public int Id { get; set; }
        public int Level = 1;
        public int HP = 500;
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public int Cost = 200;
        public int FoodCost = 100;
        public string Type = "Townhall";

        public Townhall(DateTime startedAt, DateTime finishedAt)
        {
            StartedAt = startedAt;
            FinishedAt = finishedAt;
        }
        public Townhall()
        {

        }
    }
}

