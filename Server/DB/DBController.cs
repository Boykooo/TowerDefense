using MySql.Data.MySqlClient;
using Server.DB.Model;
using Server.Interfaces;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Server.DB
{
    class DBController : IDBController
    {
        public DBController()
        {
            model = new DBModel();
        }

        private DBModel model;
        private object key = new object();

        public void SignUp(string login, string password, string mail)
        {
            lock (key)
            {
                using (var model = new DBModel())
                {
                    user newUser = new user();
                    newUser.login = login;
                    newUser.password = password;
                    newUser.mail = mail;
                    newUser.reg_date = DateTime.Now.Date;

                    model.user.Add(newUser);

                    model.SaveChanges();
                }

            }
        }
        public bool CheckPasswod(string login, string password)
        {
            using (var model = new DBModel())
            {

                string md5Password = Md5(password);
                var res = model.user.FirstOrDefault(user => user.login == login && user.password == md5Password);

                return res != null;
            }
        }
        public bool CheckFreeMail(string mail)
        {
            lock (key)
            {
                using (var model = new DBModel())
                {
                    user res = model.user.FirstOrDefault(user => user.mail == mail);

                    return res == null;
                }
            }
        }
        public bool CheckFreeLogin(string login)
        {
            lock (key)
            {
                using (var model = new DBModel())
                {
                    user res = model.user.FirstOrDefault(user => user.login == login);

                    return res == null;
                }
            }
        }

        private string Md5(string password)
        {
            byte[] hash = Encoding.ASCII.GetBytes(password);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string result = "";
            foreach (var b in hashenc)
            {
                result += b.ToString("x2");
            }
            return result;
        }
    }
}
