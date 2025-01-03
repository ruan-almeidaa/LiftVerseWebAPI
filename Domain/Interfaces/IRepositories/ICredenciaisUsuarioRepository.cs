﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface ICredenciaisUsuarioRepository
    {
        Task<CredenciaisUsuario> CriarCredenciais(CredenciaisUsuario credenciaisUsuario);
        Task<bool> VerificaSeExisteEmail(string email);
        Task<CredenciaisUsuario> BuscaCredenciaisPorEmailSenha(string email, string senha);
    }
}
