using StepperApp.Infrastructure.Commands.Base;
using System;

namespace StepperApp.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _exe;
        private readonly Func<object, bool> _canExe;

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _exe = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _canExe = CanExecute;
        }

        public override bool CanExecute(object param)
        {
            return _canExe == null ? true : _canExe(param);
        }

        public override void Execute(object param) => _exe(param);
    }
}
