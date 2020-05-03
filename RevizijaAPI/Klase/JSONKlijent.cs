using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevizijaAPI.Klase
{
    public class JSONKlijent
    {
        public int id_klijent { get; set; }
        public string naziv { get; set; }
        public string PIB { get; set; }
        public string pdv { get; set; }
        public string direktor_ime { get; set; }
    }
}