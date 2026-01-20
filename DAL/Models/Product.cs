using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public static class ProductStatus
    {
        public const string Active = "Active";
        public const string OutOfStock = "OutOfStock";
        public const string Discontinued = "Discontinued";
    }

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime ExpiryDate { get; set; }


        [Column(TypeName = "VARCHAR(20)")]
        public string Status { get; set; } = ProductStatus.Active;

        // Foreign Keys
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public virtual User Vendor { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}