using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Bussines.Models
{
    public class Endereco : Entity
    {

        public Guid FornecedorId { get; set; }

        public String Logradouro { get; set; }

        public String Numero { get; set; }

        public String Complemento { get; set; }

        public String Cep { get; set; }

        public String Bairro { get; set; }

        public String Cidade { get; set; }

        public String Estado { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
