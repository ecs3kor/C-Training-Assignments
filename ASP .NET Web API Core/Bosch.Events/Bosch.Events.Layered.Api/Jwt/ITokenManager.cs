using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.DTOs.UserDtos;

namespace Bosch.Events.Layered.Api.Jwt
{
    public interface ITokenManager
    {
        string GenerateToken(User user, string roleName);


    }
}
