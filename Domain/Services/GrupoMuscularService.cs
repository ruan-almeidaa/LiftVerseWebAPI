using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GrupoMuscularService : IGrupoMuscularService
    {
        private readonly IGrupoMuscularRepository _grupoMuscularRepository;
        public GrupoMuscularService(IGrupoMuscularRepository grupoMuscularRepository)
        {
            _grupoMuscularRepository = grupoMuscularRepository;
        }
        public async Task<GrupoMuscular> BuscarPorId(int id)
        {
           return await _grupoMuscularRepository.BuscarPorId(id);
        }
    }
}
