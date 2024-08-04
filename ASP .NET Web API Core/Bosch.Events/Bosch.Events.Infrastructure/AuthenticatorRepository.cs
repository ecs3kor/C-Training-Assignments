using Bosch.Events.DAL;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Bosch.Events.Infrastructure
{
    public class AuthenticatorRepository : IBoschAuthenticator
    {
        private readonly BoschEventsDbContext _dbContext;

        public AuthenticatorRepository(BoschEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Authenticate(User user)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.UserName == user.UserName);
        }
    }
}
