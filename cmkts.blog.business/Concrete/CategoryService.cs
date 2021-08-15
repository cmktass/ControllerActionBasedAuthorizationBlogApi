using cmkts.blog.business.Interface;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.CustomizedVM;
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
    }
}
