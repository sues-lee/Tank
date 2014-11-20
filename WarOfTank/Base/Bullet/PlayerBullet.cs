using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WarOfTank.Base.Bullet
{
    class PlayerBullet:Bullet
    {
        public PlayerBullet(int x, int y, Direction dir)
            : base(x, y, dir)
        {
            this.image = Image.FromFile("BMP/Bullet1.bmp");
        }
    }
}
