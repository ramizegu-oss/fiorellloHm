using Microsoft.AspNetCore.Mvc;

namespace FiorelloHomeWork.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
