//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IHFF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            this.EventTimes = new HashSet<EventTime>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Streetnumber { get; set; }
        public int Contact { get; set; }
        public int Type { get; set; }
<<<<<<< HEAD
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventTime> EventTimes { get; set; }
        public virtual LocationType LocationType { get; set; }
=======
>>>>>>> refs/remotes/origin/master
    }
}
