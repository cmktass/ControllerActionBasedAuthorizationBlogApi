using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.viewmodel.ViewModels.Post
{
    public class PostVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public CategoryVM Category { get; set; }
    }
}
