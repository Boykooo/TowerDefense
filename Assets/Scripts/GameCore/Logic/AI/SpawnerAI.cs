using Assets.Core.Logic.Controllers;
using Assets.Core.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Core.Mobs.Skripts
{
    class SpawnerAI : MonoBehaviour
    {
        private int waveMobsAmount;
        private int waveNumber = 1;
        private int maximumWaves = 2;
        private int maxMobs = 10;
        private GameController gControl;
        private float waveDelayTimer = 1; //переменная таймера спауна волны
        public Transform Mob;

        private void Awake()
        {
            gControl = GameObject.Find("GameController").GetComponent<GameController>();
        }

        private void Update()
        {
            if (gControl.MobCount < maxMobs)
            {
                if (waveDelayTimer > 0) //если таймеh спауна волны больше нуля
                {
                    if (gControl != null)
                    {
                        if (gControl.MobCount == 0)
                        {
                            waveDelayTimer = 0; //если мобов на сцене нет - устанавливаем его в ноль
                        }
                        else
                        {
                            waveDelayTimer -= Time.deltaTime; //иначе отнимаем таймер ??????????
                        }
                    }
                }

                if (waveDelayTimer <= 0) //если таймер менее или равен нулю
                {
                    if (waveNumber < maximumWaves) //если не достигнут предел количества волн
                    {
                        Instantiate(Mob, gControl.wayPoints[0], Quaternion.identity); //спауним моба
                        gControl.MobCount++;
                        waveDelayTimer = 2;
                    }
                }
            }
        }
    }
}
