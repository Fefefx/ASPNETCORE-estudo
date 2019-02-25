using Forms.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers
{
    public class ProductController : Controller
    {
        //Notação de método do protocolo Http
        [HttpGet]
        public IActionResult Save(){
            return View();
        }
        //Notação que especifica validação de segurança nas requisições
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Save(Product product){
            /*if (product.Id == 0 || string.IsNullOrEmpty(product.Name) || product.Price == 0){
                ViewBag.Validacao = "produto inválido para cadastro";
            }*/
            //Verifica se os valores das propriedades obedecem as regras das anotações
            if(!ModelState.IsValid){
                ViewBag.Validacao = "produto inválido para cadastro";
            }
            return View();
        }
    }
}