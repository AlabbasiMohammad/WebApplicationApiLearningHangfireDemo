using WebApplicationApiDemo.General.Interfaces;

namespace WebApplicationApiDemo.General
{
    public class MaintenanceService : IMaintenanceService
    {
        public void SyncRecords()
        {
            Console.WriteLine("the sync has started");
        }
    }
}
