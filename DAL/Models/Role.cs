using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Role
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Column(TypeName="VARCHAR(50)")]
        public string Name { get; set; } = null!;

    }
}
