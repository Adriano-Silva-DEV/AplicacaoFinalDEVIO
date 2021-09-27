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
  public  class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {

     public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorForncedor(Guid FornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == FornecedorId);
        }
    }
}
