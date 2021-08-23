using cmkts.blog.viewmodel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.dataaccess.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<int> DeleteAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> FindByFilter(Expression<Func<TEntity, bool>> expression);
    }   
}
