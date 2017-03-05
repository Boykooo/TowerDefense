using UnityEngine;
using System.Collections;

public class TowerDrawing : MonoBehaviour {

    public bool showMenu;
    public GUISkin Menu;
    public Texture2D drawing;

    int boxWidth = 500;
    int boxHeigt = 300;
    // Use this for initialization
    void Start()
    {
        showMenu = false;
    }

    public void Click()
    {
        showMenu = true;
    }

    void OnGUI()
    {
        GUI.skin = Menu;
        if (showMenu)
        {
            GUI.Box(new Rect(Screen.width / 2 - boxWidth / 2, Screen.height / 2 - boxHeigt / 2, boxWidth, boxHeigt), "Кузница"); //Создаем окно с меню 
            int x = Screen.width / 2 - boxWidth / 2 + 30;
            int y = Screen.height / 2 - boxHeigt / 2 + 50;
            int spellWidth = 80;
            int spellHeigt = 100;

            int cost = 50;
            drawing = Resources.Load("Towers/tower0") as Texture2D;
            GUI.DrawTexture(new Rect(x, y, spellWidth, spellHeigt), drawing);
            GUI.Label(new Rect(x, y + 90, 80, 35), string.Format("{0} монет", cost));
            if (GUI.Button(new Rect(x, y + 130, 80, 25), "Купить"))
            {
                //отправляем запрос на покупку
            }
            x += spellWidth + 10;

            cost = 90;
            drawing = Resources.Load("Towers/tower1") as Texture2D;
            GUI.DrawTexture(new Rect(x, y, spellWidth, spellHeigt), drawing);
            GUI.Label(new Rect(x, y + 90, 80, 35), string.Format("{0} монет", cost));
            if (GUI.Button(new Rect(x, y + 130, 80, 25), "Купить"))
            {

            }
            x += spellWidth + 10;

            cost = 150;
            drawing = Resources.Load("Towers/tower2") as Texture2D;
            GUI.DrawTexture(new Rect(x, y, spellWidth, spellHeigt), drawing);
            GUI.Label(new Rect(x, y + 90, 80, 35), string.Format("{0} монет", cost));
            if (GUI.Button(new Rect(x, y + 130, 80, 25), "Купить"))
            {

            }
            x += spellWidth + 10;

            cost = 300;
            drawing = Resources.Load("Towers/tower3") as Texture2D;
            GUI.DrawTexture(new Rect(x, y, spellWidth, spellHeigt), drawing);
            GUI.Label(new Rect(x, y + 90, 80, 35), string.Format("{0} монет", cost));
            if (GUI.Button(new Rect(x, y + 130, 80, 25), "Купить"))
            {

            }
            x += spellWidth + 10;

            cost = 500;
            drawing = Resources.Load("Towers/tower4") as Texture2D;
            GUI.DrawTexture(new Rect(x, y, spellWidth, spellHeigt), drawing);
            GUI.Label(new Rect(x, y + 90, 80, 35), string.Format("{0} монет", cost));
            if (GUI.Button(new Rect(x, y + 130, 80, 25), "Купить"))
            {

            }
            x += spellWidth + 10;

            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 90, 180, 30), "Выход"))
            {
                useGUILayout = false;
                showMenu = false;
            }
        }
    }
}
