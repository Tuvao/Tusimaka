using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tusimaka.Model
{
    public class KundeBestillinger
    {
        public int KundeID { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public int StrekningsID { get; set; }
        public string FraFlyplass { get; set; }
        public string TilFlyplass { get; set; }
        public string Dato { get; set; }
        public string Tid { get; set; }
        public int Pris { get; set; }
        public int AntallPersoner { get; set; }
        public string Kortnummer { get; set; }
        public string Korttype { get; set; }

    }
}
