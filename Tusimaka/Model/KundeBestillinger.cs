using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tusimaka.Model
{
    public class KundeBestillinger
    {
        public int KundeID { get; set; }

        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ ]{2,30}", ErrorMessage = "Fornavn må bestå av bokstaver")]
        public string Fornavn { get; set; }

        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ ]{2,30}", ErrorMessage = "Etternavn må bestå av bokstaver")]
        public string Etternavn { get; set; }

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

        [Display(Name = "AntallPersoner")]
        [Required(ErrorMessage = "Antall personer må oppgis")]
        [RegularExpression(@"[0-8]{1}", ErrorMessage = "Antall personer må være mellom 1 - 8")]
        public int AntallPersoner { get; set; }

        [Display(Name = "Kortnummer")]
        [Required(ErrorMessage = "Kortnummeret må oppgis")]
        [RegularExpression(@"[0-9]{16}", ErrorMessage = "Kortnummeret må bestå av 16 sifre.")]
        public string Kortnummer { get; set; }

        [Display(Name = "Korttype")]
        [Required(ErrorMessage = "Korttype må velges")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ ]{2,30}", ErrorMessage = "Korttype må bestå av bokstaver")]
        public string Korttype { get; set; }

    }
}
