using SpearSharp.Database;

namespace SpearSharp.Services
{
    public class TimeService : ITimeService
    {
        private ApplicationDbContext data;
        public TimeService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public bool IsBuildingUnderUpgradeProcess(DateTime? finishedAt)
        {
            if (finishedAt == null)
                return false;

            DateTime now = DateTime.Now;
            return now < finishedAt;
        }
    }
}
