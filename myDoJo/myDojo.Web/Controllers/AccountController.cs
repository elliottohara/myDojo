using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using myDojo.Infrastructure.Web;
using myDojo.Web.Models;
using myDojo.Web.Models.Account;

namespace myDojo.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMembershipProvider _membershipProvider;

        public AccountController(IMembershipProvider membershipProvider)
        {
            _membershipProvider = membershipProvider;
        }
        [HttpGet]
        public ActionResult Logon()
        {
            return View(new LogonForm());
        }
        [HttpPost]
        public ActionResult Logon(LogonForm form)
        {
            if(!_membershipProvider.Validate(form.EmailAddress,form.Password))
            {
                ModelState.AddModelError("Password","Username or password is invalid.");
            }
            if(ModelState.IsValid)
            {
                _membershipProvider.SignIn(form.EmailAddress,form.RememberMe);
                //TODO redirect
                return RedirectToAction("Index", "User");
            }
            return View(form);
        }
        public ActionResult Logoff()
        {
            _membershipProvider.SignOut();
            return Redirect("~/");
        }
    }
}
