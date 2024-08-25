using CharityApi.Domain.Entities;

namespace CharityApi.Application.Common.Models.Dtos;

public class UserDto
{
    public UserDto()
    {
        UserRoles = Array.Empty<UserRole>();
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Mobile { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Users, UserDto>();
        }
    }
}
