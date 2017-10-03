﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tusimaka.Models
{
    public class Kunde
    {
        public int Id { get; set; }

        [Display(Name ="Fornavn")]
        [Required(ErrorMessage ="Fornavn må oppgis!")]
        [RegularExpression(@"[A-Z][a-z]", ErrorMessage="Fornavn må bestå av bokstaver")] //må få til æøå
        public string Fornavn { get; set; }

        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppgis!")]
        [RegularExpression(@"[A-Z][a-z]", ErrorMessage = "Etternavn må bestå av bokstaver")]  //må få til æøå
        public string Etternavn { get; set; }

        [Display(Name = "Kjonn")]
        [Required(ErrorMessage = "Kjønn må oppgis!")]
        public string Kjonn { get; set; }
    }
}