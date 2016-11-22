using Server.Interfaces;
using System;
using System.Net;
using System.Net.Sockets;
using Network;

namespace Server
{
    [Serializable]
    class ServerSocket : IServer
    {
        public ServerSocket(IServerController clientController)
        {
            this.clientController = clientController;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            maxQueue = 10;
            parser = new Parser();
            
        }

        private Socket socket;
        private const int port = 8888;
        private int maxQueue;

        private IServerController clientController;
        private Parser parser;

        private void AcceptNewClient()
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, port));
            socket.Listen(maxQueue);

            while (true)
            {
                try
                {
                    Socket client = socket.Accept();
                    clientController.AddNewClient(client);
                    Console.WriteLine("Установлено соединение с {0}", client.RemoteEndPoint);
                }
                catch
                {
                    Console.WriteLine("Ошибка в коннекте нового юзера");
                }
            }
        }
        public void Start()
        {
            AcceptNewClient();
        }
    }
}


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