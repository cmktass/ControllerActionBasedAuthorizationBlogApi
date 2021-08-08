using cmkts.blog.business.Interface;
using cmkts.blog.dataaccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.business.Concrete
{
    public class GenericService<TEntity>:IGenericService<TEntity> where TEntity:class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }



    }
}
