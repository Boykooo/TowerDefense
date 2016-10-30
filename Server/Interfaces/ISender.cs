using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    public interface ISender
    {
        //Отправка сообщений
        void Send(int id, Message msg);
    }
}
