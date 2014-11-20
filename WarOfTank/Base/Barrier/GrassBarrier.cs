using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WarOfTank.Base.Barrier
{
    class GrassBarrier:Barrier
    {
        public GrassBarrier(int x, int y)
            : base(x, y)
        {
            this.image = Image.FromFile("BMP/Grass.gif");
            this.isCanCross = true;
        }
    }
}
