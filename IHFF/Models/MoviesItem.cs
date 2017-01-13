using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class MoviesItem
    {
        public int id { get; set; }
        public string title { get; set; }
        public string plot_EN { get; set; }
        public string plot_NL { get; set; }
        public string poster { get; set; }
        public DateTime start_Time { get; set; }
        public DateTime end_Time { get; set; }
        public int Eventid { get; set; }
        public int day { get; set; }
        public string name { get; set; }
        public List<Times> times { get; set; }
    }
}