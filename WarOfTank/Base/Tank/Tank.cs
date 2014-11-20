using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarOfTank.Base.Factory;
using WarOfTank.Base.Bullet;
using System.Drawing;
namespace WarOfTank.Base.Tank
{
    public enum TankMod
    {
        Mod1,
        Mod2,
    }
   public abstract class Tank:Element
    {

       public Tank(int x, int y)
            : base(x, y)
        {
            direction = Direction.Up;
            this.blood = 2;
            this.imp = new Base.Behavior.HurtImpact();
        }
       /// <summary>
       /// 按照direction移动一格
       /// </summary>
       public override void Move()
       {
           switch (direction)
           {
               case Direction.Up:
                   this.posY--;
                   break;
               case Direction.Down:
                   this.posY++;
                   break;
               case Direction.Right:
                   this.posX++;
                   break;
               case Direction.Left:
                   this.posX--;
                   break;
               default:
                   break;
           }
       }

 
      
    }
}
