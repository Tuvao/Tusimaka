using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tusimaka.Model
{
    public class FlyBestillinger
    {
        [Key]
        public int FlyBestillingsID { get; set; }
        public int StrekningsID { get; set; }
        public int AntallPersoner { get; set; }
        public int? ReturID { get; set; }
    }
}