﻿using mpp_proiect_1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.repository
{
    interface ICazCaritabilRepository : ICrudRepository<int,CazCaritabil>
    {
        void update2(CazCaritabil caz);
    }
}
