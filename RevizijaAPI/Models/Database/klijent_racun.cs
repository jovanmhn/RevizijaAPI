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
    
    public partial class klijent_racun
    {
        public byte id_racun { get; set; }
        public int id_klijent { get; set; }
        public byte id_banka { get; set; }
        public string broj { get; set; }
        public bool is_devizni { get; set; }
        public byte order_id { get; set; }
    
        public virtual banka banka { get; set; }
        public virtual klijent klijent { get; set; }
    }
}
