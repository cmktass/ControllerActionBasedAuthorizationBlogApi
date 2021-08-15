
using System;
using System.Collections.Generic;
using System.Text;
using cmkts.blog.dataaccess.Concrete.EntityFramework.BlogSiteContext;
using System.Linq;
using cmkts.blog.dataaccess.Interface;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        public async virtual Task<TEntity> AddAsync(TEntity entity)
        {
            using(var db = new CmktsBlogSiteContext()) 
            {
                await db.Set<TEntity>().AddAsync(entity);
                await db.SaveChangesAsync();
                return entity;
            }
        }

        public async virtual Task<int> DeleteAsync(TEntity entity)
        {
            using (var db = new CmktsBlogSiteContext())
            {
                db.Set<TEntity>().Remove(entity);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using (var db = new CmktsBlogSiteContext())
            {
                return await db.Set<TEntity>().ToListAsync();
            }
        }

        public async virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            using(var db=new CmktsBlogSiteContext())
            {
                db.Set<TEntity>().Update(entity);
                await db.SaveChangesAsync();
                return entity;
            }
        }
    }
}
