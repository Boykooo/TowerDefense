using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryButton : MonoBehaviour {
    public bool showMenu;
    public GUISkin Menu;
    public Texture2D spell;
    
    int boxWidth = 500;
    int boxHeigt = 350;
    // Use this for initialization
    void Start () {
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
            GUI.Box(new Rect(Screen.width / 2 - boxWidth / 2, Screen.height / 2 - boxHeigt / 2, boxWidth, boxHeigt), "Библиотека"); //Создаем окно с меню 
            int x = Screen.width / 2 - boxWidth / 2 + 30;
            int y = Screen.height / 2 - boxHeigt / 2 + 50;
            int spellWidth = 80;
            int spellHeigt = 100;

            int cost = 15;
            spell = Resources.Load("LibrarySpells/Spell0") as Texture2D;
            GUI.DrawTexture(new Rect(x, y, spellWidth, spellHeigt),spell);
            GUI.Label(new Rect(x, y + 90, 80, 35), string.Format("{0} монет", cost));
            if (GUI.Button(new Rect(x, y + 130, 80, 25), new GUIContent("Купить", "Заклинание позволяет кидать огненные шары в монстров")))
            {
                //отправляем запрос на покупку
            }
            x += spellWidth + 10;

            cost = 45;
            spell = Resources.Load("LibrarySpells/Spell1") as Texture2D;
            GUI.DrawTexture(new Rect(x, y, spellWidth, spellHeigt), spell);
            GUI.Label(new Rect(x, y + 90, 80, 35), string.Format("{0} монет", cost));
            if (GUI.Button(new Rect(x, y + 130, 80, 25), new GUIContent("Купить" , "Заклинание увеличивает скорость атаки башен на 50% ")))
            {

            }
            x += spellWidth + 10;

            cost = 80;
            spell = Resources.Load("LibrarySpells/Spell2") as Texture2D;
            GUI.DrawTexture(new Rect(x, y, spellWidth, spellHeigt), spell);
            GUI.Label(new Rect(x, y + 90, 80, 35), string.Format("{0} монет", cost));
            if (GUI.Button(new Rect(x, y + 130, 80, 25), new GUIContent("Купить", "Заклинание увеличивает урон, наносимый монстрам на 50%")))
             {

            }
            x += spellWidth + 10;

            cost = 150;
            spell = Resources.Load("LibrarySpells/Spell3") as Texture2D;
            GUI.DrawTexture(new Rect(x, y, spellWidth, spellHeigt), spell);
            GUI.Label(new Rect(x, y + 90, 80, 35), string.Format("{0} монет", cost));
            if (GUI.Button(new Rect(x, y + 130, 80, 25), new GUIContent("Купить", "Заклинание замедляет монстров на 30% ")))
            {

            }
            x += spellWidth + 10;

            cost = 300;
            spell = Resources.Load("LibrarySpells/Spell4") as Texture2D;
            GUI.DrawTexture(new Rect(x, y, spellWidth, spellHeigt), spell);
            GUI.Label(new Rect(x, y + 90, 80, 35), string.Format("{0} монет", cost));
            if(GUI.Button(new Rect(x, y + 130, 80, 25), new GUIContent("Купить", "Заклинание ")))
            {

            }
            GUI.Label(new Rect(Screen.width / 2 - boxWidth / 2, y + 150, 500,80), GUI.tooltip);
            x += spellWidth + 10;

            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 110, 180, 30), "Выход"))
            {
                useGUILayout = false;
                showMenu = false;
            }
        }
    }
}
