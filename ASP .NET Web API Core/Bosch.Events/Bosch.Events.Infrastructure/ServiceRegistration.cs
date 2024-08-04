using Bosch.Events.DAL;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfigurationManager configuration)
        {
            services.AddDbContext<BoschEventsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BoschEventsServiceConStr"));
            });
            services.AddTransient<ICommonRepository<Role>, CommonRepository<Role>>();
            services.AddTransient<ICommonRepository<Event>, CommonRepository<Event>>();
            services.AddTransient<ICommonRepository<Employee>, CommonRepository<Employee>>();
            services.AddTransient<ICommonRepository<Feedback>, CommonRepository<Feedback>>();
            services.AddTransient<ICommonRepository<EventRegistration>, CommonRepository<EventRegistration>>();
            services.AddTransient<ICommonRepository<User>, CommonRepository<User>>();
            services.AddTransient<IBoschAuthenticator, AuthenticatorRepository>();
    
            return services;
        }
    }
}
