using cmkts.blog.business.Interface;
using cmkts.blog.dataaccess.Concrete.EntityFramework.Repository;
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
        public async virtual Task<GenericResponse<TEntity>> AddAsync(TEntity entity)
        {
            GenericResponse<TEntity> response = new GenericResponse<TEntity>();
            response.Data = await _genericRepository.AddAsync(entity);
            return response;
        }

        public async Task<GenericResponse<int>> DeleteAsync(int id)
        {
            GenericResponse<int> response = new GenericResponse<int>();
            response.Data = await _genericRepository.DeleteAsync(id);
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
            GenericResponse<TEntity> response = new GenericResponse<TEntity>();
            response.Data = await _genericRepository.UpdateAsync(entity);
            return response;

        }

        public async Task<GenericResponse<TEntity>> GetByIdAsync(int id)
        {
            GenericResponse<TEntity> response = new GenericResponse<TEntity>();
            response.Data = await _genericRepository.GetByIdAsync(id);
            return response;
        }

        public async Task<GenericResponse<TEntity>> FindByFilter(Expression<Func<TEntity, bool>> expression)
        {
            GenericResponse<TEntity> response = new GenericResponse<TEntity>();
            response.Data = await _genericRepository.FindByFilter(expression);
            return response;
        }
    }
}
