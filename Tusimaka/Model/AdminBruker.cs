using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tusimaka.Model
{
    public class AdminBruker
    {
        [Required(ErrorMessage="Brukernavn må oppgis")]
        public string Brukernavn { get; set; }
        [Required(ErrorMessage="Passord må oppgis")]
        public string Passord { get; set; }
    }
}
