using AutoMapper;
using cmkts.blog.business.Interface;
using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.CustomizedVM;
using cmkts.blog.viewmodel.ViewModels;
using cmkts.blog.wepapi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmkts.blog.wepapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<CategoriesWithBlogCounts>> GetAllCategory()
        {
            return await _categoryService.GetAllCategoryWithBlogCountAsync();
        }


        [HttpPost]
        [CheckAuthorizeAttribute]
        [ModelValidation]
        public async Task<int> AddCategory(CategoryVM categoryVM)
        {
            var category = _mapper.Map<CategoryVM>(await _categoryService.AddAsync(_mapper.Map<Category>(categoryVM)));
            return category.Id;
        }

        [HttpPut]
        [CheckAuthorizeAttribute]
        [ModelValidation]
        public async Task<CategoryVM> UpdateCategory(CategoryVM categoryVM)
        {
            return _mapper.Map<CategoryVM>(await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryVM)));
        }

        [HttpDelete]
        [CheckAuthorizeAttribute]
        [ModelValidation]
        public async Task<bool> DeleteCategory(CategoryVM categoryVM)
        {
            return await _categoryService.DeleteAsync(_mapper.Map<Category>(categoryVM));
        }

    }
}
