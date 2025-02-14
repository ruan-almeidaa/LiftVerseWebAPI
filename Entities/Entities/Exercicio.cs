using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Exercicio
    {
        public int Id { get; set; }
        public int GrupoMuscularId { get; set; }
        public required string Titulo { get; set; }
        public List<VariacaoExercicio>? Variacoes { get; set; }
        [MaxLength(2048)]
        public string? Gif { get; set; }



        public GrupoMuscular? GrupoMuscular { get; set; }

    }
}
