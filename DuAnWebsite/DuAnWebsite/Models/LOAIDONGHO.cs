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
    
    public partial class LOAIDONGHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIDONGHO()
        {
            this.DONGHOes = new HashSet<DONGHO>();
        }
    
        public string MALOAIDH { get; set; }
        public string TENLOAIDH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONGHO> DONGHOes { get; set; }
    }
}