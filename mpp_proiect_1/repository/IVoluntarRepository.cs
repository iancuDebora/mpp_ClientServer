﻿using mpp_proiect_1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.repository
{
    interface IVoluntarRepository : ICrudRepository<int,Voluntar>
    {
        Voluntar findBy(int id, String parola);
    }
}
