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
    
    public partial class izvjestaj_arhiva_dnevnik
    {
        public int id_dnevnik { get; set; }
        public int id_dnevnik_def { get; set; }
        public Nullable<decimal> vrijednost { get; set; }
        public int id_arhiva_dokument { get; set; }
        public Nullable<decimal> vrijednost_prethodna { get; set; }
    
        public virtual izvjestaj_arhiva_dokument izvjestaj_arhiva_dokument { get; set; }
        public virtual izvjestaj_dnevnik_def izvjestaj_dnevnik_def { get; set; }
    }
}
