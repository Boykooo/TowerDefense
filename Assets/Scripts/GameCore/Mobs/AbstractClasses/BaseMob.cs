using Assets.Core.Logic.Controllers;
using Assets.Core.Logic.Interfaces;
using Assets.Mobs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Core.Mobs.AbstractClasses
{
    abstract class BaseMob : MonoBehaviour, IMob
    {
        protected float mobHP;
        protected int mobPrice; //цена за убийство моба
        protected GameController gControl;

        public virtual void ChangeHP(float damage)
        {
            mobHP -= damage;
        }

        public virtual void testDeath()
        {
        }
    }
}
