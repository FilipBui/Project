using System;
using System.Linq;

namespace SpearSharp.Models.BuildingModels
{
    public class Farm : Building
    {
        public int Id { get; set; }
        public int Level = 1;
        public int HP = 500;
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public int Cost = 100;
        public int FoodCost = 50;
        public string Type = "Farm";

        public Farm(DateTime startedAt, DateTime finishedAt)
        {
            StartedAt = startedAt;
            FinishedAt = finishedAt;
        }
        public Farm()
        {

        }
    }
}

