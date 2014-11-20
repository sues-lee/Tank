using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarOfTank.Base.Tank;

namespace WarOfTank.Base.Factory
{
    public class EnemyTankFactory : IFactory
    {
        public override Element factory(TankMod mod, int x, int y)
        {
               return new EnemyTank(x,y,mod);
        }
    }
}
