<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public abstract class OrderVm
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
=======
﻿using System.Collections.Generic;

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
>>>>>>> refs/remotes/origin/master
    }
}