using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delay1
{
    class Player
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }

        public void Initialize(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }
    }
}
