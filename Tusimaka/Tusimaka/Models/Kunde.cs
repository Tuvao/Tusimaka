using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tusimaka.Models
{
    public class Kunde
    {
        public int Id { get; set; } 
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Kjonn { get; set; }
        public string Type { get; set; }
    }
}