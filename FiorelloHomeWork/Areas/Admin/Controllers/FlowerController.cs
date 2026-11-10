using FiorelloHomeWork.Data;
using FiorelloHomeWork.Models;
using FiorelloHomeWork.Services.Interfaces;
using FiorelloHomeWork.ViewModels.Flower;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloHomeWork.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class FlowerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IFlowerService _flowerService;
        public FlowerController(AppDbContext context, IFlowerService flowerService)
        {
            _context = context;
            _flowerService = flowerService;
        }
        public async Task<IActionResult> Index()
        {
            var flowers = await _flowerService.GetAllFlowers();
            return View(flowers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlowerCreateVM request)
        {
            Flower flower = new();
            flower.Name = request.Name;
            flower.Description = request.Description;
            flower.CategoryId = request.CategoryId;
            flower.Price = request.Price;

            await _context.Flowers.AddAsync(flower);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var res = await _context.Flowers.FindAsync(id);

            FlowerEditVM flower = new();
            flower.Description = res.Description;
            flower.Name = res.Name;
            flower.Price = res.Price;
            flower.CategoryId = res.CategoryId;
            return View(flower);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FlowerEditVM request)
        {
            var res = await _context.Flowers.FindAsync(id);
            res.Name = request.Name;
            res.Description = request.Description;
            res.CategoryId = request.CategoryId;
            res.Price = request.Price;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _context.Flowers.FindAsync(id);
            _context.Flowers.Remove(res);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            var res = await _context.Flowers.Include(m=> m.Category).Include(m=> m.FlowerComments).Include(m=> m.Images).FirstOrDefaultAsync(m=> m.Id == id);
            

            FlowerDetailUIVM flowerDetail = new();
            flowerDetail.Title = res.Name;
            flowerDetail.Description = res.Description;
            flowerDetail.Price = res.Price;
            flowerDetail.CategoryName = res.Category.Name;
            flowerDetail.FlowerImages = res.Images.Select(m => new LabFront.ViewModels.Product.FlowerImageUIVM
            {
                Name = m.Name,
                IsMane = m.IsMain
            });
            flowerDetail.FlowerComments = res.FlowerComments.Select(m => new ViewModels.UserComment.UserCommentUIVM
            {
                FullName = m.Name + " " + m.LastName,
                Description = m.Description,
                RateCount = m.RateCount
            });



            return View(flowerDetail);
        }

    }
}
