using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootRabit
{
    using System;
    using System.Drawing;

    public abstract class CImageBase : IDisposable
    {
        private Bitmap bitmap;
        private bool isDisposed = false;

        protected CImageBase(Bitmap resource, int x, int y)
        {
            this.bitmap = new Bitmap(resource);
            this.Left = x;
            this.Top = y;
        }

        public int Left { get; set; }

        public int Top { get; set; }

        public void DrawImage(Graphics gfx)
        {
            gfx.DrawImage(this.bitmap, this.Left, this.Top);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool shouldDispose)
        {
            if (this.isDisposed)
                return;

            if (shouldDispose)
            {
                this.bitmap.Dispose();
            }

            this.isDisposed = true;
  
        }
    }

}
