using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF
{
    public class Payment
    {
        public  int Id { get; set; }
        public string PaymentOption { get; set; }
        public int products { get; set; }
        public int status { get; set; }
        public float total { get; set; }
    }
}