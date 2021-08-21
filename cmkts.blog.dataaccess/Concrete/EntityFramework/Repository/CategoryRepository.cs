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

        public override async Task<GenericResponse<Category>> AddAsync(Category entity)
        {
            GenericResponse<Category> response = new GenericResponse<Category>();
            using (var db = new CmktsBlogSiteContext())
            {
                if (db.Categories.Any(c => c.CategoryName.ToLower() == entity.CategoryName.ToLower()))
                {
                    response.ErrorMessage = "Bu Kategori Zaten Kayıtlı.";
                    response.Data = entity;
                    //Kategori Var
                }
                else
                {
                    await db.Categories.AddAsync(entity);
                    await db.SaveChangesAsync();
                    response.Data = entity;
                }
                return response;
            }
        }

        public override async Task<GenericResponse<Category>> UpdateAsync(Category entity)
        {
            using(var db=new CmktsBlogSiteContext())
            {
                GenericResponse<Category> response = new GenericResponse<Category>();
                if (db.Categories.Any(c=> c.CategoryName == entity.CategoryName))
                {
                    response.ErrorMessage = "Bu Kategori Kayıtlı";
                    response.Data = entity;
                }
                else
                {
                    await db.Categories.AddAsync(entity);
                    await db.SaveChangesAsync();
                    response.Data = entity;
                }
                return response;
            }
        }

    }
}
