using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;   
        public string PhoneNumber { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
