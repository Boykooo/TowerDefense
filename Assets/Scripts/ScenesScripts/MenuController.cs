using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{

    private void Start()
    {

    }

    public GUISkin q;
    public Texture signInTexture;

    private void Update()
    {

    }
    private void OnGUI()
    {
        GUI.skin = q;
        if (GUI.Button(new Rect(200, 200, 100, 100), signInTexture))
        {

        }
    }
}
