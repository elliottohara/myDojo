using System;
using myDojo.Domain.Users;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain.Events.MartialArtists
{
    public class StudentPromoted : IDomainEvent
    {
        public StudentPromoted(Guid instructorId, Guid studentId, Rank rank)
        {
            InstructorId = instructorId;
            StudentId = studentId;
            Rank = rank;
        }

        public Guid StudentId { get; set; }
        public Guid InstructorId { get; set; }
        public Rank Rank { get; set; }
    }
}