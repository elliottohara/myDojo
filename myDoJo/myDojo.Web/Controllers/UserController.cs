using System;
using System.Web.Mvc;
using myDojo.Commands.Users;
using myDojo.Infrastructure.Web;
using MyDojo.Query.Queries;
using myDojo.Web.Models;
using myDojo.Web.Models.Users;

namespace myDojo.Web.Controllers
{
    public class UserController : DefaultController
    {
        private readonly IMembershipProvider _provider;

        public UserController(IMembershipProvider provider)
        {
            _provider = provider;
        }

        public ActionResult Register()
        {
            return View(new RegisterUserForm());
        }
        [HttpPost]
        public CommandActionResult<RegisterUser> Register(RegisterUserForm form)
        {
            return Command(new RegisterUser(form.EmailAddress,null,form.Password), () =>
                                                                                       {
                                                                                           _provider.SignIn(
                                                                                               form.EmailAddress, false);
                                                                                           return RedirectToAction("Edit",new{email=form.EmailAddress});
                                                                                       });
        }
        [HttpGet]
        public ActionResult Edit(string email)
        {
            return MappedQuery<GetMartialArtistDetailsByEmail,EditMartialArtistForm>(query =>query.EmailAddress = email);
        }
        public ActionResult Details(Guid id)
        {
            return Query<MartialArtistDetailsById>(q => q.Id = id);
        }
        [HttpPost]
        public CommandActionResult<EditMartialArtistInfo> Edit(EditMartialArtistForm model)
        {
            return Command(new EditMartialArtistInfo(model.Id, model.Name, model.Biography), () => RedirectToAction("Index"));
        }
        public ActionResult Index()
        {
            return Query<AllMatialArtists>();
        }

    }

   
}
