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
        public int Id { get; set; }
        public int KundeId { get; set; }
        public int StrekningsId { get; set; }
        public int AntallPersoner { get; set; }
        public int? ReturId { get; set; }

        //public virtual Kunde Kunde { get; set; }
        //public virtual strekning Strekning { get; set; }
        //public virtual KomplettReise KomplettReise { get; set; }
    }
}