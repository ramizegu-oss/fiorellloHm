using FiorelloHomeWork.ViewModels.Category;
using FiorelloHomeWork.ViewModels.Flower;

namespace FiorelloHomeWork.ViewModels
{
    public class CategoryProductVM
    {
        public IEnumerable<FlowerUIVM> Flowers { get; set; }
        public IEnumerable<CategoryUIVM> Categories { get; set; }
    }
}
