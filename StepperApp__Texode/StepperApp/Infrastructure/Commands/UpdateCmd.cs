using StepperApp.Infrastructure.Commands.Base;
using StepperApp.ViewModels;
using System;

namespace StepperApp.Infrastructure.Commands
{
    internal class UpdateCmd : Command
    {
        private IUsersVM _vm;


        public UpdateCmd(IUsersVM vm)
        {
            _vm = vm;
        }

        public override bool CanExecute(object param)
        {
            return _vm.SelectedUser != null &&
                ((UserVM)_vm.SelectedUser).FullName.IsNotNullOrEmpty();
        }

        public override void Execute(object param)
        {
            _vm.UpdateUser();
        }
    }
}
