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
        
        private readonly DataAccessFactory _factory;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;

        
        public ProductService(DataAccessFactory factory, IMapper mapper, EmailService emailService)
        {
            _factory = factory; 
            _mapper = mapper;
            _emailService =  emailService;
        }

        
        public async Task<ProductDto> CreateProductAsync(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            product.Status = ProductStatus.Active;

            
            var created = await _factory.ProductData().CreateAsync(product);

            return _mapper.Map<ProductDto>(created);
        }

        
        public async Task<ProductDto> UpdateProductAsync(int id, ProductDto dto)
        {
           
            var dbProduct = await _factory.ProductData().GetAsync(id);

            if (dbProduct == null) return null;

           
            dbProduct.Name = dto.Name;
            dbProduct.Price = dto.Price;
            dbProduct.Quantity = dto.Quantity;
            dbProduct.ExpiryDate = dto.ExpiryDate;

           
            if (dbProduct.Quantity <= 0)
            {
                dbProduct.Status = ProductStatus.OutOfStock;
            }
            else
            {
                dbProduct.Status = ProductStatus.Active;
            }

            
            if (dbProduct.Quantity < 10 && dbProduct.Quantity > 0)
            {
                if (dbProduct.Vendor != null)
                {
                    var email = dbProduct.Vendor.Email;
                    var subject = $"Low Stock Warning: {dbProduct.Name}";
                    var body = $"Alert! Only {dbProduct.Quantity} items left.please prepare your to delivery!";

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
         
            var data = await _factory.ProductData().GetExpiringProductsAsync();

            
            return _mapper.Map<List<ProductDto>>(data);
        }
    }
}