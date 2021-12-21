using System.ComponentModel.DataAnnotations;

namespace G2G1FinalProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Enter Category Name")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

    }
}
