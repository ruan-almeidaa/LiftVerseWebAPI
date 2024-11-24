using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ExercicioFeito
    {
        public int Id { get; set; }
        public int TreinoId { get; set; }
        public int ExercicioId { get; set; }
        public int? VariacaoExercicioId { get; set; }
        public int? Series { get; set; }
        public int? Repeticoes { get; set; }
        public float? Peso { get; set; }
        public string? Observacao { get; set; }

        public Exercicio Exercicio { get; set; }
        public VariacaoExercicio? VariacaoExercicio { get; set; }
    }
}
