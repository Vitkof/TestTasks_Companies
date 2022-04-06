using Microsoft.Extensions.DependencyInjection;

namespace StepperApp.ViewModels
{
    internal class ViewModelLocator
    {
        public static MainWindowVM MainWindowVM =>
            App.Services.GetRequiredService<MainWindowVM>();
    }
}