using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UsuarioEhCredenciais
    {
        public required string Nickname { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public string? Foto { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
