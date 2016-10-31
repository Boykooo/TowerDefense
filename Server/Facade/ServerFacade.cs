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
        private ICommunication communication;

        public event Action<int> Disconnect = (x) => { };

        public void Init(ICommunication communication)
        {
            this.communication = communication;
        }
        public void SignIn(string login, string password, int id)
        {
            if (db.CheckPasswod(login, password) && !communication.isOnline(login))
            {
                communication.AddOnlineUser(login, id);
                clientFacade.EnterTheGame(login);
                Console.WriteLine("Пользователь {0} вошел в систему", login);
            }
            else
            {
                // А вдруг дисконект выполнится быстрее, чем отправится сообщение. Возможно ли такое?
                Console.WriteLine("Неправильный пароль у пользователя {0} или онлайн", login);
                //clientFacade.ErrorSignIn("Неправильный пароль");

                Message msg = new Message("Disconnect", login);
                communication.Send(id, msg);

                Disconnect(id);
            }

        }
        public void SignUp(string login, string password, string mail, int id)
        {
            Console.WriteLine("Успешная регистрация {0}", login);
            Message msg = new Message("Успешная регистрация", login);
            communication.Send(id, msg);
        }
    }
}
