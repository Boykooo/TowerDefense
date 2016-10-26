using UnityEngine;
using System.Collections;
using Assets.Core.Logic.Controllers;
using Assets.Core.Logic.Interfaces;
using Assets.Mobs.Interfaces;
using Assets.Core.Mobs.MobsTypes;

public class MobAI : MonoBehaviour
{

    public float minSpeed = 3.5f; //минимальная скорость моба
    public float maxSpeed = 7.0f; //максимальная скорость моба
    public float mobRotationSpeed = 2.5f; //скорость поворота моба

    private GameController gControl; //поле для объекта глобальных переменных
    private int currPoint;
    private float currSpeed;
    private void Awake()
    {
        gControl = GameObject.Find("GameController").GetComponent<GameController>();
        currSpeed = maxSpeed;
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    private void Update()
    {
        if (transform.position == gControl.wayPoints[currPoint])
        {
            currPoint++;
            RotateObj();
            if (currPoint == gControl.wayPoints.Length)
            {
                currPoint--;
                IMob q = GameObject.Find("Mob_War").GetComponent<Mob_War>();
                q.testDeath();
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, gControl.wayPoints[currPoint], currSpeed * Time.deltaTime);
    }

    private void RotateObj()
    {
        switch (currPoint)
        {
            case 2 :
                transform.eulerAngles = new Vector3(0, 90, 0);
                break;
            case 3:
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 4:
                transform.eulerAngles = new Vector3(0, 90, 0);
                break;
            case 5:
                transform.eulerAngles = new Vector3(0, 90, 0);
                break;
            default:
                break;
        }
    }
}
