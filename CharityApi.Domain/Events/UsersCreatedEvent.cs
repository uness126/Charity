namespace CharityApi.Domain.Events;

public class UsersCreatedEvent : BaseEvent
{
    public Users User { get; }
    public UsersCreatedEvent(Users user)
    {
        User = user;
    }
}
