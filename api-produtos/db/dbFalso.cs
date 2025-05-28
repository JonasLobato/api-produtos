using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_produtos.Models;

namespace api_produtos.db
{
    public static class dbFalso
    {
        public static List<EstoqueProduto> geradorFalso(int quantidade)
        {
            List<EstoqueProduto> Lista = new List<EstoqueProduto>();

            for (int i = 1; i <= quantidade; i++)
            {
                var NovoItem = new EstoqueProduto()
                {
                    Id = i,
                    Nome = "ps2" + i,
                    Preco = 500,
                    Promocao = 0,
                    Parcelas = 0,
                    Descricao = "Melhor console!" + i,
                };
                Lista.Add(NovoItem);
            }
            return Lista;
        }
    }
}