using cmkts.blog.entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.EntityConfiguration
{
    public class ControllerActionConfiguration : IEntityTypeConfiguration<ControllerAction>
    {
        public void Configure(EntityTypeBuilder<ControllerAction> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.ActionName).HasColumnType("varchar(30)").IsRequired();
            builder.HasMany(ar => ar.ActionRoles).WithOne(a => a.ControllerAction).HasForeignKey(a => a.ControllerActionId);
        }
    }
}
