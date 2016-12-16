using System.Collections.Generic;

namespace IHFF.Models
{
    public class OrderVm
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Prefix { get; set; }
        public int PayemntMethod { get; set; }
        public List<ProductVm> products { get; set; }
        public string Email { get; internal set; }
    }
}