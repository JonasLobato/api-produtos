using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_produtos.db;
using api_produtos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace api_produtos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class produto : Controller
    {
        public static List<EstoqueProdutos> estoqueProdutos = dbFalso.geradorFalso(10);
        public IActionResult ListarProdutos()
        {
            return Json(estoqueProdutos);
        }
        [HttpGet("{Id}")]
        public IActionResult UmItem(int Id)
        {
            var ItemFiltrado = estoqueProdutos.FirstOrDefault(x => x.Id == Id);
            if (ItemFiltrado == null)
            {
                return NotFound();
            }
            return Json(ItemFiltrado);
        }
        [HttpGet]
        [Route("/api/produto/filtro/{Nome}")]
        public IActionResult Filtro(string Nome)
        {
            // a função recebe o nome 
            // 1- procurar por nome dentro da lista
            var ItemFiltradoPorNome = estoqueProdutos.Where(x => x.Nome.ToUpper().Contains(Nome.ToUpper()));
            // 
            // 2 uma nova listas com os nomes parecidos
            // 3 retornar essa lista
            return Json(ItemFiltradoPorNome);
        }
        [HttpPost]
        public IActionResult AdicionarItem(EstoqueProdutos ItemNovo)
        {
            estoqueProdutos.Add(ItemNovo);
            return Created();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var ItemFiltrado = estoqueProdutos.FirstOrDefault(x => x.Id == Id);
            if (ItemFiltrado == null)
            {
                return NotFound("Não existe");
            }
            estoqueProdutos.Remove(ItemFiltrado);
            return Ok("Este item foi deletado!");
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, EstoqueProdutos Editar)
        {
            var ItemFiltrado = estoqueProdutos.FirstOrDefault(x => x.Id == Id);
            if (ItemFiltrado == null)
            {
                return NotFound("Não existe");
            }
            ItemFiltrado.Nome = Editar.Nome;
            ItemFiltrado.Preco = Editar.Preco;
            ItemFiltrado.Descricao = Editar.Descricao;
            return Created();
        }
    }
}