using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Input.VariacaoExercicio
{
    public class VariacaoExercicioCriarDto
    {
        public required string Titulo { get; set; }
        public int ExercicioId { get; set; }
    }
}
