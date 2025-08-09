using CarFactory.Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Employees.Infrastructure.Configurations;

public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
{
    public void Configure(EntityTypeBuilder<Factory> builder)
    {
        builder.ToTable("FACTORIES");

        builder.HasKey(k => k.Id);

        builder.Property(p => p.FactoryId).IsRequired();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.IsOpen).IsRequired().HasDefaultValue(true);

        builder.BaseEntityConfiguration();
    }
}
