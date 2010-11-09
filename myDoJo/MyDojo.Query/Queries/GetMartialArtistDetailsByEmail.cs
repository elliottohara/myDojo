using System;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Query;
using MyDojo.Query.ViewModels;

namespace MyDojo.Query.Queries
{
    public class GetMartialArtistDetailsByEmail : IQuery 
    {
        private readonly IReadModelRepository<MartialArtistDetails> _repository;

        public GetMartialArtistDetailsByEmail(IReadModelRepository<MartialArtistDetails> repository)
        {
            _repository = repository;
        }

        public virtual String EmailAddress { get; set; }
        public object Execute()
        {
            return _repository.GetSingle(ma => ma.EmailAddress == EmailAddress);
        }
    }
}