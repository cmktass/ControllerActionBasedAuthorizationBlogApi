using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.entities.Entities
{
    public class UserActivity:BaseEntity
    {
        public DateTime UserFailLoginDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
