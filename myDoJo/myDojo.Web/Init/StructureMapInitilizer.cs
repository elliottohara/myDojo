using StructureMap;

namespace myDojo.Web.Init
{
    public static class StructureMapInitilizer
    {
        public static void Initilize()
        {
            ObjectFactory.Configure(c =>
            {
                c.Scan(s =>
                {
                    s.AssembliesFromApplicationBaseDirectory();
                    s.LookForRegistries();
                });

            });
        }
    }
}