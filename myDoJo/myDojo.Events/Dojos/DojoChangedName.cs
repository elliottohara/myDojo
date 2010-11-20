using System;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain.Dojos
{
    public class DojoChangedName : IDomainEvent
    {
        public Guid DojoId { get; set; }
        public string SchoolName { get; set; }

        public DojoChangedName(Guid id, string schoolName)
        {
            DojoId = id;
            SchoolName = schoolName;
        }
    }
}