using System.ComponentModel.DataAnnotations;

namespace FiorelloHomeWork.ViewModels.Category
{
    public class CategoryCreateVM
    {
        [Required]
        public string Name { get; set; }
    }
}
