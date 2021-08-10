using cmkts.blog.entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.dataaccess.Interface
{
    public interface IActionRepository:IGenericRepository<ControllerAction>
    {
        List<ControllerAction> GetContollerActionGetByController(string ControllerName);
    }
}
