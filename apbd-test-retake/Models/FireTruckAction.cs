using System;

namespace apbd_test_retake.Models
{
    public class FireTruckAction
    {
        public int IdFireTruckAction { get; set; }
        public int IdFireTruck { get; set; }
        public int IdAction { get; set; }
        public DateTime AssigmentDate { get; set; }
        public virtual FireTruck FireTruck { get; set; }
        public virtual Action Action { get; set; }
    }
}
