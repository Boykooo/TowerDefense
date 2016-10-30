using Network;
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
        IServer server;
        
        public void Init(IServer server)
        {
            this.server = server;
        }

        public void SignIn(string login, string password, int id)
        {
            Console.WriteLine("Идет проверка входа в систему {0}", login);

            if (db.CheckPasswod(login, password))
            {
                clientFacade.EnterTheGame();

                Message msg = new Message("Успешный вход", login);
                server.Send(id, msg);
            }
            else
            {
                clientFacade.ErrorSignIn("Неправильный пароль");
            }

        }

        public void SignUp(string login, string password, string mail, int id)
        {
            Console.WriteLine("Успешная регистрация {0}", login);
            Message msg = new Message("Успешная регистрация", login);
            server.Send(id, msg);

        }
    }
}
