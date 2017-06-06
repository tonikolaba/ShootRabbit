using ShootRabit.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootRabit
{
    using System.Drawing;
    using Properties;

    public class CRabbit : CImageBase
    {
        private const int RectangleX = 20;

        public Rectangle moleHotSpot = new Rectangle();

        public CRabbit(int x, int y)
            : base(Resources.rabbit, x, y)
        {
            this.moleHotSpot.X = this.Left + RectangleX;
            this.moleHotSpot.Y = this.Top;
            this.moleHotSpot.Width = 30;
            this.moleHotSpot.Height = 40;
        }

        public void Update(int x, int y)
        {
            this.Left = x;
            this.Top = y;
            this.moleHotSpot.X = this.Left + RectangleX;
            this.moleHotSpot.Y = this.Top;
        }

        public bool Hit(int x, int y)
        {
            Rectangle c = new Rectangle(x, y, 1, 1);

            if (this.moleHotSpot.Contains(c))
            {
                return true;
            }

            return false;
        }
    }

}
