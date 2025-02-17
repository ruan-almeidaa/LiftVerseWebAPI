using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Paginacao
{
    public class PaginacaoModel<T>
    {
        public List<T> Itens { get; set; } = new();
        public int TotalItensParaExibir { get; set; }
        public int NumeroPaginaAtual { get; set; }
        public int TotalPaginasParaExibir { get; set; }
    }
}
