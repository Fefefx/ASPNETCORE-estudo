using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _contexto;
        public ProdutoController(ApplicationDbContext contexto){
            _contexto = contexto;
        }
        [HttpGet]
        public IActionResult Salvar(){
            ViewBag.Categorias = _contexto.Categorias.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Salvar(Produto modelo){
            if(modelo.Id == 0)
                _contexto.Produtos.Add(modelo);
            else{
                var produto = _contexto.Produtos.First(p => p.Id == modelo.Id);
                produto.Nome = modelo.Nome;
                produto.CategoriaId = modelo.CategoriaId;
                produto.Ativo = modelo.Ativo;
            }
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index(){
            /*
            //Sem Lazing Load
            //var produtos = _contexto.Produtos.Include(p => p.Categoria).ToList();
            //Com Lazing Load
            var produtos = _contexto.Produtos.ToList();
            return View(produtos);
            */
            var queryDeprodutos = _contexto.Produtos
                .Where(p => p.Ativo && p.Categoria.PermiteEstoque)
                .OrderBy(p=> p.Nome);
            if(!queryDeprodutos.Any())
                return View(new List<Produto>());
            return View(queryDeprodutos.ToList());
        }

        [HttpGet]
        public IActionResult Editar(int id){
            var produto = _contexto.Produtos.First(p => p.Id == id);
            ViewBag.Categorias = _contexto.Categorias.ToList();
            return View("Salvar",produto);
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(int id){
            var produto = _contexto.Produtos.First(p => p.Id == id);
            _contexto.Produtos.Remove(produto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}