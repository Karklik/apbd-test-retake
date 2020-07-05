using System;

namespace apbd_test_retake.DTOs
{
    public class GetActionsResponse
    {
        public int IdAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
