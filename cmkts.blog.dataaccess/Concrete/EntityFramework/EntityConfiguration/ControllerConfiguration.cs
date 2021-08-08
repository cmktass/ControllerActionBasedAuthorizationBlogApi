using cmkts.blog.entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.EntityConfiguration
{
    class ControllerConfiguration : IEntityTypeConfiguration<Controller>
    {
        public void Configure(EntityTypeBuilder<Controller> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.ControllerName).HasColumnType("varchar(30)").IsRequired();
            builder.HasMany(ca => ca.ControllerActions).WithOne(c => c.Controller).HasForeignKey(c => c.ControllerId);
            
        }
    }
}
