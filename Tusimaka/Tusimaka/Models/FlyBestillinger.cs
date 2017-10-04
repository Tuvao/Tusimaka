using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tusimaka.Models
{
    public class FlyBestillinger
    {
        public int id { get; set; }
        public int strekningid { get; set; }
        
        public int Kundeid { get; set; }

        public strekning strekning { get; set; }
        public Kunde Kunde { get; set; }

    }
}