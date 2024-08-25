using CharityApi.Domain.Entities;

namespace CharityApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Users> Users { get; }

    DbSet<Roles> Roles { get; }

    DbSet<UserRole> UserRoles { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
