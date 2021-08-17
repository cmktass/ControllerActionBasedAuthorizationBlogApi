using cmkts.blog.business.Interface;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<Post>> GetPostByCategory(string name)
        {
            return await _blogRepository.GetPostByCategory(name);
        }

        public async Task<Post> GetPostByName(string name)
        {
            return await _blogRepository.GetPostByName(name);
        }

    }
}
