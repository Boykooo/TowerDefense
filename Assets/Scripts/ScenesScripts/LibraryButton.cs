using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryButton : MonoBehaviour {
    public bool showMenu;
    public GUISkin Menu;
    public Texture2D spell;
    public List<bool> buttons;
    
    int boxWidth = 500;
    int boxHeigt = 300;
    // Use this for initialization
    void Start () {
        showMenu = false;
        buttons = new List<bool>();
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
                GUI.Box(new Rect(Screen.width / 2 - boxWidth / 2, Screen.height / 2 - boxHeigt / 2, boxWidth, boxHeigt), "Библиотека"); //Создаем окно с меню 
                int x = Screen.width / 2 - boxWidth / 2 + 30;
                int y = Screen.height / 2 - boxHeigt / 2 + 50;
                int spellWidth = 80;
                int spellHeigt = 100;
                int cost = 15;
            for (int i = 0; i < 5; i++)
            {
                cost *= (i + 1);
                spell = Resources.Load("LibrarySpells/Spell" + i.ToString()) as Texture2D;
                GUI.DrawTexture(new Rect(x, y, spellWidth, spellHeigt), spell);
                GUI.Label(new Rect(x, y + 90, 80, 35), string.Format("{0} монет", cost));
                buttons.Add(GUI.Button(new Rect(x, y + 130, 80, 25), "Купить"));
                x += spellWidth + 10;
            }

            if (buttons.Count > 0)
            {
               for(int i=0;i<buttons.Count;i++)
                 if (buttons[i])
                    {
                        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 120, 50), "do something ");
                    }
            }
            if (GUI.Button(new Rect(Screen.width / 2-90, Screen.height / 2+90, 180, 30), "Выход"))
            {
                useGUILayout = false;
                showMenu = false;
            }
        }
    }
}
