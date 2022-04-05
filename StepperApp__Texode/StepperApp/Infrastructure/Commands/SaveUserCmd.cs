using StepperApp.Infrastructure.Commands.Base;
using StepperApp.ViewModels;
using System;

namespace StepperApp.Infrastructure.Commands
{
    internal class SaveUserCmd : Command
    {
        private readonly IUsersVM _vm;


        public SaveUserCmd(IUsersVM vm)
        {
            _vm = vm;
        }


        public override bool CanExecute(object param)
        {
            return _vm.SelectedUser != null &&
                _vm.SelectedUser.FullName.IsNotNullOrEmpty();
        }

        public override void Execute(object param)
        {
            _vm.SaveUser();
        }
    }
}
