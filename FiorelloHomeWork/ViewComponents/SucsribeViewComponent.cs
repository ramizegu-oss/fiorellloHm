
using Microsoft.AspNetCore.Mvc;

namespace FiorelloHomeWork.ViewComponents
{
    public class SucsribeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
