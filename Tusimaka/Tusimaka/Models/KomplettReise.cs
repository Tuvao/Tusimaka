using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tusimaka.Models
{
    public class KomplettReise
    {
        public int KundeID { get; set; }
        public int FlyBestillingsID { get; set; }

    }
}