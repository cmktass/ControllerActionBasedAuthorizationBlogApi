using cmkts.blog.entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(i => !i.IsDeleted);
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.Gsm).HasColumnType("varchar(11)").IsRequired();
            builder.Property(i => i.FirstName).HasColumnType("varchar(25)").IsRequired();
            builder.Property(i => i.LastName).HasColumnType("varchar(25)").IsRequired();
            builder.Property(i => i.Email).HasColumnType("varchar(50)").IsRequired();
            builder.HasIndex(i => i.Email).IsUnique();
            builder.Property(i => i.RegisteredAt).IsRequired();
            builder.Property(i => i.BirthDate).IsRequired();
            builder.Property(i => i.Job).IsRequired();
            builder.HasMany(p => p.Posts).WithOne(u => u.User).HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(ur => ur.UserRoles).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            builder.HasMany(usm => usm.UserSocialMedias).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            
        }
    }
}
