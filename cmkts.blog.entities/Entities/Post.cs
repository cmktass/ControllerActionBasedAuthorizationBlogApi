using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.entities.Entities
{
    public class Post:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ClickCount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<PostTag> PostTags  { get; set; }
    }
}
