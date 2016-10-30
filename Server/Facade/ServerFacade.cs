using Proxy;
using Server.DB;
using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Facade
{
    class ServerFacade : IServerFacade
    {
        public ServerFacade(IClientFacade clientFacade)
        {
            this.clientFacade = clientFacade;
            db = new DBController();
        }

        private IClientFacade clientFacade;
        private IDBController db;
        

        public void SignIn(ref int id, string login, string password)
        {
            Console.WriteLine("Идет проверка входа в систему {0}", login);

            if (db.CheckPasswod(login, password))
            {
                id = db.GetID(login);
                clientFacade.EnterTheGame();
            }
            else
            {
                clientFacade.ErrorSignIn("Неправильный пароль");
            }

        }

        public void SignUp(string login, string password, string mail)
        {
            throw new NotImplementedException();
        }
    }
}
