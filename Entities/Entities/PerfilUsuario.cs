using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class PerfilUsuario
    {
        public int Id { get; set; }
        public required string Usuario { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Foto { get; set; }
    }
}
