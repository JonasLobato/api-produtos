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
        public IActionResult ListarProdutos()
        {
            using (var db = new DbEstoqueContext())
            {
                return Json(db.EstoqueProdutos.ToList());
            }
        }
        [HttpPost]
        public IActionResult AdicionarProduto(EstoqueProduto ItemNovo)
        {
            using (var db = new DbEstoqueContext())
            {
                db.EstoqueProdutos.Add(ItemNovo);
                db.SaveChanges();
                return Created();
            }

        }

        [HttpDelete("{Id}")]
        public IActionResult RemoverProduto(int Id)
        {
            using (var db = new DbEstoqueContext())
            {
                var ItemFiltrado = db.EstoqueProdutos.FirstOrDefault(x => x.Id == Id);
                if (ItemFiltrado == null)
                {
                    return NotFound();
                }
                db.EstoqueProdutos.Remove(ItemFiltrado);
                db.SaveChanges();
                return Ok("Este item foi deletado");
            }

        }

        [HttpPut("{Id}")]
        public IActionResult Editar(int Id, EstoqueProduto Editar)
        {
            using (var db = new DbEstoqueContext())
            {
                var ItemFiltrado = db.EstoqueProdutos.FirstOrDefault(x => x.Id == Id);
                if (ItemFiltrado == null)
                {
                    return NotFound("Item não encontrado");
                }
                ItemFiltrado.Nome = Editar.Nome;
                ItemFiltrado.Preco = Editar.Preco;
                ItemFiltrado.Promocao = Editar.Promocao;
                ItemFiltrado.Parcelas = Editar.Parcelas;
                ItemFiltrado.Descricao = Editar.Descricao;
                db.SaveChanges();
                return Created();
            }

        }

        [HttpGet("{Id}")]
        public IActionResult UmItem(int Id)
        {
            using (var db = new DbEstoqueContext())
            {
                var ItemFiltrado = db.EstoqueProdutos.FirstOrDefault(x => x.Id == Id);
                if (ItemFiltrado == null)
                {
                    return NotFound();
                }
                return Json(ItemFiltrado);
            }

        }

        [HttpGet]
        [Route("/api/produto/filtro/{Nome}")]
        public IActionResult Filtro(string Nome)
        {
            using (var db = new DbEstoqueContext())
            {
                // a função recebe o Nome
                // 1- procurar por nome dentro da lista
                var ItemFiltradoPorNome = db.EstoqueProdutos.Where(x => x.Nome.ToUpper().Contains(Nome.ToUpper()));
                // 2 uma nova listas com os nomes parecidos
                // 3 retornar essa lista
                return Json(ItemFiltradoPorNome.ToList());
            }

        }
    }
}