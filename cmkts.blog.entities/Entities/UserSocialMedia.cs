using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.entities.Entities
{
    public class UserSocialMedia:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }
    }
}
