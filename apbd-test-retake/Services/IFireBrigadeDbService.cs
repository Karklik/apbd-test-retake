using apbd_test_retake.Models;

namespace apbd_test_retake.Services
{
    public interface IFireBrigadeDbService
    {
        public Firefighter GetFirefighter(int IdFirefighter);
        public Action GetAction(int IdAction);
        public FireTruck GetFireTruck(int IdFireTruck);
        public FireTruckAction AddFireTruckAction(FireTruckAction fireTruckAction);
    }
}
