using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WarOfTank.Properties;
namespace WarOfTank.Base.Barrier
{
    class BrickBarrier:Barrier
    {
        public BrickBarrier(int x, int y)
            : base(x, y)
        {
            this.image = Image.FromFile("BMP/Brick.BMP");
            this.isCanCross = false;
        }
    }
}
