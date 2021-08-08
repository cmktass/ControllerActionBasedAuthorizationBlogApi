using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.entities.Entities
{
    public class Tag:BaseEntity
    {
        public string TagName { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}
