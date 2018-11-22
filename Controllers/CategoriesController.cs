using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("categories")]
    public class CategoriesController : Controller
    {
        private readonly ShopContext _db;

        public CategoriesController(ShopContext db)
        {
            _db = db;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var categories = await _db.Categories.ToListAsync();

            return View(categories);
        }

        [Route("add")]
        [Route("{categoryId:int}/edit")]
        public async Task<IActionResult> Category(int? categoryId)
        {
            if (categoryId.HasValue)
            {
                var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
                return View(category);
            }

            return View();
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save(Category category)
        {
            if (category.Id == default(int))
            {
                _db.Categories.Add(category);
            }
            else
            {
                _db.Categories.Update(category);
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{categoryId:int}/remove")]
        public async Task<IActionResult> Remove(int categoryId){
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);

            if (category == null)
                return NotFound();

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
