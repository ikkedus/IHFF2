using System;

namespace IHFF.Models
{
    public class ReservationVm:ProductVm
    {
        public DateTime ReservationTime { get; set; }
        public string Comment { get; set; }
    }
}