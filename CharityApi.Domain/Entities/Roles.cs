namespace CharityApi.Domain.Entities;

public class Roles : BaseAuditableEntity
{
    public string RoleName { get; set; }

    // Navigation property for UserRole
    public ICollection<UserRole> UserRoles { get; set; }
}

