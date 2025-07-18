using System.ComponentModel.DataAnnotations;

namespace BlazorCRUDApp.Shared.Dtos
{
    public class ProductUpdateDto
    {
        [Required(ErrorMessage = "The Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; } = string.Empty;
        [Range(0.01, 1000000.00, ErrorMessage = "the price must be between 0.01 and 1,000,000")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The category is required")]
        public int CategoryId { get; set; }
    }
}