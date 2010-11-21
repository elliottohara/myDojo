using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Db4objects.Db4o;
using myDojo.Infrastructure;

namespace myDojo.Web.Init
{
    public class ObjectContainerProvider : IStartupTask, IDisposable
    {
        private readonly ConnectionStringSettingsCollection _connectionStrings;

        public ObjectContainerProvider(ConnectionStringSettingsCollection connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public void Execute()
        {
            Db = OpenDatabase();
        }
        public void Dispose()
        {
            if (Db != null)
                Db.Dispose();
        }
        public IObjectContainer OpenSession()
        {
            try
            {
                return Db.Ext().OpenSession();
            }
            catch(NullReferenceException notSureWhyThisHappens)
            {
                Execute();
                return Db.Ext().OpenSession();
            }
        }
        public static IEmbeddedObjectContainer Db { get; private set; }
        private IEmbeddedObjectContainer OpenDatabase()
        {
            var connectionString = _connectionStrings["Db4o"];
            var pairs = connectionString.ConnectionString.Split(';').Where(s => !String.IsNullOrEmpty(s));
            var parts = pairs.Select(pair => pair.Split('=')).ToDictionary(p => p[0].ToLower(), p => p[1]);

            var filePath = HttpContext.Current.Server.MapPath("~/" + parts["filename"]);
            return Db4oEmbedded.OpenFile(filePath);
        }
        
        
    }
}