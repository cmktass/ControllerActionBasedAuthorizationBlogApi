using cmkts.blog.dataaccess.Concrete.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.BlogSiteContext
{
    public static class BlogMaps
    {
        public static void Maps(this ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("blogging");
            modelBuilder.ApplyConfiguration(new ActionRoleConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ControllerActionConfiguration());
            modelBuilder.ApplyConfiguration(new ControllerConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SocialMediaConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserSocialMediasConfiguration());
        }
    }
}
