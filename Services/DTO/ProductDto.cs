using BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please select category")]
        [Display(Name = "Category Name")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(100, ErrorMessage = "Product Name cannot exceed 100 characters.")]
        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [StringLength(50, ErrorMessage = "Weight cannot exceed 50 characters.")]
        public string? Weight { get; set; }

        [Required(ErrorMessage = "Unit Price is required")]
        [DataType(DataType.Currency)]
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }

        [Required(ErrorMessage = "Units In Stock is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Units in stock cannot be negative.")]
        [Display(Name = "Units in Stock")]
        public int UnitsInStock { get; set; }

        [Required(ErrorMessage = "Image Url is required")]
        [Url(ErrorMessage = "Invalid URL format.")]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Discount is required")]
        [Range(0.0, 1.0, ErrorMessage = "Discount must be between 0.0 and 1.0.")]
        public double Discount { get; set; }
        public virtual Category? Category { get; set; }
        public string? CategoryName { get; set; }
    }
}
