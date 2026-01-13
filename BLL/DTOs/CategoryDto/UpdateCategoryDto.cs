using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs.CategoryDto
{
    public  class UpdateCategoryDto
    {
         
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Description { get; set; }
    }
}

