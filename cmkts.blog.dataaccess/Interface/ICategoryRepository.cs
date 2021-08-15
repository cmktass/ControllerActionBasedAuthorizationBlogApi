using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.CustomizedVM;
using cmkts.blog.viewmodel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.dataaccess.Interface
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<List<CategoriesWithBlogCounts>> GetAllCategoryWithBlogCount();
    }
}
