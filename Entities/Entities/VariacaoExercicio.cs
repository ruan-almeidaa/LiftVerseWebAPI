using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class VariacaoExercicio
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public int ExercicioId { get; set; }
    }
}
