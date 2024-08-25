namespace CharityApi.Domain.Entities;

public class Users : BaseAuditableEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Mobile { get; set; }

    // Navigation property for UserRole
    public ICollection<UserRole> UserRoles { get; set; }
}
