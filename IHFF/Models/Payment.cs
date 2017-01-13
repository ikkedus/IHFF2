using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF
{
    public class Payment
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string Lastname { get; set; }
        public string PaymentOption { get; set; }
        public double Total { get; set; }
        public int products { get; set; }
        public int status { get; set; }
        public int OrderId { get; internal set; }
    }
}