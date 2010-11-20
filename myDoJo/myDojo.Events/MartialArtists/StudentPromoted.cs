using System;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Events.MartialArtists
{
    public class StudentPromoted : IDomainEvent
    {
        public StudentPromoted(Guid instructorId, Guid studentId, string belt, int stripes)
        {
            InstructorId = instructorId;
            StudentId = studentId;
            Belt = belt;
            Stripes = stripes;
        }

        public Guid StudentId { get; set; }
        public string Belt { get; set; }
        public int Stripes { get; set; }
        public Guid InstructorId { get; set; }
    }
}