using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.entities.Entities
{
    public class ControllerAction:BaseEntity
    {
        public string ActionName { get; set; }
        public int ControllerId { get; set; }
        public Controller Controller { get; set; }

        public List<ActionRole> ActionRoles { get; set; }
    }
}
