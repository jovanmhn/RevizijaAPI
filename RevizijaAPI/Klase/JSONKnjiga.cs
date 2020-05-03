using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevizijaAPI.Klase
{
 
    public class JSONKnjiga
    {
        public int id { get; set; }
        public int godina { get; set; }
        public string opis { get; set; }
        public string klijent_naziv { get; set; }

    }
}