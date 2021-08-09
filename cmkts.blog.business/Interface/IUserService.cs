using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.business.Interface
{
    public interface IUserService:IGenericService<User>
    {
        Task<bool> Register(UserVM user);
        Task<bool> UserExist(string username);
        Task<UserVM> Login(UserLoginVM userVM);
    }
}
