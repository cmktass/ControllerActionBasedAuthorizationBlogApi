using cmkts.blog.business.Interface;
using cmkts.blog.dataaccess.Interface;
using System;
using System.Collections.Generic;
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

        public Task<TEntity> AddAsync(TEntity entity)
        {
            return _genericRepository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            if (await _genericRepository.DeleteAsync(entity)>0)
            {
                return true;
            }
            return false;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _genericRepository.UpdateAsync(entity);
        }
    }
}
