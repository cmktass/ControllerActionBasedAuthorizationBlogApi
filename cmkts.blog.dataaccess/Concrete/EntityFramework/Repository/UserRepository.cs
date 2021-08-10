using cmkts.blog.dataaccess.Concrete.EntityFramework.BlogSiteContext;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public async Task<bool> Register(User user)
        {
            if(UserExist(user.Email) == null)
            {
                using var db = new CmktsBlogSiteContext();
                user.RegisteredAt = DateTime.Now;
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
           
        }

        public async Task<User> UserExist(string email)
        {
            using var db = new CmktsBlogSiteContext();
            return await db.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> Login(string userEmail)
        {
            var user = await UserExist(userEmail);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public Task<UserRole> GetRolesGetByEmail(string email)
        {
            return null;
        }
    }
}
