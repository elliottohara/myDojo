using System;
using System.Web.Mvc;
using myDojo.Commands.Dojos;
using myDojo.Infrastructure.Core;
using myDojo.Infrastructure.Web;
using MyDojo.Query.Queries.Dojos;
using myDojo.Web.Models.Schools;
using myDojo.Web.Utilities;

namespace myDojo.Web.Controllers
{
    public class SchoolsController : DefaultController
    {
        private readonly CurrentUserProvider _currentUserProvider;

        public SchoolsController(CurrentUserProvider currentUserProvider)
        {
            _currentUserProvider = currentUserProvider;
        }
        public ActionResult Details(Guid id)
        {
            return Query<DojoById>(q => q.DojoId = id);
        }
        public ActionResult Create()
        {
            var model = new CreateSchoolForm();
            return ContextualView(model);
        }

        [HttpPost]
        public CommandActionResult<CreateNewDojo> Create(CreateSchoolForm form)
        {
            var address = new Address
                              {
                                  State = form.State,
                                  City = form.City,
                                  PostalCode = form.PostalCode,
                                  Street = form.StreetName,
                                  StreetNumber = form.StreetNumber,
                              };
            return Command(
                new CreateNewDojo(_currentUserProvider.CurrentLoggedInUser().Id, form.Id, form.Name, address,form.Description),
                () => RedirectToAction("List", "Schools"));
        }
        public ActionResult Join()
        {
            return View(new JoinSchoolForm());
        }
        [HttpPost]
        public CommandActionResult<RegisterStudent> Join(JoinSchoolForm form)
        {
            return Command(new RegisterStudent(_currentUserProvider.CurrentLoggedInUser().Id, form.DojoId),
                           () => RedirectToAction("Details", new {Id = form.DojoId}));
        }
        public ActionResult Registrations(Guid dojoId)
        {
            return Query<RegistrationsBySchool>(q => q.DojoId = dojoId);
        }
        public ActionResult List()
        {
            return Query<AllDojos>();
        }
        public ActionResult AdminList()
        {
            return Query<AllDojos>();
        }
        [AcceptVerbs("POST","DELETE")]
        public CommandActionResult<DeleteDojo> Delete(DeleteSchoolForm form)
        {
            return Command(new DeleteDojo(form.SchoolId), () => RedirectToAction("List"));
        }
    }
}