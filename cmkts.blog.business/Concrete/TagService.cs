using cmkts.blog.business.Interface;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.business.Concrete
{
    public class TagService:GenericService<Tag>,ITagService
    {
        private readonly IGenericRepository<Tag> _genericRepository;
        public TagService(IGenericRepository<Tag> genericRepository):base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
