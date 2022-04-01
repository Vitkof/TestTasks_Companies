using StepperApp.Infrastructure.Commands.Base;
using StepperApp.ViewModels;

namespace StepperApp.Infrastructure.Commands
{
    internal class LoadDataCmd : Command
    {
        private readonly IUsersVM _vm;


        public LoadDataCmd(IUsersVM vm)
        {
            _vm = vm;
        }

        public override bool CanExecute(object param) => true;
        public override void Execute(object param)
        {
            _vm.LoadData();
        }
    }
}
