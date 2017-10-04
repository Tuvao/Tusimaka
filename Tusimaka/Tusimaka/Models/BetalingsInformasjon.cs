using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tusimaka.Models
{
    public class BetalingsInformasjon
    {
        public int id { get; set; }
        public string kortnummer { get; set; }
        public string utløpsdato { get; set; }
        public string cvc { get; set; }
    }
}