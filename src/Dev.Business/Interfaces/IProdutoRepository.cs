using DevIO.Bussines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Bussines.Interfaces
{
  public  interface IProdutoRepository : IRepository<Produto>
    {

        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);

        Task<IEnumerable<Produto>> ObterProdutosForncedores();

        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}
