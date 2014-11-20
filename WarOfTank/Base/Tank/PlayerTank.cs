using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarOfTank.Base.Factory;
namespace WarOfTank.Base.Tank
{
    public class PlayerTank:Tank
    {
        private IFactory bulletFactory = new BulletFactory(); 
        public PlayerTank(int x, int y)
            : base(x, y)
        {
            this.image = Image.FromFile("BMP/p1tankU.gif");
        }
        public override void setDirection(Direction dir)
        {
            direction = dir;
            switch (dir)
            {
                case Direction.Up:
                    this.image = Image.FromFile("BMP/p1tankU.gif");
                    break;
                case Direction.Down:
                    this.image = Image.FromFile("BMP/p1tankD.gif");
                    break;
                case Direction.Right:
                    this.image = Image.FromFile("BMP/p1tankR.gif");
                    break;
                case Direction.Left:
                    this.image = Image.FromFile("BMP/p1tankL.gif");
                    break;
                default:
                    break;
            }
        }

        public override Element shot()
        {
            switch (direction)
            {
                case Direction.Up:
                    return bulletFactory.factory(BulletType.PlayerBullet, this.PosX, this.PosY - 1, this.EleDirection);

                case Direction.Down:
                    return bulletFactory.factory(BulletType.PlayerBullet, this.PosX, this.PosY + 1, this.EleDirection);

                case Direction.Right:
                    return bulletFactory.factory(BulletType.PlayerBullet, this.PosX + 1, this.PosY, this.EleDirection);

                case Direction.Left:
                    return bulletFactory.factory(BulletType.PlayerBullet, this.PosX - 1, this.PosY, this.EleDirection);

                default:
                    break;
            }
            return null;

        }
    }
}
