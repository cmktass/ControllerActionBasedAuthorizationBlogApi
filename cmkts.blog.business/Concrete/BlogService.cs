using cmkts.blog.business.Interface;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.business.Concrete
{
    public class BlogService:GenericService<Post>,IBlogService
    {
        IGenericRepository<Post> _genericRepository;
        IBlogRepository _blogRepository;
        public BlogService(IGenericRepository<Post> genericRepository,IBlogRepository blogRepository):base(genericRepository)
        {
            _genericRepository = genericRepository;
            _blogRepository = blogRepository;
        }


    }
}
