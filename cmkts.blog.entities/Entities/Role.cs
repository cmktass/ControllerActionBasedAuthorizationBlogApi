using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.entities.Entities
{
    public class Role:BaseEntity
    {
        public string RoleName { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<ActionRole> ActionRoles { get; set; }
    }
}
