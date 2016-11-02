using Network;

namespace Server.Interfaces
{
    public interface ICommunication
    {
        //Отправка сообщений
        void Send(int id, Message msg);

        // Действия со списком онлайн юзеров
        void AddOnlineUser(int id, string login);
        bool isOnline(string login);
    }
}
