using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        // 1. Factory ডিক্লেয়ার
        private readonly DataAccessFactory _factory;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;

        // কনস্ট্রাক্টর
        public ProductService(DataAccessFactory factory, IMapper mapper)
        {
            _factory = factory; // 2. Factory ইনিশিয়ালাইজ
            _mapper = mapper;
            _emailService = new EmailService();
        }

        // ✅ Create Product
        public async Task<ProductDto> CreateProductAsync(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            product.Status = ProductStatus.Active;

            // 🔥 পরিবর্তন: _repo এর বদলে _factory.ProductData()
            var created = await _factory.ProductData().CreateAsync(product);

            return _mapper.Map<ProductDto>(created);
        }

        // ✅ Update Product
        public async Task<ProductDto> UpdateProductAsync(int id, ProductDto dto)
        {
            // 🔥 পরিবর্তন: _factory.ProductData() ব্যবহার করা হয়েছে
            var dbProduct = await _factory.ProductData().GetAsync(id);

            if (dbProduct == null) return null;

            // ডেটা আপডেট
            dbProduct.Name = dto.Name;
            dbProduct.Price = dto.Price;
            dbProduct.Quantity = dto.Quantity;
            dbProduct.ExpiryDate = dto.ExpiryDate;

            // Workflow Logic
            if (dbProduct.Quantity <= 0)
            {
                dbProduct.Status = ProductStatus.OutOfStock;
            }
            else
            {
                dbProduct.Status = ProductStatus.Active;
            }

            // Email Notification Logic
            if (dbProduct.Quantity < 10 && dbProduct.Quantity > 0)
            {
                if (dbProduct.Vendor != null)
                {
                    var email = dbProduct.Vendor.Email;
                    var subject = $"Low Stock Warning: {dbProduct.Name}";
                    var body = $"Alert! Only {dbProduct.Quantity} items left.";

                    _emailService.SendLowStockAlert(email, subject, body);
                }
            }

           
            var updated = await _factory.ProductData().UpdateAsync(dbProduct);

            return _mapper.Map<ProductDto>(updated);
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
   
            var data = await _factory.ProductData().GetAllAsync();
            return _mapper.Map<List<ProductDto>>(data);
        }

        public async Task<List<ProductDto>> SearchAsync(string name, double? min, double? max)
        {
          
            var data = await _factory.ProductData().SearchAsync(name, min, max);
            return _mapper.Map<List<ProductDto>>(data);
        }

        public async Task<List<ProductDto>> GetExpiryReportAsync()
        {
            // Factory দিয়ে Repo এর স্পেশাল মেথড কল করা হচ্ছে
            var data = await _factory.ProductData().GetExpiringProductsAsync();

            // DTO তে কনভার্ট করে রিটার্ন
            return _mapper.Map<List<ProductDto>>(data);
        }
    }
}