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
    
    public partial class izvjestaj_prethodni
    {
        public string id_izvjestaj { get; set; }
        public int godina { get; set; }
        public string id_dnevnik { get; set; }
        public Nullable<decimal> vrijednost { get; set; }
        public int id_klijent { get; set; }
    
        public virtual izvjestaj izvjestaj { get; set; }
        public virtual klijent klijent { get; set; }
    }
}