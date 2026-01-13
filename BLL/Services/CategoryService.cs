using AutoMapper;
using BLL.DTOs.CategoryDto;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CategoryService
    {
        private readonly IMapper mapper;
        private readonly DataAccessFactory factory;
        public CategoryService(IMapper mapper, DataAccessFactory factory) 
        {
            this.mapper = mapper;
            this.factory = factory;
        }

           public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto)
        {
            var allCategories = await factory.CategoryData().GetAllAsync();

            if (allCategories.Any(c => c.Name == dto.Name))
            {
                throw new Exception($"{dto.Name} category already exists");
            }

            var category = mapper.Map<Category>(dto);
            var created = await factory.CategoryData().CreateAsync(category);

            return mapper.Map<CategoryDto>(created);
        }

        // GET ALL CATEGORIES
        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var list = await factory.CategoryData().GetAllAsync();
            return mapper.Map<List<CategoryDto>>(list);
        }

       
        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await factory.CategoryData().GetAsync(id);

            if (category == null)
            {
                throw new Exception($"Category with id {id} not found");
            }

            return mapper.Map<CategoryDto>(category);
        }

        // UPDATE CATEGORY
        public async Task<CategoryDto> UpdateCategoryAsync(int id, UpdateCategoryDto dto)
        {
            var category = await factory.CategoryData().GetAsync(id);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            if (dto.Name != null)
                category.Name = dto.Name;

            if (dto.Description != null)
                category.Description = dto.Description;

            var updated = await factory.CategoryData().UpdateAsync(category);
            return mapper.Map<CategoryDto>(updated);
        }

        // DELETE CATEGORY
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var deleted = await factory.CategoryData().DeleteAsync(id);

            if (!deleted)
            {
                throw new Exception("Category not found");
            }

            return true;
        }
    }
}



