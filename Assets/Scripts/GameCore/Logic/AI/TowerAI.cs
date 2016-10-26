using UnityEngine;
using System.Collections;
using Assets.GameCore.Turrets.AbstractClasses;
using Assets.GameCore.Turrets.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Assets.Mobs.Interfaces;
using Assets.Core.Mobs.AbstractClasses;
using System;
using Assets.Core.Logic.Interfaces;
using Assets.Core.Logic.Controllers;
using Assets.GameCore.Turrets.TurretsTypes;

public class TowerAI : MonoBehaviour {
	// Use this for initialization
	void Start () {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

       tower = gameController.GetTower(gameObject.name);

        //tower = new StandartTower();
        timerShoot = tower.CurrentAttackSpeed;

    }

    private GameObject currTarget;
    private float timerShoot;
    private GameController gameController;

    //public Transform towerModel;
    private ITower tower;

	// Update is called once per frame
	void Update () {
        if (tower != null)
        {
            if (currTarget != null)
            {
                if (Vector3.Distance(transform.position, currTarget.transform.position) <= tower.CurrentAttackRadius)
                {
                    if (timerShoot > 0) timerShoot -= Time.deltaTime;
                    if (timerShoot < 0) timerShoot = 0;

                    if (timerShoot == 0)
                    {
                        IMob mob = currTarget.GetComponent<BaseMob>(); // инициализируем интерфейс моба


                        CreateShoot(transform.position, currTarget.transform.position);

                        //

                        mob.ChangeHP(tower.CurrentDamage); // отнимаем у него хп равное урону башни

                        timerShoot = tower.CurrentAttackSpeed; // возвращаем таймер скорости стрельбы башни в исходное положение
                    }
                }
                else
                {
                    currTarget = null;
                }
            }
            else
            {
                currTarget = FindTarget();
            }
        }
	}

    private GameObject FindTarget()
    {
        GameObject nearestMob = null;
        //float closestMobDistance = 0;

        List<GameObject> mobs = GameObject.FindGameObjectsWithTag("Mob").ToList();
        foreach (var mob in mobs)
        {
            if (Vector3.Distance(mob.transform.position, transform.position) < tower.CurrentAttackRadius)
            {
                //closestMobDistance = Vector3.Distance(mob.transform.position, turretModel.position);
                nearestMob = mob;
                break;
            }
        }

        return nearestMob;
    } 

    private void CreateShoot(Vector3 start, Vector3 target)
    {
        start.y = 5;
        target.y = 3;
        GameObject q = gameController.arrow;
        ArrowMove arr = q.GetComponent<ArrowMove>();
        arr.target = target;
        arr.start = start;
        q.transform.LookAt(target);

        GameObject arrow = Instantiate(q, start, Quaternion.identity) as GameObject;
        float speed = 5;
        //arrow.transform.position = Vector3.MoveTowards(start, target, speed * Time.deltaTime);
    }
}
