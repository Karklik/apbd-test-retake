using System.Collections.Generic;

namespace apbd_test_retake.Models
{
    public class Firefighter
    {
        public int IdFirefighter { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<FirefighterAction> FirefighterActions { get; set; }
    }
}
