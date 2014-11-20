using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarOfTank.Base;
namespace WarOfTank.Base.Barrier
{
    public abstract class Barrier:Element
    {
        protected bool isCanCross;  //障碍物是否可穿过

        public bool IsCanCross
        {
            get { return isCanCross; }
        }
        public Barrier(int x, int y):base(x,y)
        {
            this.speed = 0;
            this.blood = 4;
            this.imp=new Behavior.HurtImpact();
        }
    }
}
