namespace apbd_test_retake.Models
{
    public class FirefighterAction
    {
        public int IdFirefighter { get; set; }
        public int IdAction { get; set; }
        public virtual Firefighter Firefighter { get; set; }
        public virtual Action Action { get; set; }
    }
}
