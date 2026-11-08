using FiorelloHomeWork.Services.Interfaces;
using FiorelloHomeWork.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloHomeWork.ViewComponents
{
    public class CardsViewComponent : ViewComponent
    {
        private readonly IFlowerService _flowerService;
        private readonly ICategoryService _categoryService;
        public CardsViewComponent(IFlowerService flowerService, ICategoryService categoryService)
        {
            _flowerService = flowerService;
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var flowers = await _flowerService.GetAllFlowers();
            var categories = await _categoryService.GetAllUIAsync();

            CategoryProductVM model = new();
            model.Flowers = flowers;
            model.Categories = categories;

            return View(model);
        }
    }
}
