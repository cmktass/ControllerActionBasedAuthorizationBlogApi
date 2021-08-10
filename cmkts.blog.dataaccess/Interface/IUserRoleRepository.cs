using cmkts.blog.entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.dataaccess.Interface
{
    public interface IUserRoleRepository:IGenericRepository<UserRole>
    {
        List<Role> GetRolesGetByEmail(string email);
    }
}
