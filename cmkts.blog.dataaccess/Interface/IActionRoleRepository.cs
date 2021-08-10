using cmkts.blog.entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.dataaccess.Interface
{
    public interface IActionRoleRepository:IGenericRepository<ActionRole>
    {
        bool CheckActionRole(List<Role> roles, List<ControllerAction> controllerActions);
    }
}
