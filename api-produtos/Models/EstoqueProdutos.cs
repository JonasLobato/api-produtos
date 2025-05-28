using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_produtos.Models
{
    public class EstoqueProdutos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
    }
}