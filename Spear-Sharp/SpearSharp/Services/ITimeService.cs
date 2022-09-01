namespace SpearSharp.Services
{
    public interface ITimeService
    {
        bool IsBuildingUnderUpgradeProcess(DateTime? finishedAt);
    }
}