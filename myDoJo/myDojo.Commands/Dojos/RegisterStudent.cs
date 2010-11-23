using System;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.Commands.Dojos
{
    public class RegisterStudent : ICommand
    {
        public Guid StudentId { get; set; }
        public Guid DojoId { get; set; }

        public RegisterStudent(Guid studentId, Guid dojoId)
        {
            StudentId = studentId;
            DojoId = dojoId;
        }
    }
}