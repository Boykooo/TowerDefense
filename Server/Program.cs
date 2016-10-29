using Server.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServerSocket server = new ServerSocket();

            //Task.Run(() => server.Start());

            DBController db = new DBController();
            db.CheckConnect();

            while (Console.ReadLine().ToLower() != "stop") ;
        }
    }
}
