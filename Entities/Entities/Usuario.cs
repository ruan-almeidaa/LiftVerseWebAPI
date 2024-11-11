using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nickname { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Foto { get; set; }
    }
}
