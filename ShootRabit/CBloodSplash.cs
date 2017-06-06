using ShootRabit.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootRabit
{
    using Properties;

    class CBloodSplash : CImageBase
    {
        public CBloodSplash(int x, int y) 
            : base(Resources.BloodSplash, x, y)
        {
        }
    }
}
