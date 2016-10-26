using Assets.Core.Logic.Controllers;
using Assets.Core.Mobs.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Core.Mobs.MobsTypes
{
    class Mob_War : BaseMob
    {
        private void Awake()
        {
            gControl = GameObject.Find("GameController").GetComponent<GameController>();
            mobHP = 30;
            mobPrice = 5;
            if (gControl != null)
            {
                gControl.AddMob(gameObject); //добавляем себя в общий лист мобов
                gControl.MobCount++; //увеличиваем счетчик мобов
            }
        }

        private void Update()
        {
            if (mobHP <= 0)
            {
                gControl.PlayerMoney += mobPrice;
                Destroy(gameObject);
            }
        }

        private void OnDestroy() //при удалении
        {
            if (gControl != null)
            {
                gControl.RemoveMob(gameObject); //удаляем себя из глобального списка мобов
            }
        }

        public override void testDeath()
        {
            base.testDeath();
            Destroy(gameObject);
        }
    }
}
