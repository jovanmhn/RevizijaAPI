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
    
    public partial class knjiga
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public knjiga()
        {
            this.dms_file = new HashSet<dms_file>();
            this.izvjestaj_arhiva_dokument = new HashSet<izvjestaj_arhiva_dokument>();
            this.knjiga_dnevnik = new HashSet<knjiga_dnevnik>();
        }
    
        public int id_knjiga { get; set; }
        public int id_klijent { get; set; }
        public int godina { get; set; }
        public Nullable<System.DateTime> datum_od { get; set; }
        public Nullable<System.DateTime> datum_do { get; set; }
        public string opis { get; set; }
        public Nullable<bool> is_locked { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dms_file> dms_file { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<izvjestaj_arhiva_dokument> izvjestaj_arhiva_dokument { get; set; }
        public virtual klijent klijent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<knjiga_dnevnik> knjiga_dnevnik { get; set; }
    }
}
