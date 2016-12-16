using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IHFF.Models
{
    public class OrderVm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Prefix { get; set; }
        [Required]
        public int PayemntMethod { get; set; }
        public List<ProductVm> products { get; set; }
        public string Email { get; internal set; }
    }
}