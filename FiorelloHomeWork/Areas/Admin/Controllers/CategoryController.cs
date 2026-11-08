using FiorelloHomeWork.Data;
using FiorelloHomeWork.Models;
using FiorelloHomeWork.Services.Interfaces;
using FiorelloHomeWork.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloHomeWork.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly AppDbContext _context;
        public CategoryController(ICategoryService category, AppDbContext appDb)
        {
            _categoryService = category;
            _context = appDb;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            Category res = new();
            res.Name = request.Name;
            await _context.Categories.AddAsync(res);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var res =await _context.Categories.FindAsync(id);
            CategoryEditVM category = new();
            category.Name = res.Name;
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,CategoryEditVM reguest)
        {
            var item = await _context.Categories.FindAsync(id);
            item.Name = reguest.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
