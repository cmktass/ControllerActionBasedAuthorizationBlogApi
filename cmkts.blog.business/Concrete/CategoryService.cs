using cmkts.blog.business.Interface;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.CustomizedVM;
using cmkts.blog.viewmodel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.business.Concrete
{
    public class CategoryService:GenericService<Category>,ICategoryService
    {
        private readonly IGenericRepository<Category> _genericRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IGenericRepository<Category> genericRepository, ICategoryRepository categoryRepository):base(genericRepository)
        {
            this._genericRepository = genericRepository;
            this._categoryRepository = categoryRepository;
        }

        public async Task<List<CategoriesWithBlogCounts>> GetAllCategoryWithBlogCountAsync()
        {
             return await _categoryRepository.GetAllCategoryWithBlogCount();
        }
        public async override Task<GenericResponse<Category>> AddAsync(Category entity)
        {
            GenericResponse<Category> response = new GenericResponse<Category>();
            if (await _categoryRepository.FindByFilter(c=>c.CategoryName == entity.CategoryName) != null)
            {
                response.ErrorMessage = "Bu isimli kategori mevcut";
                response.Data = entity;
                return response;
            }
            return await base.AddAsync(entity);
        }
        public async override Task<GenericResponse<Category>> UpdateAsync(Category entity)
        {
            GenericResponse<Category> response = new GenericResponse<Category>();
            if (await _categoryRepository.FindByFilter(c => c.CategoryName == entity.CategoryName) != null)
            {
                response.ErrorMessage = "Bu isimli kategori mevcut";
                response.Data = entity;
                return response;
            }
            return await base.UpdateAsync(entity);
        }

    }
}
