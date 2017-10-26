using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tusimaka.Model
{
    public class Strekning
    {
        [Key]
        public int StrekningsID { get; set; }

        [Display(Name = "fraFlyplass")]
        [Required(ErrorMessage = "Fra flyplass må oppgis")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ ]{1,30}", ErrorMessage = "Fra flyplass må bestå av bokstaver")]
        public string FraFlyplass { get; set; }

        [Display(Name = "tilFlyplass")]
        [Required(ErrorMessage = "Til flyplass må oppgis")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ ]{1,30}", ErrorMessage = "Til flyplass må bestå av bokstaver")]
        public string TilFlyplass { get; set; }

        [Display(Name = "dato")]
        [Required(ErrorMessage = "Dato må oppgis")]
        public string Dato { get; set; }

        [Display(Name = "tid")]
        [Required(ErrorMessage = "Tid må oppgis")]
        [RegularExpression(@"^(?:[01][0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Ugyldig tid")]
        public string Tid { get; set; }

        [Display(Name = "tilFlyplass")]
        [Required(ErrorMessage = "Pris må oppgis")]
        [RegularExpression(@"[0-9]{1,6}", ErrorMessage = "Pris må bestå av et positivt tall")]
        public int Pris { get; set; }

        [Display(Name = "flyTid")]
        [Required(ErrorMessage = "Flytid må oppgis")]
        [RegularExpression(@"[0-9]{1,6}", ErrorMessage = "Flytid må bestå av et positivt tall")]
        public double FlyTid { get; set; }

        [Display(Name = "antallLedigeSeter")]
        [Required(ErrorMessage = "Antall ledige seter må oppgis")]
        [RegularExpression(@"[0-9]{1,4}", ErrorMessage = "Antall ledige seter må bestå av tall")]
        public int AntallLedigeSeter { get; set; }

        public override string ToString()
        {
            //return String.Format(
            //    "{0:00}:{1:00}:{2:00}",
            //    this.Hours, this.Minutes, this.Seconds);
            var t = Math.Floor(FlyTid / 60);
            var m = FlyTid % 60;
            return t + "t " + m + "m";
        }
    }
}