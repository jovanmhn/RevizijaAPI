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
    
    public partial class izvjestaj_dnevnik_def
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public izvjestaj_dnevnik_def()
        {
            this.izvjestaj_arhiva_dnevnik = new HashSet<izvjestaj_arhiva_dnevnik>();
        }
    
        public int id_dnevnik_def { get; set; }
        public string id_dnevnik { get; set; }
        public string id_izvjestaj { get; set; }
        public string naziv { get; set; }
        public string info1 { get; set; }
        public string info2 { get; set; }
        public string computed { get; set; }
        public bool style_bold { get; set; }
        public string lang_naziv { get; set; }
        public string lang_info1 { get; set; }
    
        public virtual izvjestaj izvjestaj { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<izvjestaj_arhiva_dnevnik> izvjestaj_arhiva_dnevnik { get; set; }
    }
}
