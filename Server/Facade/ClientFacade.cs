using Network;
using Proxy;
using Server.Interfaces;
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

        private ICommunication sender;
        public void Init(ICommunication sender)
        {
            this.sender = sender;
        }
        public void EnterTheGame(string login)
        {
            Message msg = new Message("EnterTheGame");
            sender.Send(login, msg);
        }

        public void ErrorSignIn(string message)
        {
            Console.WriteLine("Послано сообщение на клиент <{0}>", message);
        }
    }
}
