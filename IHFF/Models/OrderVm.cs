using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public abstract class OrderVm
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}