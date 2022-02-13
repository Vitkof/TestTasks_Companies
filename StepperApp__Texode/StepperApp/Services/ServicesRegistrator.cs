using StepperApp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace StepperApp.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
           .AddTransient<IDataService, DataService>()
           .AddTransient<IUserService, UserService>()
        ;
    }
}
