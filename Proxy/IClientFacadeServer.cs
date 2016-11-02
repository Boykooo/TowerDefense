
namespace Proxy
{
    public interface IClientFacadeServer
    {
        void ErrorSignIn(int id, string message);
        void EnterTheGame(int id, string login);

        void ErrorSignUp(int id, string error);
        void SuccessfulSignUp(int id);
    }
}
