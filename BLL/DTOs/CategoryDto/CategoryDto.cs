using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.CategoryDto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
