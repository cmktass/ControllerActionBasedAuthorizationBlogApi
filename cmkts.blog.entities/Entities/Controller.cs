using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.entities.Entities
{
    public class Controller:BaseEntity
    {
        public string ControllerName { get; set; }
        public List<ControllerAction> ControllerActions { get; set; }
    }
}
