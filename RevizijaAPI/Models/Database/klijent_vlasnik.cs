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
    
    public partial class klijent_vlasnik
    {
        public byte id_vlasnik { get; set; }
        public int id_klijent { get; set; }
        public int id_tip { get; set; }
        public string naziv { get; set; }
        public string maticni { get; set; }
        public bool is_foreign { get; set; }
        public decimal procenat { get; set; }
        public Nullable<byte> id_drzava { get; set; }
        public string opstina { get; set; }
        public string mjesto { get; set; }
        public string adresa { get; set; }
        public string br_dok { get; set; }
    
        public virtual drzava drzava { get; set; }
        public virtual klijent klijent { get; set; }
        public virtual klijent_tip klijent_tip { get; set; }
    }
}
