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
    class ServerSocket
    {
        public ServerSocket()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clients = new Dictionary<int, Socket>();
            maxQueue = 10;
            formatter = new BinaryFormatter();
        }

        private Socket socket;
        private Dictionary<int, Socket> clients;
        private const int port = 8888;
        private const int packetLenght = 5024;
        private int maxQueue;
        private int id = 0;
        private object lck = new object();
        private BinaryFormatter formatter;



        public void Start()
        {
            AcceptNewClient();
        }

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

                    Console.WriteLine("Соединение установлено с {0}", currId);

                    lock (lck)
                    {
                        clients.Add(id, client);
                    }



                    Thread listenUser = new Thread(() => ListenUser(client));
                    listenUser.Start();
                }
                catch
                {

                    Console.WriteLine("Ошбика в коннекте слушателя");
                }
            }
        }

        private void ListenUser(Socket userSocket)
        {
            byte[] data = new byte[packetLenght];
            int len;

            try
            {
                while (true)
                {
                    len = userSocket.Receive(data);

                    using (MemoryStream stream = new MemoryStream(data))
                    {
                        var mesg = formatter.Deserialize(stream) as String;

                        Console.WriteLine(mesg);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ошбика в слушателе");
            }
        }
    }
}
