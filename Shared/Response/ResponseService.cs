using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Response
{
    public static class ResponseService
    {
        public static ResponseModel<T> CriarResponse<T>(T? dados, string mensagem = "Ok", bool status = true)
        {
            return new ResponseModel<T>
            {
                Dados = dados,
                Mensagem = mensagem,
                Status = status
            };
        }
    }
}
