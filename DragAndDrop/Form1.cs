using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DragAndDrop
{
    public partial class Form1 : Form
    {
        //Фигуры
        Rectangle rect = new Rectangle(1000,1000,200,100);
        Rectangle circ = new Rectangle(10, 200, 150, 150);
        Rectangle sq = new Rectangle(1000, 1000, 150, 150);
        Label forma, info;
        //Поля для фигур
        Rectangle circ2 = new Rectangle(220, 10, 140, 140);
        Rectangle rect2 = new Rectangle(10, 10, 190, 90);
        Rectangle sq2 = new Rectangle(380, 10, 140, 140);
        PictureBox pic;
        bool rectclick;
        bool sqclick ;
        bool circclick ;
        int xrect= 0;
        int yrect = 0;
        int xcirc = 0;
        int ycirc = 0;
        int xsq = 0;
        int ysq = 0;
        int x, y, dx, dy;
        int lastclick = 0;
        public Form1()
        {
            this.Height = 700;
            this.Width = 1000;

            info = new Label();
            forma = new Label { BorderStyle = BorderStyle.FixedSingle };
            pic = new PictureBox { Size = new Size(650,600), BorderStyle= BorderStyle.FixedSingle, Location = new Point(50,10)};
            pic.Paint += Pic_Paint;
            pic.MouseDown += Pic_MouseDown;
            pic.MouseUp += Pic_MouseUp;
            pic.MouseMove += Pic_MouseMove;
            forma.Location = new Point(300,500);
            info.Location = new Point(500,500);
            info.Size = new Size(100, 100);
            forma.Size = new Size(100, 100);
            info.Text = " ";
            forma.Text = "форма";
            this.Controls.Add(forma);
            this.Controls.Add(info);
            this.Controls.Add(pic);

        }

        private void Pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (circclick)
            {
                circ.X = e.X - xcirc;
                circ.Y = e.Y - ycirc;
            }
            if (rectclick)
            {
                rect.X = e.X - xrect;
                rect.Y = e.Y - yrect;
            }
            if (sqclick)
            {
                sq.X = e.X - xsq;
                sq.Y = e.Y - ysq;
            }
            if ((sq2.Location.X<sq.X +sq.Width) && (sq2.Location.X > sq.X))
            {
                if((sq2.Location.Y<sq.Y+sq.Height) && (sq2.Location.Y > sq.Y))
                {
                    info.Text = "Правильно! Квадрат";
                    info.ForeColor = Color.Green;
                }
            }
            if ((circ2.Location.X < circ.X + circ.Width) && (circ2.Location.X > circ.X))
            {
                if ((circ2.Location.Y < circ.Y + circ.Height) && (circ2.Location.Y > circ.Y))
                {
                    info.Text = "Правильно! Круг";
                    info.ForeColor = Color.Green;
                }
            }
            if ((rect2.Location.X < rect.X + rect.Width) && (rect2.Location.X > rect.X))
            {
                if ((rect2.Location.Y < rect.Y + rect.Height) && (rect2.Location.Y > rect.Y))
                {
                    info.Text = "Правильно! Прямоугольник";
                    info.ForeColor = Color.Green;
                }
            } //Проверка для формы квадрата
            if ((sq2.Location.X < rect.X + rect.Width) && (sq2.Location.X > rect.X))
            {
                if ((sq2.Location.Y < rect.Y + rect.Height) && (sq2.Location.Y > rect.Y))
                {
                    info.Text = "Неправильно! ";
                    info.ForeColor = Color.Red;
                }
            }
            if ((sq2.Location.X < circ.X + circ.Width) && (sq2.Location.X > circ.X))
            {
                if ((sq2.Location.Y < circ.Y + circ.Height) && (sq2.Location.Y > circ.Y))
                {
                    info.Text = "Неправильно! ";
                    info.ForeColor = Color.Red;
                }
            }//Проверка для формы круга
            if ((circ2.Location.X < rect.X + rect.Width) && (circ2.Location.X > rect.X))
            {
                if ((circ2.Location.Y < rect.Y + rect.Height) && (circ2.Location.Y > rect.Y))
                {
                    info.Text = "Неправильно! ";
                    info.ForeColor = Color.Red;
                }
            }
            if ((circ2.Location.X < sq.X + sq.Width) && (circ2.Location.X > sq.X))
            {
                if ((circ2.Location.Y < sq.Y + sq.Height) && (circ2.Location.Y > sq.Y))
                {
                    info.Text = "Неправильно! ";
                    info.ForeColor = Color.Red;
                }
            }//Проверка для формы прямоугольника
            if ((rect2.Location.X < circ.X + circ.Width) && (rect2.Location.X > circ.X))
            {
                if ((rect2.Location.Y < circ.Y + circ.Height) && (rect2.Location.Y > circ.Y))
                {
                    info.Text = "Неправильно! ";
                    info.ForeColor = Color.Red;
                }
            }
            if ((rect2.Location.X < sq.X + sq.Width) && (rect2.Location.X > sq.X))
            {
                if ((rect2.Location.Y < sq.Y + sq.Height) && (rect2.Location.Y > sq.Y))
                {
                    info.Text = "Неправильно! ";
                    info.ForeColor = Color.Red;
                }
            }
            pic.Invalidate();
        }

        private void Pic_MouseUp(object sender, MouseEventArgs e)
        {
            rectclick = false;
            sqclick = false;
            circclick = false;
            if ((forma.Location.X < sq.X + sq.Width) && (forma.Location.X > sq.X))
            {
                if ((forma.Location.Y < sq.Y + sq.Height) && (forma.Location.Y > sq.Y))
                {
                    lastclick = 3;
                }
            }
            if ((forma.Location.X < circ.X + circ.Width) && (forma.Location.X > circ.X))
            {
                if ((forma.Location.Y < circ.Y + circ.Height) && (forma.Location.Y > circ.Y))
                {
                    lastclick = 2;
                }
            }
            if ((forma.Location.X < rect.X + rect.Width) && (forma.Location.X > rect.X))
            {
                if ((forma.Location.Y < rect.Y + rect.Height) && (forma.Location.Y > rect.Y))
                {
                    lastclick = 1;
                }
            }
            if (lastclick == 2)
            {
                if((forma.Location.X < circ.X + circ.Width) && (forma.Location.X > circ.X))
                {
                    if((forma.Location.Y <  circ.Y + circ.Height) && (forma.Location.Y > circ.Y))
                    {
                        x = circ.X;
                        y = circ.Y;
                        dx = xcirc;
                        dy = ycirc;
                        circ.X = sq.X;
                        circ.Y = sq.Y;
                        xcirc = xsq;
                        ycirc = ysq;
                        sq.X = x;
                        sq.Y = y;
                        xsq = dx;
                        ysq = dy;
                        
                    }
                }
            }
            if (lastclick == 3)
            {
                if ((forma.Location.X < sq.X + sq.Width) && (forma.Location.X > sq.X))
                {
                    if ((forma.Location.Y < sq.Y + sq.Height) && (forma.Location.Y > sq.Y))
                    {
                        x = sq.X;
                        y = sq.Y;
                        dx = xsq;
                        dy = ysq;
                        sq.X = rect.X;
                        sq.Y = rect.Y;
                        xsq = xrect;
                        ysq = yrect;
                        rect.X = x;
                        rect.Y = y;
                        xrect = dx;
                        yrect = dy;
                    }
                }
            }
            if (lastclick == 1)
            {
                if ((forma.Location.X < rect.X + rect.Width) && (forma.Location.X > rect.X))
                {
                    if ((forma.Location.Y < rect.Y + rect.Height) && (forma.Location.Y > rect.Y))
                    {
                        x = rect.X;
                        y = rect.Y;
                        dx = xrect;
                        dy = yrect;
                        rect.X = circ.X;
                        rect.Y = circ.Y;
                        xrect = xcirc;
                        yrect = ycirc;
                        circ.X = x;
                        circ.Y = y;
                        xcirc = dx;
                        ycirc = dy;
                        
                    }
                }
            }
        }

        private void Pic_MouseDown(object sender, MouseEventArgs e)
        {
            if((e.X < rect.X + rect.Width) && (e.X > rect.X))
            {
                if((e.Y<rect.Y+rect.Height) && (e.Y > rect.Y))
                {
                    rectclick = true;
                    xrect = e.X - rect.X;
                    yrect = e.Y - rect.Y;
                }
            }
            if ((e.X < circ.X + circ.Width) && (e.X > circ.X))
            {
                if ((e.Y < circ.Y + circ.Height) && (e.Y > circ.Y))
                {
                    circclick = true;
                    xcirc = e.X - circ.X;
                    ycirc = e.Y - circ.Y;
                }
            }
            if ((e.X < sq.X + sq.Width) && (e.X > sq.X))
            {
                if ((e.Y < sq.Y + sq.Height) && (e.Y > sq.Y))
                {
                    sqclick = true;
                    xsq = e.X - sq.X;
                    ysq = e.Y - sq.Y;
                }
            }
        }

        private void Pic_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, circ);
            e.Graphics.FillRectangle(Brushes.Blue, sq);
            e.Graphics.FillRectangle(Brushes.Yellow, rect);
            e.Graphics.FillEllipse(Brushes.LightGray, circ2);
            e.Graphics.FillRectangle(Brushes.LightGray, rect2);
            e.Graphics.FillRectangle(Brushes.LightGray, sq2);
            
        }
    }
}
