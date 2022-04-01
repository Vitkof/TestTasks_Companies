using StepperApp.Infrastructure.Commands.Base;
using StepperApp.Models;
using StepperApp.ViewModels;
using System;

namespace StepperApp.Infrastructure.Commands
{
    internal class RenderCmd : Command
    {
        private readonly CoordinateGridVM _vm;


        public RenderCmd(CoordinateGridVM vm)
        {
            _vm = vm;
        }

        public override bool CanExecute(object param)
        {
            return _vm.Data.FullName.IsNotNullOrEmpty();
        }
            
        public override void Execute(object param)
        {
            var parameter = (CoordinateGridModel)param;

            _vm.Rendering(parameter);
        }
    }
}
