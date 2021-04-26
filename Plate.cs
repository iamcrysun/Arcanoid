using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Arcanoid
{
   public  class Plate
    {
        public int x, y, dx, dy, color, bonus;
        public Plate()
        {
        }
        public Plate(int x, int y, int dx, int dy, int color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.dx = dx;
            this.dy = dy;
            bonus = 100;
        }
        public virtual void show(Graphics g)
        {
            SolidBrush blackPen = new SolidBrush(Color.Red);
            System.Drawing.Color colors = Color.Red;
            switch (color)
            {
                case 0:
                    colors = Color.Red;
                    break;
                case 1:
                    colors = Color.Blue;
                    break;
                case 2:
                    colors = Color.Orange;
                    break;
                case 3:
                    colors = Color.Yellow;
                    break;
                case 4:
                    colors = Color.Green;
                    break;
                case 5:
                    colors = Color.Gold;
                    break;
                case 6:
                    colors = Color.Pink;
                    break;
                case 7:
                    colors = Color.Brown;
                    break;
                case 8:
                    colors = Color.Purple;
                    break;
                case 9:
                    colors = Color.GreenYellow;
                    break;
                case 10:
                    colors = Color.Peru;
                    break;
            }
            blackPen.Color = colors;
            g.FillRectangle(blackPen, x, y, dx, dy);
            Pen whitePen = new Pen(Color.Black, 5);
            g.DrawRectangle(whitePen, x, y, dx, dy);
        }

        public virtual void hide(Graphics g)
        {
            SolidBrush blackPen = new SolidBrush(Color.White);
            g.FillRectangle(blackPen, x, y, dx, dy);
        }
    }
}
