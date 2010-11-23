using System;
using System.Linq;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Query;
using MyDojo.Query.ViewModels.Dojos;

namespace MyDojo.Query.Queries.Dojos
{
    public class RegistrationsBySchool : IQuery
    {
        private readonly IReadModelRepository<StudentRegistrationView> _repository;

        public Guid DojoId { get; set; }
        public RegistrationsBySchool(IReadModelRepository<StudentRegistrationView> repository)
        {
            _repository = repository;
        }

        public object Execute()
        {
            return _repository.Get(r => r.DojoId == DojoId);
        }
    }
}