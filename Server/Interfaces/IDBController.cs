using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    interface IDBController
    {
        //Вход в систему
        bool CheckPasswod(string login, string password);


        //Регистрация
        bool CheckFreeMail(string mail);
        bool CheckFreeLogin(string login);
        void SignUp(string login, string password, string mail);

        int GetID(string login);
        
    }
}
