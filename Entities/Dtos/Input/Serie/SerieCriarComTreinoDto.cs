using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Input.Serie
{
    public class SerieCriarComTreinoDto
    {
        public int ExercicioId { get; set; }
        public int? VariacaoExercicioId { get; set; }
        public int? Repeticoes { get; set; }
        public float? Peso { get; set; }
        public string? Observacao { get; set; }
    }
}
