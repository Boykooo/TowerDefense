using MySql.Data.MySqlClient;
using Server.DB.Model;
using Server.Interfaces;
using System;
using System.Linq;

namespace Server.DB
{
    class DBController : IDBController
    {
        public DBController()
        {
            model = new TDModel();
        }

        private TDModel model;
        private object key = new object();

        public void SignUp(string login, string password, string mail)
        {
            lock (key)
            {
                using (var model = new TDModel())
                {
                    Users newUser = new Users();
                    newUser.Login = login;
                    newUser.Password = password;
                    newUser.Mail = mail;
                    newUser.Reg_date = DateTime.Now.Date;

                    model.users.Add(newUser);

                    model.SaveChanges();
                }

            }
        }
        public bool CheckPasswod(string login, string password)
        {
            using (var model = new TDModel())
            {
                var res = model.users.FirstOrDefault(user => user.Login == login && user.Password == password);

                return res == null;
            }
        }
        public bool CheckFreeMail(string mail)
        {
            lock (key)
            {
                using (var model = new TDModel())
                {
                    Users res = model.users.FirstOrDefault(user => user.Mail == mail);

                    return res == null;
                }
            }
        }
        public bool CheckFreeLogin(string login)
        {
            lock (key)
            {
                using (var model = new TDModel())
                {
                    Users res = model.users.FirstOrDefault(user => user.Login == login);

                    return res == null;
                }
            }
        }
    }
}
