using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Arcanoid
{
    public class Platform
    {
        public int x, y, dx, dy, color, v;
        public Platform(int initx, int inity, int initdx, int initdy, int initcolor, int initv)
        {
            x = initx;
            y = inity;
            dx = initdx;
            dy = initdy;
            color = initcolor;
            v = initv;
        }
        Platform()
        {

        }
        public void show(Graphics g)
        {
            SolidBrush br = new SolidBrush(Color.Gray);
            g.FillRectangle(br, x, y, dx, dy);
        }

        public void hide(Graphics g)
        {
            SolidBrush br = new SolidBrush(Color.White);
            g.FillRectangle(br, x, y, dx, dy);
        }

        public void move(Graphics g, int d)
        {
            hide(g);
            x -= d;
            if (x < 0)
            {
                x = 0;
            }
            if (x > 800)
            {
                x = 800;
            }
            show(g);
        }
    }
}
