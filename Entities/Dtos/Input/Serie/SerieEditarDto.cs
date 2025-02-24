using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Input.Serie
{
    public class SerieEditarDto
    {
        public int Id { get; set; }
        public int TreinoId { get; set; }
        public int ExercicioId { get; set; }
        public int? VariacaoExercicioId { get; set; }
        public int? Repeticoes { get; set; }
        public float? Peso { get; set; }
        public string? Observacao { get; set; }
    }
}
