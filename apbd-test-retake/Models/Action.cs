using System;
using System.Collections.Generic;

namespace apbd_test_retake.Models
{
    public class Action
    {
        public int IdAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool NeedSpecialEquipment { get; set; }
        public virtual ICollection<FirefighterAction> FirefighterActions { get; set; }
        public virtual ICollection<FireTruckAction> FireTruckActions { get; set; }
    }
}
