using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxy;
using Network;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Client
{
    public class ClientController : IServerFacade
    {
        public ClientController()
        {
            sender = new Sender();
        }

        private Sender sender;

        public event Action<int> Disconnect = (x) => { };

        public void SignIn(string login, string password, int id)
        {
            sender.SendMessage(new SignInMessage(login, password));
        }

        public void SignUp(string login, string password, string mail, int id)
        {
            
        }

    }
}
