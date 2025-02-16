using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Input.Exercicio
{
    public class ExercicioEditarDto
    {
        public int Id { get; set; }
        public int GrupoMuscularId { get; set; }
        public required string Titulo { get; set; }
    }
}
