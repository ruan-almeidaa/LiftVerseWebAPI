using Entities.Dtos.Output.VariacaoExercicio;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Output.Exercicio
{
    public class ExercicioDetalhadoDto
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public List<VariacaoExercicioSimplificadoDto>? Variacoes { get; set; }
        public GrupoMuscular? GrupoMuscular { get; set; }



    }
}
