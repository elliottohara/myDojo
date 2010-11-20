using System;
using System.Collections.Generic;
using System.Linq;
using myDojo.Infrastructure.CQRS.Commands;
using StructureMap;

namespace myDojo.Infrastructure.CQRS.Validation
{
    public class CommandValidator<TCommand> : ICommandValidator<TCommand> where TCommand : ICommand
    {
        private readonly IContainer _container;
        private List<IValidate<TCommand>> _failedRules;

        public CommandValidator(IContainer container)
        {
            _container = container;
            _failedRules = new List<IValidate<TCommand>>();
        }

        public bool IsValid(TCommand command)
        {
            foreach(var validator in _container.GetAllInstances<IValidate<TCommand>>())
            {
                if (!validator.IsValid(command))
                    _failedRules.Add(validator);
            }
            return _failedRules.Count() == 0;
        }

        public IEnumerable<IValidate<TCommand>> FailedRules { get { return _failedRules; } }
    }
}