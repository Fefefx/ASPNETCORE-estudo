using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NaturaData;
using NaturaDomain.Model;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly NaturaContext _context;

        public ProductController(NaturaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.products
                .Include(p => p.Category)
                .ToList()
                .OrderBy(p => p.name);
            if (!products.Any())
                return View(new List<Product>());
            return View(products);
        }

        [HttpGet]
        public IActionResult Save()
        {
            ViewBag.categories = _context.categories.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(Product product)
        {
            if (product.id == 0)
                _context.products.Add(product);
            else
            {
                var oldProduct = _context.products.First(p => p.id == product.id);
                oldProduct.name = product.name;
                oldProduct.Categoryid = product.Categoryid;
                oldProduct.size = product.size;
                oldProduct.unity = product.unity;
                oldProduct.amount = product.amount;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _context.products.First(p => p.id == id);
            ViewBag.categories = _context.categories.ToList();
            return View("Save", product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = _context.products.First(p => p.id == id);
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}