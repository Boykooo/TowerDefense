using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    public interface ICommunication
    {
        //Отправка сообщений
        void Send(int id, Message msg);
        void Send(string login, Message msg);
        void AddOnlineUser(string login, int id);
        bool isOnline(string login);
    }
}
