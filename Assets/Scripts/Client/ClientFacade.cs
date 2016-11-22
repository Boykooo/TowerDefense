using System;
using Proxy;

namespace Assets.Scripts.Client
{
    public class ClientFacade : IClientFacade
    {
        public void EnterTheGame(string login)
        {
            throw new NotImplementedException();
        }

        public void ErrorSignIn(string message)
        {
            throw new NotImplementedException();
        }

        public void ErrorSignUp(string error)
        {
            throw new NotImplementedException();
        }

        public void SuccessfulSignUp()
        {
            throw new NotImplementedException();
        }
    }
}
