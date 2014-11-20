using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarOfTank.Base.Tank;

namespace WarOfTank.Base.Factory
{
    public enum BarrierType
    {
        RockBarrier,
        BrickBarrier,
        GrassBarrier,
    }
    public enum TankType
    {
        PlayerTank,
    }
    public enum BulletType
    {
        PlayerBullet,
        AnamyBullet,
    }
    public abstract class IFactory
    {
        public virtual Element factory(BarrierType type, int x, int y)
        { return null; }
        public  virtual Element factory(TankType type, int x, int y)
        { return null; }
        public virtual Element factory(BulletType type, int x, int y,Direction dir)
        { return null; }
        public virtual Element factory(TankMod mod, int x, int y)
        { return null; }
    }
}
