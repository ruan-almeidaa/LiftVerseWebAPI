using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Output.ExercicioFeito
{
    public class ExercicioFeitoDetalhadoDto
    {
        // Dados sobre o próprio exercicio feito
        public int Id { get; set; }
        public int TreinoId { get; set; }
        public int? Series { get; set; }
        public int? Repeticoes { get; set; }
        public float? Peso { get; set; }
        public string? Observacao { get; set; }
        // Dados sobre qual exercício foi feito
        public int ExercicioId { get; set; }
        public required string ExercicioTitulo { get; set; }
        // Dados sobre qual variação foi feita
        public int VariacaoExercicioId { get; set; }
        public string? VariacaoExerciciotitulo { get; set; }
    }
}