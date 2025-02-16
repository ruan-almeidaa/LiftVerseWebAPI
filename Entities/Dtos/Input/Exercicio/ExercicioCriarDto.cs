using Entities.Dtos.Input.VariacaoExercicio;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Input.Exercicio
{
    public class ExercicioCriarDto
    {
        public int GrupoMuscularId { get; set; }
        public required string Titulo { get; set; }
    }
}
