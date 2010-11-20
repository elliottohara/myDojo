using System;
using System.Web.Mvc;
using myDojo.Infrastructure.CQRS.Query;

namespace myDojo.Infrastructure.Web
{
    public class QueryActionResult<TQuery> : ViewResult where TQuery:IQuery
    {
        public Action<TQuery> BuildUpQuery { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            var query = ServiceLocation.CurrentContainer.GetInstance<TQuery>();
            if(BuildUpQuery!=null)
                BuildUpQuery(query);
            ViewData.Model = query.Execute();
            base.ExecuteResult(context);
        }
    }
}