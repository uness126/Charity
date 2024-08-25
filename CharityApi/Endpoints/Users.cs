using CharityApi.Application.UsersApp.Commands.CreateUser;
using CharityApi.Infrastructure.Identity;

namespace CharityApi.Endpoints;

public class Users: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            //.MapGet(GetTodoLists)
            .MapPost(CreateUser);
            //.MapPut(UpdateTodoList, "{id}")
            //.MapDelete(DeleteTodoList, "{id}");
    }

    //public Task<TodosVm> GetTodoLists(ISender sender)
    //{
    //    return sender.Send(new GetTodosQuery());
    //}

    public Task<Guid> CreateUser(ISender sender, CreateUserCommand command)
    {
        return sender.Send(command);
    }

    //public async Task<IResult> UpdateTodoList(ISender sender, int id, UpdateTodoListCommand command)
    //{
    //    if (id != command.Id) return Results.BadRequest();
    //    await sender.Send(command);
    //    return Results.NoContent();
    //}

    //public async Task<IResult> DeleteTodoList(ISender sender, int id)
    //{
    //    await sender.Send(new DeleteTodoListCommand(id));
    //    return Results.NoContent();
    //}
}
