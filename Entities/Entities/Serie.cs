using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Serie
    {
        public int Id { get; set; }
        public int TreinoId { get; set; }
        public int ExercicioId { get; set; }
        public int? VariacaoExercicioId { get; set; }
        public int? Repeticoes { get; set; }
        public float? Peso { get; set; }
        public string? Observacao { get; set; }

        public required Exercicio Exercicio { get; set; }
        public VariacaoExercicio? VariacaoExercicio { get; set; }
    }
}
