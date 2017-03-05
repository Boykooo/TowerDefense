using Network;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts.Client
{
    public class Listener
    {
        public Listener()
        {
            clientFacade = GameObject.FindGameObjectWithTag("ClientFacade").GetComponent<ClientFacade>();
            clientFacade.disconnect += () => Disconnect();
            parser = new Parser();
        }

        private Parser parser;
        private const int packetLenght = 5000;
        private ClientFacade clientFacade;
        private Socket socket;

        public void Listen(Socket socket)
        {
            this.socket = socket;
            if (clientFacade != null)
            {
                byte[] data = new byte[packetLenght];
                try
                {
                    while (true)
                    {
                        socket.Receive(data); // ???

                        Message message = parser.GetMessage(data);

                        if (message != null)
                        {
                            clientFacade.GetType().GetMethod(message.Method).Invoke(clientFacade, message.Arguments);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Разрыв соединения");
                }
            }
           
        }

        private void Disconnect()
        {
            socket.Dispose();
            socket = null;
        }
    }
}
