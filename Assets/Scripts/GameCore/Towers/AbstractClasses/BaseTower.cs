using Assets.Core.Logic.Controllers;
using Assets.Core.Logic.Interfaces;
using Assets.GameCore.Turrets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.GameCore.Turrets.AbstractClasses
{
    abstract class BaseTower : MonoBehaviour, ITower
    {
        public BaseTower(float damage, float attackSpeed, float attackRadius, int price)
        {
            CurrentDamage = baseDamage = damage;
            CurrentAttackSpeed = baseAttackSpeed = attackSpeed;
            CurrentAttackRadius = baseAttackRadius = attackRadius;
            this.price = price;
        }

        protected int price;
        protected GameController gameControl;

        protected float baseDamage;
        protected float baseAttackSpeed;
        protected float baseAttackRadius;

        public float CurrentDamage { get; set; }
        public float CurrentAttackSpeed { get; set; }
        public float CurrentAttackRadius { get; set; }

        public void ChangeAttackRadius(float newAttackRadius)
        {
            CurrentAttackRadius = baseAttackRadius = newAttackRadius;
        }
        public void ChangeAttackSpeed(float newAttackSpeed)
        {
            CurrentAttackSpeed = baseAttackSpeed = newAttackSpeed;
        }
        public void ChangeDamage(float newDamage)
        {
            CurrentDamage = baseDamage = newDamage;
        }

        public void ModifyDamage(float modDamage)
        {
            CurrentDamage += CurrentDamage*modDamage;
        }
        public void ModifyAttackSpeed(float modSpeed)
        {
            CurrentAttackSpeed += CurrentAttackSpeed * modSpeed;
        }
        public void ModifyAttackRadius(float modRadius)
        {
            CurrentAttackRadius += CurrentAttackRadius * modRadius;
        }

        public void SetBaseDamage()
        {
            CurrentDamage = baseDamage;
        }
        public void SetBaseAttackSpeed()
        {
            CurrentAttackSpeed = baseAttackSpeed;
        }
        public void SetBaseAttackRadius()
        {
            CurrentAttackRadius = baseAttackRadius;
        }

        
    }
}
