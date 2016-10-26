using Assets.Core.Logic.Controllers;
using Assets.GameCore.Turrets.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.GameCore.Turrets.TurretsTypes
{
    class StandartTower : BaseTower
    {
        public StandartTower() : base(5, 1, 300, 100)
        {

        }
        private int temp;
        private void Awake()
        {
            gameControl = GameObject.Find("GameController").GetComponent<GameController>();

            if (gameControl != null)
            {
                gameControl.AddTower(gameObject);
            }
        }
    }
}
