using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private void Start()
    {

    }

    public InputField login;
    public InputField password;


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void EnterTheGame()
    {

    }
    public void Registration()
    {

    }
}
