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

    public partial class TBLUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLUser()
        {
            this.TBLBookings = new HashSet<TBLBooking>();
        }
    
        public int ID { get; set; }
        [DisplayName("User Name")]
        public string User_Name { get; set; }
        [DisplayName("Phone #")]
        public string User_Phone { get; set; }
        [DisplayName("Gender")]
        public string User_Gender { get; set; }
        [DisplayName("Address")]
        public string User_Address { get; set; }
        [DisplayName("Password")]
        public string User_Password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLBooking> TBLBookings { get; set; }
    }
}