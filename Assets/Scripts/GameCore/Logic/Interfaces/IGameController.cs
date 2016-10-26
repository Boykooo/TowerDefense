using Assets.GameCore.Turrets.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Core.Logic.Interfaces
{
    interface IGameController
    {
        int PlayerMoney { get; set; }
        int MobCount { get; set; }
        Vector3[] wayPoints { get; }
        void AddMob(GameObject obj);
        void RemoveMob(GameObject obj);
        void AddTower(GameObject obj);
        void RemoveTower(GameObject obj);
        BaseTower GetTower(string name);
    }
}
