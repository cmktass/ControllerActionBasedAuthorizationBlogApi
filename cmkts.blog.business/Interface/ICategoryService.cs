using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.CustomizedVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.business.Interface
{
    public interface ICategoryService:IGenericService<Category>
    {
        Task<List<CategoriesWithBlogCounts>> GetAllCategoryWithBlogCountAsync();
    }
}
