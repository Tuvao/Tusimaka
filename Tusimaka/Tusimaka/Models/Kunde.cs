using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tusimaka.Models
{
    public class Kunde
    {
        [Key]
        public int KundeID { get; set; }

        [Display(Name ="Fornavn")]
        [Required(ErrorMessage ="Fornavn må oppgis!")]
        [RegularExpression(@"[ÆØÅæøåA-Za-z]", ErrorMessage="Fornavn må bestå av bokstaver")] //må få til æøå
        public string Fornavn { get; set; }

        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppgis!")]
        [RegularExpression(@"[ÆØÅæøåA-Za-z]", ErrorMessage = "Etternavn må bestå av bokstaver")]  //må få til æøå
        public string Etternavn { get; set; }

        [Display(Name = "Kjonn")]
        [Required(ErrorMessage = "Kjønn må oppgis!")]
        public string Kjonn { get; set; }

        //public virtual FlyBestillingKunde FlyBestillingKunde { get; set; }

    }
}