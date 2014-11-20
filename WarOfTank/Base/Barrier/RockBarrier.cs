using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarOfTank.Base.Barrier
{
    public class RockBarrier:Barrier
    {
        public RockBarrier(int x, int y)
            : base(x, y)
        {
            this.image = Image.FromFile("BMP/Rock.BMP");
            this.imp = new Base.Behavior.NotHurtImpact();
            this.isCanCross = false;
        }
       
    }
}
