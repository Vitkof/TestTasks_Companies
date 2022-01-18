using StepperApp.Infrastructure.Commands.Base;
using System.Windows;

namespace StepperApp.Infrastructure.Commands
{
    internal class CloseApplicationCmd : Command
    {
        public override bool CanExecute(object param) => true;
        public override void Execute(object param) => Application.Current.Shutdown();
    }
}
