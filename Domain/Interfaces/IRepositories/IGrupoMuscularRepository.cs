﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface IGrupoMuscularRepository
    {
        Task<GrupoMuscular> BuscarPorId(int id);
    }
}
