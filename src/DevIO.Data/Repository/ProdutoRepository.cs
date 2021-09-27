using DevIO.Bussines.Interfaces;
using DevIO.Bussines.Models;
using DevIO.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context)
        {

        }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(prop => prop.Id == id);
                
        }

        public async Task<IEnumerable<Produto>> ObterProdutosForncedores()
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
               .OrderBy(p => p.Nome).ToListAsync();

        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorID)
        {

            return await Buscar(p => p.FornecedorId == fornecedorID);
        }
    }
}
