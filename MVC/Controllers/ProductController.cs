using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    //Define-se a roda da api
    [Route("api/product")]
    public class ProductController : Controller
    {
        //Mapeia o parâmetro da url para a propriedade id do método
        /*[HttpGet("{id:int}")]
        public int Get(int id){
            return id;
        }*/
        /* public string Get(){
           //Retorna o caminho da url que o usuário está acessando
           // return HttpContext.Request.Path;
           //Permite capturar valores da URL
           return HttpContext.Request.Query["param"];
        }*/
        public IActionResult Get(){
            //Define o código da resposta
            //HttpContext.Response.StatusCode = 404;
            //Define o cabeçalho da requisição
            HttpContext.Response.Headers.Add("ResponseHeader","my response");
            //Retorna um conteúdo do tipo pdf
            //return Content("aaa","application/pdf");
            //Retorna um elemento svg
            return File("images/Tux.svg","image/svg+xml");
        }
    }
}