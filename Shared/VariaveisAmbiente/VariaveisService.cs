using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.VariaveisAmbiente
{
    public class VariaveisService : IVariaveisService
    {
        private readonly Variaveis _variaveis;

        public VariaveisService(IOptions<Variaveis> variaveis)
        {
            _variaveis = variaveis.Value;
        }

        public Task<Variaveis> BuscarVariaveisAmbiente()
        {
            Variaveis variaveis = new()
            {
                ChaveToken = _variaveis.ChaveToken,
                IssuerToken = _variaveis.IssuerToken,
                AudienceToken = _variaveis.AudienceToken
            };

            return Task.FromResult(variaveis);
        }
    }
}
