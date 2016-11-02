using MySql.Data.MySqlClient;
using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DB
{
    class DBController : IDBController
    {
        public DBController()
        {
            InitConnection();
        }

        private MySqlConnection conn;
        private object key = new object();

        private void InitConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "91.202.20.14";
            builder.Port = 3306;
            builder.UserID = "root";
            builder.Password = "root";
            builder.Database = "tower_defence";
            conn = new MySqlConnection(builder.ToString());
        }
        private void OpenConnection()
        {
            lock (key)
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    Console.WriteLine("------   Ошибка при подключении к удаленной бд...    ------");
                }
            }

        }
        private void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public void CheckConnect()
        {

            try
            {
                conn.Open();
                string sql = "SELECT * FROM user_reg_data";
                MySqlCommand script = new MySqlCommand(sql, conn);
                MySqlDataReader data = script.ExecuteReader();

                data.Read();

                int id = (int)data["ID"];
                string login = data["Login"].ToString();
                string password = data["Password"].ToString();
                string mail = data["Mail"].ToString();
                string reg_date = data["Reg_date"].ToString();

                Console.WriteLine("Первый в базе id = {0} login = {1} password = {2} mail = {3} reg_date = {4}", id, login, password, mail, reg_date);

                conn.Close();

            }
            catch
            {
                Console.WriteLine("bad");
            }
        }
        public void SignUp(string login, string password, string mail)
        {
            lock (key)
            {

            }
        }
        public bool CheckPasswod(string login, string password)
        {
            OpenConnection();

            MySqlCommand request = new MySqlCommand();
            request.CommandText = "SELECT * FROM user_reg_data where Login = @login and Password = @password; ";
            request.Parameters.AddWithValue("@login", login);
            request.Parameters.AddWithValue("@password", password);
            request.Connection = conn;

            bool result = request.ExecuteReader().HasRows;

            CloseConnection();

            return result;
        }
        public bool CheckFreeMail(string mail)
        {
            MySqlCommand request = new MySqlCommand();
            request.CommandText = "SELECT * FROM user_reg_data where Mail = @mail; ";
            request.Parameters.AddWithValue("@mail", mail);
            request.Connection = conn;

            lock (key)
            {
                OpenConnection();
                bool result = request.ExecuteReader().HasRows;
                CloseConnection();

                return true;
            }

        }
        public bool CheckFreeLogin(string login)
        {
            return true;
        }
    }
}
