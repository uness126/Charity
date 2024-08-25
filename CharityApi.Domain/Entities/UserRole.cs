namespace CharityApi.Domain.Entities;

public class UserRole : BaseAuditableEntity
{
    public Guid UserID { get; set; }
    public Guid RoleID { get; set; }

    // Navigation properties
    public Users User { get; set; }
    public Roles Role { get; set; }
}
