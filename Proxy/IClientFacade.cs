
namespace Proxy
{
    public interface IClientFacade
    {
        void ErrorSignIn(string message);
        void EnterTheGame(string login);

        void ErrorSignUp(string message);
        void SuccessfulSignUp();
    }
}
