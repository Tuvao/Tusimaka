﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;
using Tusimaka.BLL;

namespace Tusimaka.BLL
{
    public interface IAdminLogikk
    {
        bool Bruker_i_DB(AdminBruker innAdminBruker);
    }
}
