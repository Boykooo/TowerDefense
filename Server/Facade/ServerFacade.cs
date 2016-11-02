using Network;
using Proxy;
using Server.DB;
using Server.Interfaces;
using System;

namespace Server.Facade
{
    class ServerFacade : IServerFacade
    {
        public ServerFacade(IClientFacadeServer clientFacade)
        {
            this.clientFacade = clientFacade;
            db = new DBController();
        }

        private IClientFacadeServer clientFacade;
        private IDBController db;
        private ICommunication communication;

        public event Action<int> Disconnect = (x) => { };

        public void Init(ICommunication communication)
        {
            this.communication = communication;
        }

        // Вход в систему
        public void SignIn(string login, string password, int id)
        {
            if (db.CheckPasswod(login, password))
            {
                if (!communication.isOnline(login))
                {
                    communication.AddOnlineUser(id, login);
                    clientFacade.EnterTheGame(id, login);
                    Console.WriteLine("Пользователь {0} вошел в систему", login);
                }
                else
                {
                    clientFacade.ErrorSignIn(id, "Пользователь уже в сети");
                    Disconnect(id);
                }
            }
            else
            {
                clientFacade.ErrorSignIn(id, "Неправильная комбинация логина и пароля");
                Disconnect(id);
            }

        }

        // Регистрация в системе
        public void SignUp(string login, string password, string mail, int id)
        {

            if (db.CheckFreeMail(mail))
            {
                if (db.CheckFreeLogin(login))
                {
                    db.SignUp(login, password, mail);
                    clientFacade.SuccessfulSignUp(id);
                }
                else
                {
                    clientFacade.ErrorSignUp(id, "Логин занят");
                    Disconnect(id);
                }
            }
            else
            {
                clientFacade.ErrorSignUp(id, "Данный почтовый адресс уже занят");
                Disconnect(id);
            }

        }
    }
}
