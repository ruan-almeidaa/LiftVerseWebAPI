using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Output.VariacaoExercicio
{
    public class VariacaoExercicioSimplificadoDto
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
    }
}
