using System.Linq;
using System.Web.Mvc;
using myDojo.Commands.Users;
using myDojo.Domain;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.Web;
using MyDojo.Query.ViewModels;
using myDojo.Web.Models;

namespace myDojo.Web.Controllers
{
    public class UserController : DefaultController
    {
        private readonly IReadModelRepository<MartialArtistDetails> _detailsReadModelRepository;
        
        public UserController(RefererRepository referrerRepo,IReadModelRepository<MartialArtistDetails> detailsReadModelRepository,IAggrigateRootRepository<MartialArtist> domainRepo)
        {
            _detailsReadModelRepository = detailsReadModelRepository;
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public CommandActionResult<RegisterUser> Register(string email)
        {
            return Command(new RegisterUser(email, null), () => RedirectToAction("Edit", new {email}));
        }
        public ActionResult Edit(string email)
        {
            var readModel = _detailsReadModelRepository.GetSingle(d=>d.EmailAddress == email);
            var viewModel = new EditMartialArtistForm(readModel);
            return View(viewModel);

        }
        [HttpPost]
        public CommandActionResult<EditMartialArtistInfo> Edit(EditMartialArtistForm model)
        {
            return Command(new EditMartialArtistInfo(model.Id, model.Name, model.Biography), () => RedirectToAction("List"));
        }
        public ActionResult List()
        {
            var users = _detailsReadModelRepository.GetAll().AsEnumerable();
            return View(users);
        }

    }

   
}
