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
    public class ClientFacade : IClientFacadeServer
    {
        public ClientFacade()
        {

        }

        private ICommunication sender;

        public void Init(ICommunication sender)
        {
            this.sender = sender;
        }
        public void EnterTheGame(int id, string login)
        {
            Message msg = new Message("EnterTheGame", login);
            sender.Send(id, msg);
        }
        public void ErrorSignIn(int id, string message)
        {
            Message msg = new Message("ErrorSignIn", message);
            sender.Send(id, msg);
        }

        public void ErrorSignUp(int id, string error)
        {
            Message msg = new Message("ErrorSignUp", error);
            sender.Send(id, msg);
        }
        public void SuccessfulSignUp(int id)
        {
            Message msg = new Message("SuccessfulSignUp");
            sender.Send(id, msg);
        }
    }
}
