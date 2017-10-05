using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tusimaka.Models
{
    public class BetalingsInformasjon
    {
        [Key]
        public int BestillingsID { get; set; }
        public int FlyBestillingsID { get; set; }
        [Display(Name = "Kortnummer")]
        [Required(ErrorMessage = "Kortnummeret må oppgis!")]
        [RegularExpression(@"[0-9]{16}", ErrorMessage = "Kortnummeret må bestå av 16 sifre.")]
        public string Kortnummer { get; set; }
        [Display(Name = "Utlopsmaaned")]
        [Required(ErrorMessage = "Utlopsmaaned må oppgis!")]
        [RegularExpression(@"[0-9]{2}", ErrorMessage = "Utlopsmaaned må bestå av 2 sifre.")]
        public string Utlopsmnd { get; set; }
        [Display(Name = "Utlopsaar")]
        [Required(ErrorMessage = "Utlopsaar må oppgis!")]
        [RegularExpression(@"[0-9]{2}", ErrorMessage = "Utlopsaar må bestå av 2 sifre.")]
        public string Utlopsaar { get; set; }
        [Display(Name = "CVC")]
        [Required(ErrorMessage = "CVC må oppgis!")]
        [RegularExpression(@"[0-9]{3}", ErrorMessage = "CVC må bestå av 3 sifre.")]
        public string CVC { get; set; }
        [Display(Name = "Korttype")]
        [Required(ErrorMessage = "Korttype må velges!")]
        public string Korttype { get; set; }
    }
}