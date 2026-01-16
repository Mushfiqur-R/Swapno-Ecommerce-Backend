using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "VARCHAR(50)")]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR(100)")]
        public string Email { get; set; } = null!;

        [Required]
        [Phone] // Validation: phone format
        [StringLength(20)]
        [Column(TypeName = "VARCHAR(20)")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string Password { get; set; } = null!;

        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

    }
}
