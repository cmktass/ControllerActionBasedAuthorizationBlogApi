using cmkts.blog.entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.business.Interface
{
    public interface IBlogService:IGenericService<Post>
    {
        Task<Post> GetPostByName(string name);
        Task<List<Post>> GetPostByCategory(string name);
    }
}
