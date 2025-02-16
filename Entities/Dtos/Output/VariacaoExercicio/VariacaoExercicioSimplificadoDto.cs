using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Output.VariacaoExercicio
{
    public class VariacaoExercicioSimplificadoDto
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        [MaxLength(2048)]
        public string? Gif { get; set; }
    }
}
