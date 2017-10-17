using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public class BetalingBLL
    {
        public bool lagreBetalingsinformasjon(BetalingsInformasjon innBetaling)
        {
            var BetalDAL = new BetalingDAL();
            return BetalDAL.lagreBetalingsinformasjon(innBetaling);
        }
    }
}
