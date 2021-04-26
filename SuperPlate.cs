using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Arcanoid
{
    public class SuperPlate: /*(int x, int y, int dx, int dy, int color, int bonus):*/ Plate 

    {
        public SuperPlate (int x, int y, int dx, int dy, int color, int bonus)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.dx = dx;
            this.dy = dy;
            this.bonus = bonus;
            
        }

        public override void show(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Red);
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
            brush.Color = colors;
            Pen whitePen = new Pen(Color.Black, 5);
            SolidBrush brush_2 = new SolidBrush(Color.Black);
            g.FillRectangle(brush_2, x, y, dx, dy);
            g.FillEllipse(brush, x, y, dx, dy);
            g.DrawRectangle(whitePen, x, y, dx, dy);
        }
    }
}
