using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IServerFacade
    {
        void SignIn(string login, string password, int id);
        void SignUp(string login, string password, string mail, int id);


    }
}
