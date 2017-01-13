using System;

namespace IHFF.Models
{
    public class Times
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Location { get; set; }
        public DayOfWeek day { get; set; }
    }
}