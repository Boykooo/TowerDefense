using Proxy;
using Server.Facade;
using Server.Interfaces;
using System;
using System.Threading.Tasks;
using Server.ClientController;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            IClientFacade clientFacade = new ClientFacade();

            ServerFacade serverFacade = new ServerFacade(clientFacade);

            IClientController clientController = new ClientController.ClientController(serverFacade);

            IServer server = new ServerSocket(clientController);

            serverFacade.Init(clientController);

            Task.Run(() => server.Start());

            //DBController db = new DBController();
            //db.CheckConnect();

            while (Console.ReadLine().ToLower() != "stop") ;
        }
    }
}
