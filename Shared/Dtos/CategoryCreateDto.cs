using System.ComponentModel.DataAnnotations;

namespace BlazorCRUDApp.Shared.Dtos
{
    public class CategoryCreateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [StringLength(100, ErrorMessage = "The name must be between 1 and 100 characters", MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
    }
}
