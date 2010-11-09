using System;

using System.Web.Mvc;
using AutoMapper;
using myDojo.Infrastructure.CQRS.Query;
using StructureMap;

namespace myDojo.Infrastructure.Web
{
    public class MappedQueryViewResult<TQuery,TDestination> : ViewResult where TQuery:IQuery
    {
        private static IMappingEngine Mapper { get { return Container.GetInstance<IMappingEngine>(); } }
        private static IContainer Container { get { return ServiceLocation.CurrentContainer; } }

        public MappedQueryViewResult(Action<TQuery> buildUpQuery)
        {
            BuildUpQuery = buildUpQuery;
        }

        protected Action<TQuery> BuildUpQuery { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var query = Container.GetInstance<TQuery>();
            if (BuildUpQuery != null)
                BuildUpQuery(query);
            var source = query.Execute();
            var viewModel = Mapper.Map(source,source.GetType(), typeof (TDestination));
            ViewData.Model = viewModel;
            base.ExecuteResult(context);
        }
        
    }
}