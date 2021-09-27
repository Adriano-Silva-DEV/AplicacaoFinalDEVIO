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
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
      
        public FornecedorRepository(MeuDbContext context) : base(context) { }


        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async  Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            //include os produtos e o endereço do id especificado

            return await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
