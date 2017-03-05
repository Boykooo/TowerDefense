using System.Net.Sockets;

namespace Server.Interfaces
{
    public interface IServerController : ICommunication
    {
        //Действия со словарем клиентов
        void AddNewClient(Socket clientSocket);
        void RemoveClient(int id);
        Socket GetClient(int id);
    }
}
