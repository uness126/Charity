using CharityApi.Application.Common.Interfaces;
using CharityApi.Domain.Entities;
using CharityApi.Domain.Events;

namespace CharityApi.Application.UsersApp.Commands.CreateUser;

public class CreateUserCommand : IRequest<Guid>
{
    public Guid Id { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new Users
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        entity.AddDomainEvent(new UsersCreatedEvent(entity));

        _context.Users.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
