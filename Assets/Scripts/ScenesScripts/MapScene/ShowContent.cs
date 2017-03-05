using UnityEngine;
using System.Collections;

public class ShowContent : MonoBehaviour
{
    public bool showMenu; //Отображать ли меню  
    public GUISkin BoxBack;
    void Start()
    {
        showMenu = false;
    }

    void Update()
    {

    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            showMenu = true;
        }
    }

    void OnGUI()
    {
        if (showMenu)
        {
            GUI.skin = BoxBack;
            int x = 1;
                Rect menu = new Rect(Screen.width / 2 - 250, Screen.height / 2 - 150, 500, 300);
                GUI.Box(menu,"Ресурсы"); 
                GUI.Label(new Rect(menu.x+20,menu.y+20,menu.width-40,40),x +"  УРОВЕНЬ");
                if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height/2+100 , 180, 30), "Выход"))
                {
                    useGUILayout = false;
                    showMenu = false;
                }
           
        }
    }
}

