using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Mobs.Interfaces
{
    public interface IMob
    {
        void ChangeHP(float damage);
        void testDeath();
    }
}
