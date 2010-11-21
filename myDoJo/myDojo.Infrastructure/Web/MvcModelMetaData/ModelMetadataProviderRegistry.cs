using myDojo.Infrastructure.Web.MvcModelMetaData;
using StructureMap.Configuration.DSL;

namespace myDojo.Infrastructure.Web.ModelMetaData
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