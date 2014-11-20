using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarOfTank.Base.Bullet;
namespace WarOfTank.Base.Factory
{
    class BulletFactory : IFactory
    {
      
        public override Element factory(BulletType type, int x, int y,Direction dir)
        {
            switch (type)
            {
                case BulletType.PlayerBullet: return new PlayerBullet(x, y, dir);
                case BulletType.AnamyBullet: return new EnemyBullet(x, y, dir);                 
            }
            return null;
        }
    }
}
