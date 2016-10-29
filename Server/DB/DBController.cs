using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DB
{
    class DBController
    {
        public DBController()
        {
            InitConnection();
        }

        private MySqlConnection conn;
        private object keySignUp = new object();
        private object keySignIn = new object();

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
            try
            {
                conn.Open();
            }
            catch
            {
                Console.WriteLine("------   Ошибка при подключении к удаленной бд...    ------");
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

                int id = (int) data["ID"];
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
            lock (keySignUp)
            {

            }
        }
        public void SignIn(string login, string password)
        {
            lock (keySignIn)
            {
                OpenConnection();




                CloseConnection();
            }
        }
    }
}
