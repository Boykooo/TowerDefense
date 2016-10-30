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

        private ISender sender;
        public void Init(ISender sender)
        {
            this.sender = sender;
        }
        public void EnterTheGame(int id)
        {
            Message msg = new Message("EnterTheGame");
            sender.Send(id, msg);
        }

        public void ErrorSignIn(string message)
        {
            Console.WriteLine("Послано сообщение на клиент <{0}>", message);
        }
    }
}
