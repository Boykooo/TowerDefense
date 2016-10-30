using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IServerFacade
    {
        void SignIn(ref int id, string login, string password);
        void SignUp(string login, string password, string mail);


    }
}
