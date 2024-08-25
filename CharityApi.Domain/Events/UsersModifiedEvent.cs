namespace CharityApi.Domain.Events;

public class UsersModifiedEvent : BaseEvent
{
    public Users User { get; }

    public UsersModifiedEvent(Users user)
    {
        User = user;
    }
}
