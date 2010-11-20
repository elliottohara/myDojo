using System;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain.Events.Dojos
{
    public class StudentRegistered : IDomainEvent
    {
        public Guid DojoId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime On { get; set; }

        public StudentRegistered(Guid dojoId,Guid studentId,DateTime on)
        {
            DojoId = dojoId;
            StudentId = studentId;
            On = on;
        }
    }
}