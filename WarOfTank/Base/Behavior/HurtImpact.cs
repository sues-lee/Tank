using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarOfTank.Base.Behavior
{
    public class HurtImpact:IImpactBehavior
    {
        public  void Impact(Element ele)
        {
            ele.Blood--;
        }
    }
}
