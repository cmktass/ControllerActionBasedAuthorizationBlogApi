
using System;
using System.Collections.Generic;
using System.Text;
using cmkts.blog.dataaccess.Concrete.EntityFramework.BlogSiteContext;
using System.Linq;
using cmkts.blog.dataaccess.Interface;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cmkts.blog.viewmodel.ViewModels;
using System.Linq.Expressions;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        public async virtual Task<GenericResponse<TEntity>> AddAsync(TEntity entity)
        {
            using(var db = new CmktsBlogSiteContext()) 
            {
                GenericResponse<TEntity> response = new GenericResponse<TEntity>();
                await db.Set<TEntity>().AddAsync(entity);
                await db.SaveChangesAsync();
                response.Data = entity;
                return response;
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

        public async virtual Task<GenericResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            using(var db=new CmktsBlogSiteContext())
            {
                GenericResponse<TEntity> response = new GenericResponse<TEntity>();
                db.Set<TEntity>().Update(entity);
                await db.SaveChangesAsync();
                response.Data = entity;
                return response;
            }
        }
        public async virtual Task<GenericResponse<TEntity>> GetByIdAsync(int id)
        {
            using (var db = new CmktsBlogSiteContext())
            {
                GenericResponse<TEntity> response = new GenericResponse<TEntity>();
                var data = await db.Set<TEntity>().FindAsync(id);
                response.Data = data;
                return response;
            }
        }

        public async virtual Task<GenericResponse<TEntity>> FindByFilter(Expression<Func<TEntity, bool>> expression)
        {
            using (var db = new CmktsBlogSiteContext())
            {
                GenericResponse<TEntity> response = new GenericResponse<TEntity>();
                response.Data = await db.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
                return response;
            }
        }
    }
}
