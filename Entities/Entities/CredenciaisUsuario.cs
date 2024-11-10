﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class CredenciaisUsuario
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required PerfilUsuario PerfilUsuario { get; set; }
    }
}
