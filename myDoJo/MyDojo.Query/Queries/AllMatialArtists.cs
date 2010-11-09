using System;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Query;
using MyDojo.Query.ViewModels;

namespace MyDojo.Query.Queries
{
    public class AllMatialArtists : IQuery
    {
        private readonly IReadModelRepository<MartialArtistDetails> _repository;

        public AllMatialArtists(IReadModelRepository<MartialArtistDetails> repository)
        {
            _repository = repository;
        }

        public object Execute()
        {
            return _repository.GetAll();
        }
    }
}