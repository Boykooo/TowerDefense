using Network;
using Proxy;
using Server.DB;
using Server.Interfaces;
using System;

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
        private ISender sender;

        public event Action<int> Disconnect = (x) => { };

        public void Init(ISender sender)
        {
            this.sender = sender;
        }
        public void SignIn(string login, string password, int id)
        {

            if (db.CheckPasswod(login, password))
            {
                clientFacade.EnterTheGame();

                Message msg = new Message("Успешный вход", login);
                sender.Send(id, msg);
            }
            else
            {
                // А вдруг дисконект выполнится быстрее, чем отправится сообщение. Возможно ли такое?
                clientFacade.ErrorSignIn("Неправильный пароль");
                Disconnect(id);
            }

        }
        public void SignUp(string login, string password, string mail, int id)
        {
            Console.WriteLine("Успешная регистрация {0}", login);
            Message msg = new Message("Успешная регистрация", login);
            sender.Send(id, msg);
        }
    }
}
