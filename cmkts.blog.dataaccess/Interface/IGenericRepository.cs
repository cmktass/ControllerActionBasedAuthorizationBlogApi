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
        Task<GenericResponse<TEntity>> AddAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        Task<GenericResponse<TEntity>> UpdateAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<GenericResponse<TEntity>> GetByIdAsync(int id);
        Task<GenericResponse<TEntity>> FindByFilter(Expression<Func<TEntity, bool>> expression);
    }   
}
