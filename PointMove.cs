using System;
using System.Collections.Generic;
using System.Text;

namespace Arcanoid
{
    public class PointMove : Point
    {
		public int dx, dy;
		public PointMove() { }
		public PointMove(int x, int y, int color, int dx, int dy) : base(x, y, color)
		{
			this.dx = dx;
			this.dy = dy;
		}
	}
}
