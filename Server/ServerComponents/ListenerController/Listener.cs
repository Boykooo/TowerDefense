using Network;
using Proxy;
using System;
using System.Net;
using System.Net.Sockets;

namespace Server.ClientController.ListenerController
{
    public class Listener
    {
        public Listener(IServerFacade serverFacade)
        {
            this.serverFacade = serverFacade;
            parser = new Parser();
        }

        private const int packetLenght = 5024;

        private IServerFacade serverFacade;
        private Parser parser;
        private object lockParser = new object();

        public event Action<int> Disconnect = (x) => { };

        public void ListenClient(int id, Socket client)
        {
            byte[] data = new byte[packetLenght];
            int len;
            EndPoint endPoint = client.RemoteEndPoint;
            try
            {
                while (true)
                {

                    client.Receive(data); // ???

                    lock (lockParser)
                    {
                        Message msg = parser.GetMessage(data);

                        if (msg != null)
                        {
                            object[] args = new object[msg.Arguments.Length + 1];
                            msg.Arguments.CopyTo(args, 0);
                            args[args.Length - 1] = id;

                            serverFacade.GetType().GetMethod(msg.Method).Invoke(serverFacade, args); // вызов заданного метода из фасада сервера
                        }
                    }
                }
            }
            catch
            {
                Disconnect(id); // отключаем клиента от сервера

                Console.WriteLine("Слушатель для id = {0} отключен", id);
            }
        }
    }
}
