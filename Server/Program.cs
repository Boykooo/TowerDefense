using Proxy;
using Server.DB;
using Server.Facade;
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
            IClientFacade clientFacade = new ClientFacade();

            IServerFacade serverFacade = new ServerFacade(clientFacade);

            ServerSocket server = new ServerSocket(serverFacade);


            Task.Run(() => server.Start());

            //DBController db = new DBController();
            //db.CheckConnect();

            while (Console.ReadLine().ToLower() != "stop") ;
        }
    }
}
