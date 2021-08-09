
using System;
using System.Collections.Generic;
using System.Text;
using cmkts.blog.dataaccess.Concrete.EntityFramework.BlogSiteContext;
using System.Linq;
using cmkts.blog.dataaccess.Interface;
using System.Threading.Tasks;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {

        public async virtual Task AddAsync(TEntity entity)
        {
            using(var db = new CmktsBlogSiteContext()) 
            {
                await db.Set<TEntity>().AddAsync(entity);
                await db.SaveChangesAsync();
            }
        }
    }
}
