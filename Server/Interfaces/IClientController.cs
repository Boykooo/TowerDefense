using System.Net.Sockets;

namespace Server.Interfaces
{
    public interface IClientController : ICommunication
    {
        //Действия со словарем клиентов
        void AddNewClient(Socket clientSocket);
        void RemoveClient(int id);
        Socket GetClient(int id);
    }
}
