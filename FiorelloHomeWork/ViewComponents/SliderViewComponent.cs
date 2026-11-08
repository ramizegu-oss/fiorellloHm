using FiorelloHomeWork.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloHomeWork.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        readonly ISliderService _sliderService;
        public SliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders = await _sliderService.GetAllAsync();
            return View(sliders);
        }
    }
}
