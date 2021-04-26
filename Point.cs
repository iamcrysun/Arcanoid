using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Arcanoid
{
    public class Point
    {
        public int x, y, color;
        public Point() { }
        public Point(int initx, int inity, int initcolor)
        {
            x = initx;
            y = inity;
            color = initcolor;
        }
        void show(Graphics g)
        {
            //SetPixel(hdc, x, y, color);
        }
    }
}
