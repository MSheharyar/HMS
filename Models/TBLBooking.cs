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

    public partial class TBLBooking
    {
        public int ID { get; set; }
        [DisplayName("Booking Date")]
        public System.DateTime BDate { get; set; }
        [DisplayName("Room")]
        public Nullable<int> BRoom { get; set; }
        [DisplayName("User")]
        public Nullable<int> Agent { get; set; }
        [DisplayName("Date Check In")]
        public System.DateTime DateIn { get; set; }
        [DisplayName("Date Check Out")]
        public System.DateTime DateOut { get; set; }
        public int Amount { get; set; }
    
        public virtual TBLUser TBLUser { get; set; }
        public virtual TBLRoom TBLRoom { get; set; }
    }
}
