//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace altinsofra
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderCart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderCart()
        {
            this.Ordereds = new HashSet<Ordered>();
        }
    
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> time { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordered> Ordereds { get; set; }
    }
}