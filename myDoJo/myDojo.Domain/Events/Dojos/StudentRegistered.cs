using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain.Events.Dojos
{
    public class StudentRegistered : IDomainEvent
    {
        public Registration Registration { get; set; }

        public StudentRegistered(Registration registration)
        {
            Registration = registration;
        }
    }
}