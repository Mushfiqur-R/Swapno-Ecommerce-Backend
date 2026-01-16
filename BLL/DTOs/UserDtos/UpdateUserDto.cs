using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.UserDtos
{

        public class UpdateUserDto
        {
            public string? Name { get; set; }
            public string? PhoneNumber { get; set; }
            public int? RoleId { get; set; }
        }

    }

