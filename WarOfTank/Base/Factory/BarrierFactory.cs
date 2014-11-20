using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarOfTank.Base.Barrier;
namespace WarOfTank.Base.Factory
{
   
    public class BarrierFactory:IFactory
    {
        public override  Element factory(BarrierType type,int x,int y)
        {
            switch(type)
            {
                case BarrierType.RockBarrier: return new RockBarrier(x, y);
                case BarrierType.BrickBarrier: return new BrickBarrier(x, y);
                case BarrierType.GrassBarrier: return new GrassBarrier(x, y);
            }
            return null;
        }

    }
}
