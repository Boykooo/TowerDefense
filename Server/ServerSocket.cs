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
                    currId = id++;

                    Console.WriteLine("Установлено соединение с {0}", client.RemoteEndPoint);


                    //ThreadPool.QueueUserWorkItem((x) => ListenUser(client));
                    //ThreadPool.QueueUserWorkItem((x) => Send(client));

                    Thread listenUser = new Thread(() => ListenUser(client));
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
        private void ListenUser(Socket userSocket)
        {
            byte[] data = new byte[packetLenght];
            int len;
            bool inGame = false;
            int idUser = -1;
            try
            {
                while (true)
                {
                    if (!inGame)
                    {



                        len = userSocket.Receive(data);

                        using (MemoryStream stream = new MemoryStream(data))
                        {
                            BinaryFormatter f = new BinaryFormatter();

                            var mesg = f.Deserialize(stream) as String;

                            if (mesg == "login")
                            {
                                serverFacade.SignIn(ref idUser, );
                            }

                        }















                    }
                    else
                    {
                        
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ошбика в слушателе");
            }
        }
        private void InGame(Socket userSocket)
        {

        }

        private void Send(Socket userSocket)
        {
            try
            {
                string str = "hello client";

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
        public void Send(int id, byte[] message)
        {
            if (clients.ContainsKey(id))
            {
                clients[id].Send(message);
            }
        }

        public void NewPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
