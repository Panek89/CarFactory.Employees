using CarFactory.Employees.Domain.Models;

namespace CarFactory.Employees.Domain.ExtensionMethods;

public static class ModelExtensionMethods
{
    public static T SetInitialMetaData<T>(this T model) where T : BaseEntity
    {
        model.Id = Guid.NewGuid();
        model.IsDeleted = false;
        model.CreatedAt = DateTime.UtcNow;
        model.CreatedBy = "System";

        return model;
    }
}
