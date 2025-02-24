using Entities.Dtos.Output.Serie;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface ISerieService
    {
        Task<bool> ExcluirSeriesTreino(int treinoId);
        Task<SerieDetalhadoDto>ConverteParaSerieDetalhado(Serie serie);
    }
}
