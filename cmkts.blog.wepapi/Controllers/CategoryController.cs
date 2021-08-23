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
    [ModelValidation]
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
        [HttpGet]
        public async Task<GenericResponse<Category>> GetCategoryById(int id)
        {
            return await _categoryService.GetByIdAsync(id);
        }
        [HttpGet("name")]
        public async Task<GenericResponse<CategoryVM>> GetCategoryByName(string name)
        {
            return _mapper.Map<GenericResponse<CategoryVM>>(await _categoryService.FindByFilter(i=>i.CategoryName==name));
        }
        [HttpPost]
        [CheckAuthorizeAttribute]
        public async Task<GenericResponse<CategoryVM>> AddCategory(CategoryVM categoryVM)
        {
            return _mapper.Map<GenericResponse<CategoryVM>>(await _categoryService.AddAsync(_mapper.Map<Category>(categoryVM)));  
        }

        [HttpPut]
        [CheckAuthorizeAttribute]
        public async Task<GenericResponse<CategoryVM>> UpdateCategory(CategoryVM categoryVM)
        {
            return _mapper.Map<GenericResponse<CategoryVM>>(await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryVM)));
        }

        [HttpDelete("id")]
        [CheckAuthorizeAttribute]
        public async Task<GenericResponse<int>> DeleteCategory(int id)
        {
            return await _categoryService.DeleteAsync(id);
        }

    }
}
