using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Threading;
using System.Collections.Generic;

public class MessageBox : MonoBehaviour
{
    private void Start()
    {
        boxX = 0;
        boxY = 0;
        boxWidth = 250;
        boxHeight = 150;

        buttonWidth = 70;
        buttonHeight = 30;
    }

    private bool update;
    private string error;

    private int buttonWidth;
    private int buttonHeight;

    public int boxX;
    public int boxY;
    public int boxWidth;
    public int boxHeight;

    public void Show(string message)
    {
        error = message;
        update = true;
    }

    private void OnGUI()
    {
        if (update)
        {
            GUI.skin.box.wordWrap = true;
            GUI.skin.box.fontSize = 18;
            GUI.skin.button.fontSize = 18;

            GUI.Box(new Rect(boxX, boxY, boxWidth, boxHeight), error);

            if (GUI.Button(new Rect(boxWidth - buttonWidth - 10, boxHeight - buttonHeight - 10, buttonWidth, buttonHeight), "OK"))
            {
                update = false;
            }
        }
    }
}
