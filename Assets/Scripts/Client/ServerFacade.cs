using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxy;
using UnityEngine;

namespace Assets.Scripts.Client
{
    public class ServerFacade : IServerFacade
    {

        public event Action<int> Disconnect;

        public void SignIn(string login, string password, int id)
        {
            throw new NotImplementedException();
        }

        public void SignUp(string login, string password, string mail, int id)
        {
            throw new NotImplementedException();
        }

    }
}
