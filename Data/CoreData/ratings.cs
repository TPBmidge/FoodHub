//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodHub.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ratings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ratings()
        {
            this.books = new HashSet<books>();
        }
    
        public int ratingID { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public Nullable<int> rating { get; set; }
        public Nullable<int> authorID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<books> books { get; set; }
        public virtual users users { get; set; }
    }
}
