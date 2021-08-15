using cmkts.blog.viewmodel.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.viewmodel.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<PostVM> Posts { get; set; }

    }
}
