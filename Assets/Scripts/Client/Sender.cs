using Network;
using System.Net;
using System.Net.Sockets;
using System.Threading;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Scripts.Client
{
    public class Sender
    {
        public Sender()
        {
            //Connect();
            parser = new Parser();
            //listener = new Listener();
            //Thread td = new Thread(() => listener.Listen(socket));
            //td.Start();
        }

        private Socket socket;
        private Parser parser;
        private Listener listener;

        public void SendMessage(Message message)
        {
            Connect();
            StartListen();
            socket.Send(parser.GetSerializedMessage(message));
        }

        private void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //socket.Connect(IPAddress.Parse("127.0.0.1"), 8888);
            socket.Connect(IPAddress.Parse("91.202.20.14"), 8888);
        }



        private void StartListen()
        {
            listener = new Listener();
            Thread td = new Thread(() => listener.Listen(socket));
            td.Start();
        }
    }
}
//socket.Connect(IPAddress.Parse("91.202.20.14"), 8888);