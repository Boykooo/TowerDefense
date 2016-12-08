using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Proxy;
using Assets.Scripts.Client;

public class MenuController : MonoBehaviour
{
    private void Start()
    {
        facade = new ClientController();
    }

    public InputField login;
    public InputField password;

    private IServerFacade facade;
    private const int magicID = -1;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void EnterTheGame()
    {
        facade.SignIn(login.text, password.text, magicID);
    }
    public void Registration()
    {

    }
}
