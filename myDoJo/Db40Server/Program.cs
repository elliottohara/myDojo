using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db40Server.Properties;

namespace Db40Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = Db4objects.Db4o.Db4oFactory.OpenServer(Settings.Default.FileName, Settings.Default.Port);
            server.GrantAccess(Settings.Default.User,Settings.Default.Password);
            Console.ReadLine();
            server.Close();
        }
    }
}
