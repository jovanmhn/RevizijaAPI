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
    
    public partial class mailacc
    {
        public int id_mailacc { get; set; }
        public int id_operater { get; set; }
        public string naziv { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool enablessl { get; set; }
        public int port { get; set; }
        public string host { get; set; }
    
        public virtual operater operater { get; set; }
    }
}
