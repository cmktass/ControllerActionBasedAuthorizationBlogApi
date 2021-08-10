using cmkts.blog.dataaccess.Concrete.EntityFramework.BlogSiteContext;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.Repository
{
    public class ActionRepository : GenericRepository<ControllerAction>, IActionRepository
    {
        public List<ControllerAction> GetContollerActionGetByController(string ControllerName)
        {
            using (var db = new CmktsBlogSiteContext())
            {
                var value = db.Controllers.Where(c => c.ControllerName == ControllerName)
                         .Select(s => new
                         {
                             controllerActions = s.ControllerActions
                         })
                         .FirstOrDefault();

                return value.controllerActions;
            }
           
        }
    }
}
