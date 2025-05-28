using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_produtos.Models;

namespace api_produtos.db
{
    public static class dbFalso
    {
        public static List<EstoqueProdutos> geradorFalso(int quantidade)
        {
            List<EstoqueProdutos> Lista = new List<EstoqueProdutos>();

            for (int i = 1; i <= quantidade; i++)
            {
                var NovoItem = new EstoqueProdutos()
                {
                    Id = i,
                    Nome = "ps2" + i,
                    Preco = 500,
                    Descricao = "Melhor console!" + i,
                };
                Lista.Add(NovoItem);
            }
            return Lista;
        }
    }
}