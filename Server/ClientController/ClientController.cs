using Server.Interfaces;
using System.Collections.Generic;
using Network;
using System.Net.Sockets;
using Server.ClientController.IdManager;
using Server.ClientController.ParseMessage;
using Server.ClientController.ListenerController;
using System.Threading;
using Proxy;
using System;
using System.Linq;

namespace Server.ClientController
{
    public class ClientController : IClientController
    {
        public ClientController(IServerFacade serverFacade)
        {
            clients = new Dictionary<int, Socket>();
            online = new Dictionary<string, int>();
            idManager = new IDManager();
            parser = new Parser();

            serverFacade.Disconnect += (x) => RemoveClient(x);
            listener = new Listener(serverFacade);
            listener.Disconnect += (x) => RemoveClient(x);
        }

        private Dictionary<int, Socket> clients;
        private Dictionary<string, int> online;
        private IDManager idManager;
        private Parser parser;
        private Listener listener;
        private object key = new object();



        public void AddNewClient(Socket clientSocket)
        {
            lock (key)
            {
                int id = idManager.GetID();
                Console.WriteLine(id);
                clients.Add(id, clientSocket);
                Thread td = new Thread(() => listener.ListenClient(id, clientSocket));
                td.Start();
            }
        }
        public Socket GetClient(int id)
        {
            lock (key)
            {
                if (clients.ContainsKey(id))
                {
                    return clients[id];
                }
            }

            return null;
        }
        public void RemoveClient(int id)
        {
            lock (key)
            {
                // затестить
                if (clients.ContainsKey(id))
                {
                    clients[id].Dispose();
                    clients.Remove(id);

                    string login = online.FirstOrDefault(x => x.Value == id).Key;   // Очень медленно
                    if (login != null)
                    {
                        online.Remove(login);
                    }

                    idManager.AddID(id); // освобождаем id

                    Console.WriteLine("Соединение с клиентом id = {0} разорвано", id);
                }
            }
        }
        public void Send(int id, Message msg)
        {
            lock (key)
            {
                if (clients.ContainsKey(id))
                {
                    clients[id].Send(parser.GetSerializedMessage(msg));
                }
            }
        }
        public void Send(string login, Message msg)
        {
            lock (key)
            {
                if (online.ContainsKey(login))
                {
                    Send(online[login], msg);
                }
            }
        }
        public void AddOnlineUser(string login, int id)
        {
            lock (key)
            {
                online.Add(login, id);
            }
        }
        public bool isOnline(string login)
        {
            return online.ContainsKey(login);
        }
    }
}
