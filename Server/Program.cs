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

            ClientFacade clientFacade = new ClientFacade();

            ServerFacade serverFacade = new ServerFacade(clientFacade);

            IServerController serverController = new ServerController(serverFacade);

            IServer server = new ServerSocket(serverController);

            serverFacade.Init(serverController);
            clientFacade.Init(serverController);

            Task.Run(() => server.Start());

            while (Console.ReadLine().ToLower() != "stop") ;
        }
    }
}
