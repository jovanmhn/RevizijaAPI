//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RevizijaAPI.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class opstina
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public opstina()
        {
            this.klijent = new HashSet<klijent>();
            this.klijent1 = new HashSet<klijent>();
        }
    
        public short id_opstina { get; set; }
        public string naziv { get; set; }
        public int sifra { get; set; }
        public decimal prirez_stopa { get; set; }
        public string prirez_racun { get; set; }
        public string sifra_m4 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<klijent> klijent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<klijent> klijent1 { get; set; }
    }
}
