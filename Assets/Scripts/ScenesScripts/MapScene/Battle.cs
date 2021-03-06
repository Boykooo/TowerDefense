﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Battle : MonoBehaviour {
    public bool showMenu;
    public GUISkin Menu;
    public Texture2D picture;
    // Use this for initialization
    void Start () {
        showMenu = false;
	}
	
	// Update is called once per frame
	void Update () {
	
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
        GUI.skin = Menu;
        if (showMenu)
        {
                GUI.Box(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 150, 500, 300), "Битва"); //Создаем окно с меню 
                GUI.Label(new Rect(Screen.width / 2-200, Screen.height / 2-100,400,200),"Уровень сложности битвы " + 10);
                GUI.DrawTexture(new Rect(Screen.width / 2 -140, Screen.height / 2 -115, 280, 250),picture, ScaleMode.ScaleToFit, true);


            if (GUI.Button(new Rect(Screen.width / 2 - 180, Screen.height / 2 + 100, 180, 30), "Вступить в битву"))
            {
               
            }
            if (GUI.Button(new Rect(Screen.width / 2 +20, Screen.height / 2 + 100, 180, 30), "Выход"))
                {
                    useGUILayout = false;
                    showMenu = false;
                }
            }
    }
}
