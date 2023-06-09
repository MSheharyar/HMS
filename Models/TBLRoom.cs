//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMS_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class TBLRoom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLRoom()
        {
            this.TBLBookings = new HashSet<TBLBooking>();
        }
    
        public int ID { get; set; }
        [DisplayName("Room #")]
        public string Room_Name { get; set; }
        [DisplayName("Category")]
        public Nullable<int> RoomCat { get; set; }
        public string Location { get; set; }
        public int Cost { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLBooking> TBLBookings { get; set; }
        public virtual TBLCategory TBLCategory { get; set; }
    }
}
