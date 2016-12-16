using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class ReservationVm:OrderVm
    {
        public DateTime Date { get; set; }
=======

namespace IHFF.Models
{
    public class ReservationVm:ProductVm
    {
        public DateTime ReservationTime { get; set; }
        public string Comment { get; set; }
>>>>>>> refs/remotes/origin/master
    }
}