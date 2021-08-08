using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.viewmodel.ViewModels
{
    public class UserVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }
        public string ProfileImage { get; set; }
        public string Resume { get; set; }
        public DateTime BirthDate { get; set; }
        public string Job { get; set; }
        public string ProfileText { get; set; }
        public string ProfileDescription { get; set; }
        public string Password { get; set; }
    }
}
