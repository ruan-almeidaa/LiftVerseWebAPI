using Entities.Dtos.Output.Serie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Output.Treino
{
    public class TreinoDetalhadoDto
    {
        public int UsuarioId { get; set; }
        public required string Titulo { get; set; }
        public required DateOnly Data { get; set; }
        public List<SerieDetalhadoDto>? Series { get; set; }
    }
}
