using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Response
{
    public static class ResponseService
    {
        public static ResponseModel<T> CriarResponse<T>(T? dados, string mensagem = "Ok", HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            return new ResponseModel<T>
            {
                Dados = dados,
                Mensagem = mensagem,
                HttpStatusCode = httpStatusCode

            };
        }
    }
}
