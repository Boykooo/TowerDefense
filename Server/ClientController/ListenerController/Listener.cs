using Network;
using Proxy;
using Server.ClientController.ParseMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                while (true)
                {
                    len = client.Receive(data); // ???
                    lock(lockParser)
                    {
                        Message msg = parser.GetMessage(data);
                        object[] args = new object[msg.Arguments.Length + 1];
                        msg.Arguments.CopyTo(args, 0);
                        args[args.Length - 1] = id;

                        serverFacade.GetType().GetMethod(msg.Method).Invoke(serverFacade, args); // вызов заданного метода из фасада сервера
                    }
                }
            }
            catch
            {
                Disconnect(id); // отрубаем клиента от сервера

                Console.WriteLine("Ошибка в слушателе");
            }
        }
    }
}
