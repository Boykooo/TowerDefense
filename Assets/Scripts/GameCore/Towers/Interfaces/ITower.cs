using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.GameCore.Turrets.Interfaces
{
    public interface ITower
    {
        // Изменить базовые значения
        void ChangeDamage(float newDamage);
        void ChangeAttackSpeed(float newSpeed);
        void ChangeAttackRadius(float newRadius);

        // Временно увиличить боевые характеристики башни -- баффы
        void ModifyDamage(float modDamage);
        void ModifyAttackSpeed(float modSpeed);
        void ModifyAttackRadius(float modRadius);


        // Вернуть базовые значения
        void SetBaseDamage();
        void SetBaseAttackSpeed();
        void SetBaseAttackRadius();

        float CurrentDamage { get; set; }
        float CurrentAttackSpeed { get; set; }
        float CurrentAttackRadius { get; set; }
    }
}
