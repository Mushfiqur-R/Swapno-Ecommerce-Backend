namespace BLL.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }


        public int VendorId { get; set; }
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
        public string? VendorName { get; set; }
        public string? VendorEmail { get; set; }
        public string? RemainingTime { get; set; }
    }
}