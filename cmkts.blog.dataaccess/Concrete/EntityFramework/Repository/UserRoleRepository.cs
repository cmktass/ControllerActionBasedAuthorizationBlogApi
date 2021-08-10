using cmkts.blog.dataaccess.Concrete.EntityFramework.BlogSiteContext;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.Repository
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public  List<Role> GetRolesGetByEmail(string email)
        {
            using (var db = new CmktsBlogSiteContext())
            {
                
                return  db.UserRoles.Include(r => r.Role).Where(ur => ur.UserId == 4).Select(i => i.Role).ToList();
            }
            
        }
    }
}
