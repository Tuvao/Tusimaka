using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tusimaka.Models
{   //kvittering/bekreftelses modell
    public class KomplettReise
    {   //Id her = Referansenr. 
        public int Id { get; set; }
        public int KundeID { get; set; }
        public int FlyBestillingsID { get; set; }
        public int BetalingsID { get; set; }

        //public virtual Kunde Kunde { get; set; }
        //public virtual FlyBestillinger FlyBestillinger { get; set; }
        //public virtual BetalingsInformasjon BetalingsInformasjon { get; set; }
    }
}