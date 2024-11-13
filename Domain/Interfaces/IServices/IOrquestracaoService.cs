using Entities.Dtos;
using Entities.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IOrquestracaoService
    {
        Task<ResponseModel<Usuario>> CriaUsuarioEhCredenciais(UsuarioEhCredenciais usuarioEhCredenciais);
    }
}
