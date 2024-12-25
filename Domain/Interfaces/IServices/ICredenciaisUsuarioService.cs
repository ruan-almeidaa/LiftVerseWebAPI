using Entities.Dtos.Input.CredenciaisUsuario;
using Entities.Dtos.Output.Usuario;
using Entities.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface ICredenciaisUsuarioService
    {
        Task<bool> VerificaSeExisteEmail(string email);
        Task<CredenciaisUsuario> CriarCredenciaisUsuario(CredenciaisUsuario credenciaisUsuario);
        Task<UsuarioAutenticadoDto>AutenticarUsuario(CredenciaisUsuarioDto credenciaisUsuarioDto);
    }
}
