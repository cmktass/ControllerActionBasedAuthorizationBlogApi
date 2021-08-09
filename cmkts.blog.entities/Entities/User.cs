using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.entities.Entities
{
    public class User:BaseEntity
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
        public bool IsDeleted { get; set; }
        public List<Post> Posts { get; set; }
        public List<UserSocialMedia> UserSocialMedias { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<UserActivity> UserActivities { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
