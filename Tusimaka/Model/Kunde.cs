using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tusimaka.Model
{
    public class Kunde
    {
        [Key]
        public int KundeID { get; set; }

        [Display(Name ="Fornavn")]
        [Required(ErrorMessage ="Fornavn må oppgis")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ ]{2,30}", ErrorMessage="Fornavn må bestå av bokstaver")]
        public string Fornavn { get; set; }
        
        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppgis")]
        [RegularExpression(@"[a-zæøåA-ZØÅ ]{1,30}", ErrorMessage = "Etternavn må bestå av bokstaver")]
        public string Etternavn { get; set; }

        [Display(Name = "Epost")]
        [Required(ErrorMessage = "E-post må oppgis")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Ugyldig epost-adresse")]
        public string Epost { get; set; }
        
        [Display(Name = "Kjonn")]
        [Required(ErrorMessage = "Kjønn må oppgis")]
        public string Kjonn { get; set; }

        public virtual FlyBestillingKunde FlyBestillingKunde { get; set; }

    }

    
}