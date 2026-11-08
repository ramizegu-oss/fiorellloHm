using Microsoft.AspNetCore.Mvc;

namespace FiorelloHomeWork.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
