﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;
using Tusimaka.DAL;

namespace Tusimaka.DAL
{
    public interface IAdminRepository
    {
        bool Bruker_i_DB(AdminBruker innAdminBruker);
    }
}
