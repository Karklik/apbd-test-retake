using System.Collections.Generic;

namespace apbd_test_retake.Models
{
    public class FireTruck
    {
        public int IdFireTruck { get; set; }
        public string OperationalNumber { get; set; }
        public bool SpecialEquipment { get; set; }
        public virtual ICollection<FireTruckAction> FireTruckActions { get; set; }
    }
}
