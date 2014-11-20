using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarOfTank.Base.Tank;
namespace WarOfTank.Base.Factory
{
    class PlayerTankFactory:IFactory
    {
        public override Element factory(TankType type, int x, int y)
        {
            switch (type)
            {
                case TankType.PlayerTank: return new PlayerTank(x, y);
            }
            return null;
        }

    }
}
