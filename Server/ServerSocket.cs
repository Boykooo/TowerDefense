using Proxy;
using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Network;
using Server.ParseMessage;

namespace Server
{
    [Serializable]
    class ServerSocket : IServer
    {
        public ServerSocket(IServerFacade serverFacade)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clients = new Dictionary<int, Socket>();
            maxQueue = 10;
            formatter = new BinaryFormatter();
            this.serverFacade = serverFacade;
            idManager = new IDManager.IDManager();
            parser = new Parser();
        }

        private Socket socket;
        private const int port = 8888;
        private const int packetLenght = 5024;
        private int maxQueue;
        private int id = 0;
        private object lck = new object();
        private BinaryFormatter formatter;

        private Dictionary<int, Socket> clients;
        private IServerFacade serverFacade;
        private IDManager.IDManager idManager;
        private Parser parser;

        public event Action<int> Disconnect = (x) => { };
        public event Action<byte[], int> GetMessage = (x, y) => { };
        public event Action<int> Connect = (x) => { };

        private void AcceptNewClient()
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, port));
            socket.Listen(maxQueue);

            int currId;

            while (true)
            {
                try
                {
                    Socket client = socket.Accept();
                    int id = idManager.GetID();
                    clients.Add(id, client);

                    Console.WriteLine("Установлено соединение с {0}", client.RemoteEndPoint);

                    //ThreadPool.QueueUserWorkItem((x) => ListenUser(client));
                    //ThreadPool.QueueUserWorkItem((x) => Send(client));

                    Thread listenUser = new Thread(() => ListenUser(id, client));
                    listenUser.Start();
                    //Thread send = new Thread(() => Send(client));
                    //send.Start();
                }
                catch
                {
                    Console.WriteLine("Ошибка в коннекте нового юзера");
                }
            }
        }
        private void ListenUser(int id, Socket userSocket)
        {
            byte[] data = new byte[packetLenght];
            int len;
            try
            {
                while (true)
                {
                    //if (!inGame)
                    //{
                    //    len = userSocket.Receive(data);

                    //    using (MemoryStream stream = new MemoryStream(data))
                    //    {
                    //        BinaryFormatter f = new BinaryFormatter();

                    //        Message msg = f.Deserialize(stream) as Message;

                    //        if (msg.Method == "SignIn")
                    //        {
                    //            serverFacade.SignIn(ref idUser, msg.Arguments[0].ToString(), msg.Arguments[1].ToString());
                    //            if (id != -1)
                    //            {
                    //                inGame = true;
                    //                Console.WriteLine("{0} выполнил вход в систему", msg.Arguments[0].ToString());
                    //                clients.Add(id, userSocket);
                    //                Send(userSocket);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            serverFacade.GetType().GetMethod(msg.Method).Invoke(serverFacade, msg.Arguments);
                    //        }
                    //    }

                    //}
                    //else
                    //{
                    //    Console.WriteLine("Прием сообщений...");
                    //}

                    len = userSocket.Receive(data);

                    using (MemoryStream stream = new MemoryStream(data))
                    {
                        BinaryFormatter f = new BinaryFormatter();

                        Message msg = f.Deserialize(stream) as Message;

                        object[] args = new object[msg.Arguments.Length + 1];
                        msg.Arguments.CopyTo(args, 0);
                        args[args.Length - 1] = id;

                        serverFacade.GetType().GetMethod(msg.Method).Invoke(serverFacade, args);
                    }

                }
            }
            catch
            {
                Console.WriteLine("Ошбика в слушателе");
            }
        }
        private void Send(Socket userSocket)
        {
            try
            {
                string str = "Вы вошли в игру";

                using (MemoryStream stream = new MemoryStream())
                {

                    formatter.Serialize(stream, str);

                    userSocket.Send(stream.GetBuffer());

                    Console.WriteLine("Сообщение {0} отправлено", str);
                }
            }
            catch
            {
                Console.WriteLine("Ошбика в сендере");
            }

        }

        public void Start()
        {
            AcceptNewClient();
        }
        public void Send(int id, Message message)
        {
            if (clients.ContainsKey(id))
            {
                Console.WriteLine("Сообщение <{0}> отправлено", message.Method);
                clients[id].Send(parser.GetSerializedMessage(message));
            }
        }
    }
}
