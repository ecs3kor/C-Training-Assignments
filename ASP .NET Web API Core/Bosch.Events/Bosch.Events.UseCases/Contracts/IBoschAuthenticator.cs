using Bosch.Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.UseCases.Contracts
{
    public interface IBoschAuthenticator
    {
        Task<User> Authenticate(User user);

    }
}
