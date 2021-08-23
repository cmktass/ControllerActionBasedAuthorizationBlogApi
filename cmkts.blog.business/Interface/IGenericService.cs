using cmkts.blog.dataaccess.Concrete.EntityFramework.Repository;
using cmkts.blog.viewmodel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.business.Interface
{
    public interface IGenericService<TEntity> where TEntity:class
    {
        Task<GenericResponse<TEntity>> AddAsync(TEntity entity);
        Task<GenericResponse<int>> DeleteAsync(int id);
        Task<GenericResponse<TEntity>> UpdateAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<GenericResponse<TEntity>> GetByIdAsync(int id);
        Task<GenericResponse<TEntity>> FindByFilter(Expression<Func<TEntity, bool>> expression);

    }
}
