using System.Web;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using MyDojo.Query.ViewModels;

namespace myDojo.Web.Utilities
{
    public class CurrentUserProvider
    {
        private readonly IReadModelRepository<MartialArtistDetails> _userRepo;
        private readonly HttpContextBase _context;

        public CurrentUserProvider(IReadModelRepository<MartialArtistDetails> userRepo,HttpContextBase context)
        {
            _userRepo = userRepo;
            _context = context;
        }

        public virtual MartialArtistDetails CurrentLoggedInUser()
        {
            var name = _context.User.Identity.Name;
            return _userRepo.GetSingle(m => m.EmailAddress == name);
        }
    }
}