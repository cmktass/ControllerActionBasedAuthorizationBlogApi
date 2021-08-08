using cmkts.blog.entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.EntityConfiguration
{
    public class UserSocialMediasConfiguration : IEntityTypeConfiguration<UserSocialMedia>
    {
        public void Configure(EntityTypeBuilder<UserSocialMedia> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.HasIndex(i => new { i.SocialMediaId, i.UserId }).IsUnique();
        }
    }
}
