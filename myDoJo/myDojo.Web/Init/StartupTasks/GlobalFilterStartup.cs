using System;
using System.Web.Mvc;
using myDojo.Infrastructure;

namespace myDojo.Web.Init
{
    public class GlobalFilterStartup : IStartupTask
    {
        private readonly GlobalFilterCollection _filters;

        public GlobalFilterStartup(GlobalFilterCollection filters)
        {
            _filters = filters;
        }

        public void Execute()
        {
            _filters.Add(new HandleErrorAttribute());
        }
    }
}