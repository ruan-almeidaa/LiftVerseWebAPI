using Entities.Dtos.Input.ExercicioFeito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Input.Treino
{
    public class TreinoEditarDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public required string Titulo { get; set; }
        public required DateOnly Data { get; set; }
        public List<ExercicioFeitoEditarDto>? ExerciciosFeitos { get; set; }
    }
}
