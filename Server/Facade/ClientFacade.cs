using Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Facade
{
    public class ClientFacade : IClientFacade
    {
        public ClientFacade()
        {

        }

        public void EnterTheGame()
        {
            Console.WriteLine("Послано сообщение на клиент <успешный вход в игру>");
        }

        public void ErrorSignIn(string message)
        {
            Console.WriteLine("Послано сообщение на клиент <{0}>", message);
        }
    }
}
