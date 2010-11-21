using myDojo.Infrastructure.Web.MvcModelMetaData.Builders;
using StructureMap.Configuration.DSL;

namespace myDojo.Infrastructure.Web.MvcModelMetaData
{
    public class ModelMetadataProviderRegistry : Registry
    {
        public ModelMetadataProviderRegistry()
        {
            Scan(scanner =>
                     {
                         scanner.AssemblyContainingType(GetType());
                         scanner.AddAllTypesOf<IModelMetadataBuilder>();
                     });
        }
    }
}