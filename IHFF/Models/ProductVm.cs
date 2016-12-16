using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class ProductVm
    {
        public int ProductId { get; set; }

        public string Title { get; set; }

        public string Poster { get; set; }

        public string Description { get; set; }
        public int Attendanties { get; set; }

        public DateTime Time { get; set; }
        public bool IsRestaurant { get; set; }
        public string Comment { get; internal set; }
    }
}