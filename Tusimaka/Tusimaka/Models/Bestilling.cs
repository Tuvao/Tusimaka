using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tusimaka.Models
{
    public class Bestilling
    {
        public int id { get; set; }

        [Display(Name = "Fra sted")]
        [Required(ErrorMessage = "Fra-sted må oppgis")]
        public string FraSted { get; set; }

        [Display(Name = "Til sted")]
        [Required(ErrorMessage = "Til-sted må oppgis")]
        public string TilSted { get; set; }

        [Display(Name = "Fra dato")]
        [Required(ErrorMessage = "Fra-dato må oppgis")]
        public string FraDato { get; set; }

        [Display(Name = "Til dato")]
        [Required(ErrorMessage = "Til-dato må oppgis")]
        //[RegularExpression(@"[0-9]{4}", ErrorMessage = "Postnr må være 4 siffer")]
        public string TilDato { get; set; }

        [Display(Name = "Voksne")]
        [Required(ErrorMessage = "Du må velge minst én voksen")]
        public string Voksne { get; set; }

        [Display(Name = "Barn")]
        public string Barn { get; set; }
    
}
}