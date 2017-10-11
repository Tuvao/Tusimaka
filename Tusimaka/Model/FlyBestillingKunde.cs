using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tusimaka.Model
{
    //Kan fjernes??
    public class FlyBestillingKunde
    {
        //hjelpetabell for å koble flybestillingsID og kundeID
        [Key]
        public int FlyBestillingsKundeID { get; set; }
        public int FlyBestillingsID { get; set; }
        public int KundeID { get; set; }
        
    }
}