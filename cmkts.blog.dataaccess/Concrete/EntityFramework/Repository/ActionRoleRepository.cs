using cmkts.blog.dataaccess.Concrete.EntityFramework.BlogSiteContext;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.Repository
{
    public class ActionRoleRepository:GenericRepository<ActionRole>,IActionRoleRepository
    {
        public bool CheckActionRole(List<Role> roles, List<ControllerAction> controllerActions)
        {
            using(var db=new CmktsBlogSiteContext())
            {
                List<int> roleIds = roles.Select(i => i.Id).ToList();
                List<int> controllerActionsIds = controllerActions.Select(i => i.Id).ToList();
                return db.ActionRoles.Any(i => roleIds.Contains(i.RoleId) && controllerActionsIds.Contains(i.ControllerActionId));
            }
        }
    }
}
