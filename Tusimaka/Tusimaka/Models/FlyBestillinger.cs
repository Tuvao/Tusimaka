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
        public int StrekningsId { get; set; }
        public int AntallPersoner { get; set; }
        public int? ReturId { get; set; }


    }
}