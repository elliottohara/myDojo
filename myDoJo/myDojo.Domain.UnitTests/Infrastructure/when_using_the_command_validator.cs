using System.Linq;
using myDojo.Infrastructure.CQRS.Commands;
using myDojo.Infrastructure.CQRS.Validation;
using NUnit.Framework;
using Rhino.Mocks;
using StructureMap;

namespace myDojo.Domain.UnitTests.Infrastructure
{
    [TestFixture]
    public class when_using_the_command_validator
    {
        
        [Test]
        public void if_a_validator_fails_is_valid_will_return_false()
        {
            if_the_command_is_not_valid();
            when_Validate_Command_is_called();
            _isValid.ShouldBeFalse();
        }
        
        private void if_the_command_is_not_valid()
        {
            var validatorThatWillReturnFalse = MockRepository.GenerateMock<IValidate<SomeTestCommand>>();
            validatorThatWillReturnFalse.Stub(v => v.IsValid(_command)).Return(false);
            ObjectFactory.Inject(validatorThatWillReturnFalse);
        }
        [Test]
        public void if_the_validator_passes_is_valid_will_return_false()
        {
            if_the_command_is_valid();
            when_Validate_Command_is_called();
            _isValid.ShouldBeTrue();
        }
        [Test]
        public void failed_rules_will_contain_the_failed_validator()
        {
            if_the_command_is_not_valid();
            when_Validate_Command_is_called();
            _validator.FailedRules.ShouldContain(ObjectFactory.GetInstance<IValidate<SomeTestCommand>>());
        }
        private void if_the_command_is_valid()
        {
            var validatorThatWillReturnFalse = MockRepository.GenerateMock<IValidate<SomeTestCommand>>();
            validatorThatWillReturnFalse.Stub(v => v.IsValid(_command)).Return(true);
            ObjectFactory.Inject(validatorThatWillReturnFalse);
        }
        private CommandValidator<SomeTestCommand> _validator;
        private SomeTestCommand _command;
        private bool _isValid;


        public void when_Validate_Command_is_called()
        {
            _validator = new CommandValidator<SomeTestCommand>(ObjectFactory.Container);
            _isValid = _validator.IsValid(_command);
        }
        [SetUp]
        public void establish_context()
        {
            ObjectFactory.Initialize(a => { });
            _command = new SomeTestCommand();
            
        }
    }
    public class SomeTestCommand : ICommand
    {
        
    }
}