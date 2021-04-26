using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Arcanoid
{
	public class Circle
	{
		public event CheckPlat_event Plat;
		public event CheckBlock_event Block;
		public int x, y, color, dx, dy, r, v;
		public Circle() { }
		public Circle(int x, int y, int color, int dx, int dy, int r, int v)
		{
			this.x = x;
			this.y = y;
			this.color = color;
			this.dx = dx;
			this.dy = dy;
			this.r = r; ///////////
			this.v = v;
		}

		public void show(Graphics g)
		{
			SolidBrush br = new SolidBrush(Color.Black);
			g.FillEllipse(br, x, y, 2 * r, 2 * r);
		}

		public void hide(Graphics g)
		{
			SolidBrush br = new SolidBrush(Color.White);
			g.FillEllipse(br, x, y, 2 * r, 2 * r);
		}

		public void Move(Graphics g)
        {
			Random rnd = new Random();
			hide(g);
			x -= dx;
			y -= dy;
			if (y < 0)
            {
				y = 0;
				dy = -(rnd.Next() % 2 + 1);
				dx = -(rnd.Next() % 5 + 1);
				if (rnd.Next() % 2 == 0)
				{
					dx *= -1;
				}
			}
			if (x < 0)
			{
				x = 0;
				dy = -(rnd.Next() % 2 + 1);
				dx = -(rnd.Next() % 5 + 1);
				if (rnd.Next() % 2 == 0)
				{
					dy *= -1;
				}
			}
			if (x > 850)
			{
				x = 850;
				dy = -(rnd.Next() % 2 + 1);
				dx = +(rnd.Next() % 5 + 1);
				if (rnd.Next() % 2 == 0)
				{
					dy *= -1;
				}
			}
			Plat?.Invoke(g);
			Block?.Invoke(g);
			show(g);
		}
	}
}

