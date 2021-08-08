using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.entities.Entities
{
    public class SocialMedia:BaseEntity
    {
        public string Name { get; set; }
        public List<UserSocialMedia> UserSocialMedias { get; set; }
    }
}
