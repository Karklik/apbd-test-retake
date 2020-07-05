using apbd_test_retake.Models;
using System.Linq;

namespace apbd_test_retake.Services
{
    public class NpgsqlFireBrigadeDbService : IFireBrigadeDbService
    {
        private readonly FireBrigadeDbContext context;
        public NpgsqlFireBrigadeDbService(FireBrigadeDbContext context)
        {
            this.context = context;
        }

        public FireTruckAction AddFireTruckAction(FireTruckAction fireTruckAction)
        {
            var doctorEntity = context.FireTruckActions.Add(fireTruckAction);
            if (context.SaveChanges() > 0)
                return doctorEntity.Entity;
            else
                return null;
        }

        public Action GetAction(int IdAction)
        {
            return context.Actions.Where(a => a.IdAction == IdAction).FirstOrDefault();
        }

        public Firefighter GetFirefighter(int IdFirefighter)
        {
            return context.Firefighters.Where(f => f.IdFirefighter == IdFirefighter).FirstOrDefault();
        }

        public FireTruck GetFireTruck(int IdFireTruck)
        {
            return context.FireTrucks.Where(f => f.IdFireTruck == IdFireTruck).FirstOrDefault();
        }
    }
}
