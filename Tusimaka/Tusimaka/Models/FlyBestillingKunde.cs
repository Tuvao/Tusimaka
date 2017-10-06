using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tusimaka.Models
{
    public class FlyBestillingKunde
    {
        [Key]
        public int FlyBestillingsKundeID { get; set; }
        public int FlyBestillingsID { get; set; }
        public int KundeID { get; set; }

        //public virtual Kunde Kunde { get; set; }
        //public virtual FlyBestillinger FlyBestillinger { get; set; }
    }
}