using Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Facade
{
    class ServerFacade : IServerFacade
    {
        public ServerFacade()
        {

        }

        public void SignIn(string login, string password)
        {
            Console.WriteLine("Подключился {0}", login);
        }

        public void SignUp(string login, string password, string mail)
        {
            throw new NotImplementedException();
        }
    }
}
