﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tusimaka.Models
{
    public class FlyBestillinger
    {
        [Key]
        public int FlyBestillingsID { get; set; }
        public int KundeID { get; set; }
        public int StrekningsID { get; set; }
        public int AntallPersoner { get; set; }
        public int? ReturID { get; set; }

        public virtual Kunde Kunde { get; set; }
        public virtual strekning Strekning { get; set; }
    }
}