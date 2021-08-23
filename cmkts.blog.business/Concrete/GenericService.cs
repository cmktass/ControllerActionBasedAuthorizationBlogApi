using cmkts.blog.business.Interface;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.business.Concrete
{
    public class GenericService<TEntity>:IGenericService<TEntity> where TEntity:class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }
        public virtual Task<GenericResponse<TEntity>> AddAsync(TEntity entity)
        {
            return _genericRepository.AddAsync(entity);
        }

        public async Task<GenericResponse<int>> DeleteAsync(int id)
        {
            var response = await _genericRepository.DeleteAsync(id);
            if (response.Data > 0)
            {
                return response;
            }
            else
            {
                response.ErrorMessage = "Silinemedi";
                return response;
            }
        }

        public virtual async Task<GenericResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            return await _genericRepository.UpdateAsync(entity);
        }

        public async Task<GenericResponse<TEntity>> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<GenericResponse<TEntity>> FindByFilter(Expression<Func<TEntity, bool>> expression)
        {
            return await _genericRepository.FindByFilter(expression);
        }
    }
}
