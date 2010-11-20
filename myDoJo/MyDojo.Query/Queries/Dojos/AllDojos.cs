using System;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Query;
using MyDojo.Query.ViewModels.Dojos;

namespace MyDojo.Query.Queries.Dojos
{
    public class AllDojos : IQuery
    {
        private readonly IReadModelRepository<DojoDetails> _dojoRepo;

        public AllDojos(IReadModelRepository<DojoDetails> dojoRepo )
        {
            _dojoRepo = dojoRepo;
        }

        public object Execute()
        {
            return _dojoRepo.GetAll();
        }
    }
}