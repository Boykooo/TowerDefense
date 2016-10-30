using Proxy;
using Server.DB;
using Server.Facade;
using Server.Interfaces;
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

            ServerFacade serverFacade = new ServerFacade(clientFacade);

            IServer server = new ServerSocket(serverFacade);

            serverFacade.Init(server);

            Task.Run(() => server.Start());

            //DBController db = new DBController();
            //db.CheckConnect();

            while (Console.ReadLine().ToLower() != "stop") ;
        }
    }
}
