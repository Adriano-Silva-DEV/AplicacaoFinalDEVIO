using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Bussines.Models
{
  public  class Produto : Entity
    {

      

        public Guid FornecedorId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public string Valor { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public Fornecedor Fornecedor { get; set; }

       //public IEnumerable<Fornecedor> Fornecedores { get; set; }
    }
}
