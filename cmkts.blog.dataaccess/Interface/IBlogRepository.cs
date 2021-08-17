using cmkts.blog.entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.dataaccess.Interface
{
    public interface IBlogRepository:IGenericRepository<Post>
    {
        Task<Post> GetPostByName(string name);
        Task<List<Post>> GetPostByCategory(string name);
    }
}
