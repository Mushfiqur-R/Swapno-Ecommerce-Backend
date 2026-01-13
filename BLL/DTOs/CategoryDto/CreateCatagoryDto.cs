using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs.CategoryDto
{
    public  class CreateCategoryDto
    {
        [Required]
        [MinLength(3,ErrorMessage ="Name length must be at least 3")]
        [MaxLength(50, ErrorMessage = "Name length cannot exceed 50")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(50, ErrorMessage = "Description should be within 50 charecter")]
        public string Description { get; set; } = null!; 
    }
}
