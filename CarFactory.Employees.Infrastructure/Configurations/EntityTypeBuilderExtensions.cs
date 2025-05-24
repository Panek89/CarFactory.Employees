using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Employees.Infrastructure.Configurations;

public static class EntityTypeBuilderExtensions
{
    public static void FirstNameConfiguration<T>(this EntityTypeBuilder<T> builder) where T : class
    {
        builder.Property(nameof(FirstName))
            .HasMaxLength(50)
            .HasColumnName(nameof(FirstName));
    }

    public static void LastNameConfiguration<T>(this EntityTypeBuilder<T> builder) where T : class
    {
        builder.Property(nameof(LastName))
            .HasMaxLength(50)
            .HasColumnName(nameof(LastName));
    }

    public static void PersonalIdConfiguration<T>(this EntityTypeBuilder<T> builder) where T : class
    {
        builder.Property(nameof(PersonalId))
            .HasMaxLength(11)
            .IsFixedLength()
            .HasColumnName(nameof(PersonalId));
    }

    public static void BaseEntityConfiguration<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
    {
        builder.Property(nameof(BaseEntity.CreatedBy))
            .HasMaxLength(50)
            .HasColumnName(nameof(BaseEntity.CreatedBy));

        builder.Property(nameof(BaseEntity.UpdatedBy))
            .HasMaxLength(50)
            .HasColumnName(nameof(BaseEntity.UpdatedBy));
    }
}
