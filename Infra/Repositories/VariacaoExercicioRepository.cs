using Domain.Interfaces.IRepositories;
using Entities.Entities;
using Infra.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class VariacaoExercicioRepository : IVariacaoExercicioRepository
    {
        private readonly BancoContext _bancoContext;

        public VariacaoExercicioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<VariacaoExercicio> BuscarPorId(int idVariacao)
        {
            return await _bancoContext.VariacoesExercicios.FindAsync(idVariacao);
        }
    }
}
