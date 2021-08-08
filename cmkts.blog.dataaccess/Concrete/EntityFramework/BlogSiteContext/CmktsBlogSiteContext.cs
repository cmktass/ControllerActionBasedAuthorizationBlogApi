using cmkts.blog.dataaccess.Concrete.EntityFramework.EntityConfiguration;
using cmkts.blog.entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.BlogSiteContext
{
    public class CmktsBlogSiteContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=CemAktasBlogApp;Integrated Security=SSPI;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BlogMaps.Maps(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Controller> Controllers { get; set; }
        public DbSet<ControllerAction> ControllerActions { get; set; }
        public DbSet<ActionRole> ActionRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<UserSocialMedia> UserSocialMedias { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
