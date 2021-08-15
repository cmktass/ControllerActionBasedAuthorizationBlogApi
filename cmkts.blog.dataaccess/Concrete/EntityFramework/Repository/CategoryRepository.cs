using cmkts.blog.dataaccess.Concrete.EntityFramework.BlogSiteContext;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.CustomizedVM;
using cmkts.blog.viewmodel.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.Repository
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        public async Task<List<CategoriesWithBlogCounts>> GetAllCategoryWithBlogCount()
        {
            using(var db=new CmktsBlogSiteContext())
            {
                List<CategoriesWithBlogCounts> categories= await db.Categories.Select(i => new CategoriesWithBlogCounts
                {
                    CategoryName = i.CategoryName,
                    BlogCount = i.Posts.Count
                }).ToListAsync();
                
                return categories;
            }
        }
    }
}
