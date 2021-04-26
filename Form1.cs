using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Arcanoid
{
    public partial class Form1 : Form
    {
        public event OnTimer_event OnTimer;
        public event OnMove_event OnMove; //событие на нажатие клавиши
        Graphics g;
        Fon fon;
        bool end;
        public Form1()
        {
            InitializeComponent();
             g =CreateGraphics();
             fon = new Fon(0, 0, 900, 500, 0, g, this);
            fon.Over += Game_over;
            fon.Score += Score;
            end = false; //признак конца игрв
        }

        private void Form1_Paint(object sender, PaintEventArgs e) //отрисовка объекта
        {
            fon.show(g);
        }

        private void timer1_Tick(object sender, EventArgs e) //событие тика таймера
        {
            if (fon != null && !end)
            {
                OnTimer?.Invoke(g);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) //движение платформы
        {
            if (fon != null && !end)
            {
                OnMove?.Invoke(g, e.KeyValue); //65 - лево, 68 - право
            }
        }

        private void Game_over(string str) //конец игры
        {
            end = true;
            label2.Text = str;
        }

        private void Score(int score) //счетчик счета игры
        {
            label2.Text = (Int32.Parse(label2.Text) + score).ToString();
        }
    }
}
