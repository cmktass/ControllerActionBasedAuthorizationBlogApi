using cmkts.blog.dataaccess.Concrete.EntityFramework.BlogSiteContext;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.Repository
{
    public class BlogRepository : GenericRepository<Post>, IBlogRepository
    {
        public async Task<Post> GetPostByName(string name)
        {
            using (var db = new CmktsBlogSiteContext())
            {
                return await db.Posts.Where(n => n.Title == name).FirstOrDefaultAsync();
            }
        }

        public async Task<List<Post>> GetPostByCategory(string name)
        {
            using (var db = new CmktsBlogSiteContext())
            {
                return await db.Posts.Include(c => c.Category).Where(c => c.Category.CategoryName == name).ToListAsync();
            }
        }
    }
}
