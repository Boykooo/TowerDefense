using Proxy;
using Server.Facade;
using Server.Interfaces;
using System;
using System.Threading.Tasks;
using Server.ServerComponents;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            ClientFacade clientFacade = new ClientFacade();

            ServerFacade serverFacade = new ServerFacade(clientFacade);

            IServerController clientController = new ServerComponents.ServerController(serverFacade);

            IServer server = new ServerSocket(clientController);

            serverFacade.Init(clientController);
            clientFacade.Init(clientController);

            Task.Run(() => server.Start());

            //DBController db = new DBController();
            //db.CheckConnect();

            while (Console.ReadLine().ToLower() != "stop") ;
        }
    }
}
