



using System;
using Db4objects.Db4o;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Query;
using MyDojo.Query.ViewModels.Dojos;

namespace MyDojo.Query.Queries.Dojos
{
    public class DojoById : IQuery
    {
        private IReadModelRepository<DojoDetails> _repo;

        public DojoById(IReadModelRepository<DojoDetails> repo)
        {
            _repo = repo;
        }

        public Guid DojoId { get; set; }
        public object Execute()
        {
            return _repo.GetById(DojoId);
        }
    }
}