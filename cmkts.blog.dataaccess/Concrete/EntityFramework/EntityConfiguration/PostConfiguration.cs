using cmkts.blog.entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.EntityConfiguration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(t => t.Title).HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Description).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(t => t.CreatedDate).IsRequired();
            builder.HasMany(p => p.PostTags).WithOne(p => p.Post).HasForeignKey(p => p.PostId);
            builder.HasOne(c => c.Category).WithMany(p => p.Posts).HasForeignKey(c => c.CategoryId);
        }
    }
}
