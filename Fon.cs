using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Arcanoid
{
	public delegate void OnTimer_event(Graphics g);
	public delegate void OnMove_event(Graphics g, int code);
	public delegate void CheckPlat_event(Graphics g);
	public delegate void CheckBlock_event(Graphics g);
	public delegate void Over_event(string str);
	public delegate void Score_event(int score);
	public class Fon
    {
		public int x, y, dx, dy, color, bl_count;
		public Plate[,] brick_wall = new Plate[3,10];
		public Circle c2;
		public Platform pl;
		public event Over_event Over;
		public event Score_event Score;
		public Fon(int x, int inity, int initdx, int initdy, int initcolor, Graphics g, Form1 form1)
		{
			Random rnd = new Random(); //генератор рандомных чисел
			this.x = x;
			y = inity;
			dx = initdx;
			dy = initdy;
			color = initcolor;
			for (int i = 0; i < 3; i++) //формирование массива кирпичиков
				for (int j = 0; j < 10; j++)
				{
					if (rnd.Next(0, 10) % 10 > 0)
						brick_wall[i,j] = new Plate(90 * j, i * 50, 90, 50, rnd.Next(0, 10));
					else
						brick_wall[i,j] = new SuperPlate(90 * j, i * 50, 90, 50, rnd.Next(0, 10), (rnd.Next() % 6 + 1) * 50);

					
				}
			c2 = new Circle(430, 410, 128, 1, 1, 20, 1); //создание шарика
			pl = new Platform(400, 450, 100, 20, 192, 0); //создание платформы для отскока
			bl_count = 30;
			form1.OnTimer += Circle_OnTimer; 
			form1.OnMove += Platform_OnMove;
			c2.Block += Block;
			c2.Plat += Plat;
		}
		Fon() { }
		public void  show(Graphics g) //отрисовка состояния игрового поля
		{
			g.Clear(Color.White);
			SolidBrush br = new SolidBrush(Color.White);
			g.FillRectangle(br, 0, 0, dx, dy);
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 10; j++)
					if (brick_wall[i, j] != null)
					brick_wall[i, j].show(g);
			c2.show(g);
			pl.show(g);



		}

		private void Circle_OnTimer(Graphics g) //движение шарика по таймеру
		{
			c2.Move(g);
		}

		private void Platform_OnMove(Graphics g, int code) //движение платформы
		{
			if (code == 65 || code == 37)
            {
				pl.move(g, 10);
			}
			if (code == 68 || code == 39)
			{
				pl.move(g, -10);
			}
		}

		private void Block(Graphics g) //проверка на столкновение с блоком, удаление при столкновении
		{
			Random rnd = new Random();
			Plate br;
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 10; j++)
				{
					br = brick_wall[i, j];
					if (br != null && c2.x + 2 * c2.r >= br.x && c2.x <= br.x + br.dx && c2.y + 2 * c2.r >= br.y && c2.y <= br.y + br.dy)
					{
						c2.dy = -(rnd.Next() % 2 + 1); 
						c2.dx = -(rnd.Next() % 5 + 1);
						if (rnd.Next() % 2 == 0)
						{
							c2.dx *= -1;
						}
						Score?.Invoke(br.bonus);
						brick_wall[i, j] = null;
						bl_count--;
						if (bl_count == 0)
						{
							Over?.Invoke("Победа");
						}
						show(g);
					}
				}
		}

		private void Plat(Graphics g) //отскок шарика от платформы
		{
			Random rnd = new Random();
			if (c2.x + 2 * c2.r >= pl.x && c2.x <= pl.x + pl.dx && c2.y + 2 * c2.r >= pl.y && c2.y <= pl.y + pl.dy)
			{
				c2.dy = (rnd.Next() % 3 + 1);
				c2.dx = -(rnd.Next() % 5 + 1);
				if (rnd.Next() % 2 == 0)
				{
					c2.dx *= -1;
				}
				pl.show(g);
			}
			if (c2.y + c2.r >= pl.y + pl.dy) //проверка на поражение при координатах шарика ниже платформы
			{
				Over?.Invoke("Поражение");
			}
		}
	}
}
