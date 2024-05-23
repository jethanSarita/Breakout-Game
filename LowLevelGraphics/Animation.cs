using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LowLevelGraphics
{
    internal class Animation
    {
        Bitmap[] frames;

        int index = 0;

        public Animation(Bitmap[] frames)
        {
            this.frames = frames;
        }

        public Bitmap GiveNextImage()
        {
            Bitmap b = frames[index++];
            if(index >= frames.Length)
            {
                index = 0;
            }
            return b;
        }
    }
}
