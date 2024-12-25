using Entities.Dtos.Input.CredenciaisUsuario;
using Entities.Dtos.Input.Usuario;
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
    public interface IOrquestraUsuarioCredenciaisService
    {
        Task<ResponseModel<Usuario>> CriaUsuarioEhCredenciais(UsuarioEhCredenciaisDto usuarioEhCredenciais);
        Task<ResponseModel<UsuarioAutenticadoDto>> AutenticarUsuario(CredenciaisUsuarioDto credenciaisUsuarioDto);
    }
}
