using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class RoleDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
