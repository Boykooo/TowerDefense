using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimeTide : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        minute = 0;
        seconds = 0;
        text = GetComponent<Text>();
        text.transform.position = new Vector3(Screen.width / 2, Screen.height - Screen.height / 10, 0);
	}

    private double seconds;
    private int minute;
    private Text text;

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds > 59)
        {
            minute += 1;
            seconds = 0;
        }
        text.text = "Time : " + minute.ToString() + "." + seconds.ToString("f0");
    }
}
