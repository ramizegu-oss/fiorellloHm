using Microsoft.AspNetCore.Mvc;

namespace FiorelloHomeWork.ViewComponents
{
    public class DownSliderInstaViewComponent  : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
