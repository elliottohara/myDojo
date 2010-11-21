using System;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.Commands.Dojos
{
    public class DeleteDojo : ICommand
    {
        public Guid DojoId { get; set; }

        public DeleteDojo(Guid id)
        {
            DojoId = id;
        }
    }
}