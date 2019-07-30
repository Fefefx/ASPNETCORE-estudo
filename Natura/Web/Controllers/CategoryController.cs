using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NaturaData;
using NaturaDomain.Model;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly NaturaContext _context;
        public CategoryController(NaturaContext context){
            _context = context;
        }
        public IActionResult Index(){
            var categories = _context.categories
                .ToList()
                .OrderBy(c => c.name);
            if(!categories.Any())
                return View(new List<Category>());
            return View(categories);
        }
        [HttpGet]
        public IActionResult Save(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(Category category){
            if(category.id == 0)
                _context.categories.Add(category);
            else{
                var oldCategory = _context.categories.First(c => c.id == category.id);
                oldCategory.name = category.name;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id){
            var category = _context.categories.First(c => c.id == id);
            return View("Save",category);
        }
        public async Task<IActionResult> Delete(int id){
            var category = _context.categories.First(c => c.id == id);
            _context.categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}