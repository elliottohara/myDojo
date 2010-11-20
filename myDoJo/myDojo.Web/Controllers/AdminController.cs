using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Db4objects.Db4o;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.Web;

namespace myDojo.Web.Controllers
{
    public class AdminController : DefaultController
    {
        private readonly IObjectContainer _db;

        public AdminController(IObjectContainer db)
        {
            _db = db;
        }
        public ActionResult FlushDb()
        {
            foreach (var o in _db.Ext().StoredClasses())
            {
                try
                {
                    var type = typeof(Instructor).Assembly.GetType(o.GetName());
                    foreach (var thing in _db.Query(type))
                    {
                        _db.Delete(thing);
                    }
                }
                catch (Exception)
                {
                    
                   
                }
               
            }
            return Content("DONE");
        }
    }
}
