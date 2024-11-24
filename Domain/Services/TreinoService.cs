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
    public class TreinoService : ITreinoService
    {
        private readonly ITreinoRepository _treinoRepository;
        public TreinoService(ITreinoRepository treinoRepository)
        { 
            _treinoRepository = treinoRepository;
        }

        public async Task<Treino> CriarTreino(Treino treino)
        {
            return await _treinoRepository.CriarTreino(treino);
        }
    }
}
