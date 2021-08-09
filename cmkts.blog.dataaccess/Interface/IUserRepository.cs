using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.dataaccess.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> Register(User user);
        Task<User> UserExist(string username);
        Task<User> Login(string userEmail);


    }
}
