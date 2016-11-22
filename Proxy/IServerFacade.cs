using System;

namespace Proxy
{
    public interface IServerFacade
    {
        void SignIn(string login, string password, int id);
        void SignUp(string login, string password, string mail, int id);


        event Action<int> Disconnect;
    }
}
