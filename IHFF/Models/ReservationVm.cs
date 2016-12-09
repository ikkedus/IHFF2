using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class ReservationVm:OrderVm
    {
        public DateTime Date { get; set; }
    }
}