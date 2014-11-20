using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarOfTank.Base;
namespace WarOfTank.Base.Bullet
{
    abstract class Bullet:Element
    {
        int power;//子弹威力
        public Bullet(int x, int y,Direction dir)
            : base(x, y)
        {
            this.direction = dir;
            this.speed = 3;
            this.power = 1;
            this.blood = 1;
            this.imp = new Behavior.HurtImpact();
            //Thread moveThread = new Thread(new ThreadStart(Move));
            //moveThread.Start();
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

        public override void Boom()
        {
            //base.Boom();
        }
    }
}
