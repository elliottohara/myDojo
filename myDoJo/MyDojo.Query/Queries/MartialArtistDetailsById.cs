

using System;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Query;
using MyDojo.Query.ViewModels;

namespace MyDojo.Query.Queries
{
    public class MartialArtistDetailsById : IQuery
    {
        private readonly IReadModelRepository<MartialArtistDetails> _repository;

        public MartialArtistDetailsById(IReadModelRepository<MartialArtistDetails> repository)
        {
            _repository = repository;
        }

        public Guid Id { get; set; }

        public object Execute()
        {
            IdMustBeSet();
            return _repository.GetById(Id);
        }

        private void IdMustBeSet()
        {
            if(Id.Equals(Guid.Empty))
                throw new ArgumentException("Id","Id must be set");
        }
    }
}