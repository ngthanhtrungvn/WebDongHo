//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DuAnWebsite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAP()
        {
            this.CHITIETNHAPs = new HashSet<CHITIETNHAP>();
        }
    
        public int MAN { get; set; }
        public Nullable<System.DateTime> NGAYNHAP { get; set; }
        public Nullable<decimal> TONGTIEN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETNHAP> CHITIETNHAPs { get; set; }
    }
}