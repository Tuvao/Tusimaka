﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tusimaka.Model
{
    public class strekning
    {
        [Key]
        public int StrekningsID { get; set; }
        public string fraFlyplass { get; set; }
        public string tilFlyplass { get; set; }
        public string dato { get; set; }
        public string tid { get; set; }
        public string pris { get; set; }
        public int flyTid { get; set; }
        public int antallLedigeSeter { get; set; }
    }
}