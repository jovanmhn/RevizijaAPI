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
    
    public partial class revizorski_tim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public revizorski_tim()
        {
            this.klijent = new HashSet<klijent>();
            this.klijent1 = new HashSet<klijent>();
            this.klijent2 = new HashSet<klijent>();
            this.operater = new HashSet<operater>();
            this.operater1 = new HashSet<operater>();
        }
    
        public int id_revizorski_tim { get; set; }
        public int id_funkcija { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string licenca_dms { get; set; }
        public byte[] potpis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<klijent> klijent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<klijent> klijent1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<klijent> klijent2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<operater> operater { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<operater> operater1 { get; set; }
        public virtual tim_funkcija tim_funkcija { get; set; }
    }
}
