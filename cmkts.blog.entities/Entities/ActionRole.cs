using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.entities.Entities
{
    public class ActionRole:BaseEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int ControllerActionId { get; set; }
        public ControllerAction ControllerAction { get; set; }
    }
}
