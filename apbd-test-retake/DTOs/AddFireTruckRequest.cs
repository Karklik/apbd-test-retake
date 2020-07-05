using System.ComponentModel.DataAnnotations;

namespace apbd_test_retake.DTOs
{
    public class AddFireTruckRequest
    {
        [Required]
        public int IdAction { get; set; }
        [Required]
        public int IdFireTruck { get; set; }
    }
}
