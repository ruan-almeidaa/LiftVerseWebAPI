using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Input.CredenciaisUsuario
{
    public class CredenciaisUsuarioDto
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
