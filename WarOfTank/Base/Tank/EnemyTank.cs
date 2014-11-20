using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WarOfTank.Base.Factory;
namespace WarOfTank.Base.Tank
{
    public class EnemyTank:Tank
    {
        TankMod mod;        //敌人坦克类型
        private Random rdm = new Random();  //用随机数控制敌方坦克
        private IFactory bulletFactory = new BulletFactory(); 
        public EnemyTank(int x, int y,TankMod mod)
            : base(x, y)
        {
            this.mod = mod;
            if (mod==TankMod.Mod1)
            {
                blood = 1;
            }
            setDirection(Direction.Down);
        }
        public override void setDirection(Direction dir)
        {
            direction = dir;

            if (mod==TankMod.Mod1)
            {
                switch (dir)
                {
                    case Direction.Up:
                        this.image = Image.FromFile("BMP/enemy1U.gif");
                        break;
                    case Direction.Down:
                        this.image = Image.FromFile("BMP/enemy1D.gif");
                        break;
                    case Direction.Right:
                        this.image = Image.FromFile("BMP/enemy1R.gif");
                        break;
                    case Direction.Left:
                        this.image = Image.FromFile("BMP/enemy1L.gif");
                        break;
                    default:
                        break;
                }
            }
            else if (mod == TankMod.Mod2)
            {
                switch (dir)
                {
                    case Direction.Up:
                        this.image = Image.FromFile("BMP/enemy2U.gif");
                        break;
                    case Direction.Down:
                        this.image = Image.FromFile("BMP/enemy2D.gif");
                        break;
                    case Direction.Right:
                        this.image = Image.FromFile("BMP/enemy2R.gif");
                        break;
                    case Direction.Left:
                        this.image = Image.FromFile("BMP/enemy2L.gif");
                        break;
                    default:
                        break;
                }
            }
           
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
            if (rdm.Next(0,6)==0)
            {
                NewDirection();
            }
        }
        /// <summary>
        /// 设置新的方向
        /// </summary>
        public void NewDirection()
        {
            switch (rdm.Next(0,4))
            {
                case 0:
                    this.setDirection(Direction.Up);
                    break;
                case 1:
                    this.setDirection(Direction.Right);
                    break;
                case 2:
                    this.setDirection(Direction.Left);
                    break;
                case 3:
                    this.setDirection(Direction.Down);
                    break;
            }
        }
        /// <summary>
        /// 重写射击方法
        /// </summary>
        /// <returns></returns>
        public override Element shot()
        {
            switch (direction)
            {
                case Direction.Up:
                    return bulletFactory.factory(BulletType.AnamyBullet, this.PosX, this.PosY - 1, this.EleDirection);

                case Direction.Down:
                    return bulletFactory.factory(BulletType.AnamyBullet, this.PosX, this.PosY + 1, this.EleDirection);

                case Direction.Right:
                    return bulletFactory.factory(BulletType.AnamyBullet, this.PosX + 1, this.PosY, this.EleDirection);

                case Direction.Left:
                    return bulletFactory.factory(BulletType.AnamyBullet, this.PosX - 1, this.PosY, this.EleDirection);

                default:
                    break;
            }
            return null;

        }
    }
}
