using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Input.VariacaoExercicio
{
    public class VariacaoExercicioCriarDto
    {
        public required string Titulo { get; set; }
        public int ExercicioId { get; set; }
        [MaxLength(2048)]
        public string? Gif { get; set; }
    }
}
