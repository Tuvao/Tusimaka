﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tusimaka.Models
{
    public class strekning
    {
        public int id { get; set; }
        public string fraFlyplass { get; set; }
        public string tilFlyplass { get; set; }
        public string dato { get; set; }
        public string tid { get; set; }
        public string pris { get; set; }
        public int antallLedigeSeter { get; set; }
    }
}