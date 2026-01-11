using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class CreateRoleDto
    {
        [Required]
        [MinLength(3,ErrorMessage ="Name should at least 3 charecter long")]
        public string Name { get; set; } = null!;
    }
}
