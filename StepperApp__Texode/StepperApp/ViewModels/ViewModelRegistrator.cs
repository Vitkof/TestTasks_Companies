using Microsoft.Extensions.DependencyInjection;

namespace StepperApp.ViewModels
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            return services.AddScoped<MainWindowVM>();
        }
    }
}
