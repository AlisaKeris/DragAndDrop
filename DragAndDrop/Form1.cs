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
        Rectangle rect = new Rectangle(1000,1000,180,80);
        Rectangle circ = new Rectangle(10, 200, 130, 130);
        Rectangle sq = new Rectangle(1000, 1000, 130, 130);
        Rectangle ov = new Rectangle(1000, 1000, 180, 80);
        Label forma, info;
        //Поля для фигур
        Rectangle circ2 = new Rectangle(250, 30, 120, 120);
        Rectangle rect2 = new Rectangle(30, 50, 170, 70);
        Rectangle sq2 = new Rectangle(410, 30, 120, 120);
        Rectangle ov2 = new Rectangle(560, 40, 170, 100);
        PictureBox pic;
        
        bool rectclick;
        bool sqclick ;
        bool circclick ;
        bool ovclick;
        int xrect= 0;
        int yrect = 0;
        int xcirc = 0;
        int ycirc = 0;
        int xsq = 0;
        int ysq = 0;
        int xov = 0;
        int yov = 0;
        int x, y, dx, dy;
        int lastclick = 0;
        public Form1()
        {
            this.Height = 700;
            this.Width = 1100;
            
            info = new Label { TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            forma = new Label { BorderStyle = BorderStyle.FixedSingle, ForeColor=Color.DarkBlue ,TextAlign = System.Drawing.ContentAlignment.MiddleCenter,BackColor=Color.BlanchedAlmond};
            
            pic = new PictureBox { Size = new Size(800,550),  Location = new Point(50,30)};
            pic.Paint += Pic_Paint;
            pic.MouseDown += Pic_MouseDown;
            pic.MouseUp += Pic_MouseUp;
            pic.MouseMove += Pic_MouseMove;
            
            forma.Location = new Point(300,500);
            info.Location = new Point(800,200);
            info.Size = new Size(200, 150);
            forma.Size = new Size(100, 50);
            
            info.Text = " ";
            forma.Text = "П О М Е Н Я Й   Ф О Р М У";
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
            if (ovclick)
            {
                ov.X = e.X - xov;
                ov.Y = e.Y - yov;
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
                    info.Text = "Молодец! Круг";
                    info.ForeColor = Color.Green;
                }
            }
            if ((rect2.Location.X < rect.X + rect.Width) && (rect2.Location.X > rect.X))
            {
                if ((rect2.Location.Y < rect.Y + rect.Height) && (rect2.Location.Y > rect.Y))
                {
                    info.Text = "Умница! Прямоугольник";
                    info.ForeColor = Color.Green;
                }
            }
            if ((ov2.Location.X < ov.X + ov.Width) && (ov2.Location.X > ov.X))
            {
                if ((ov2.Location.Y < ov.Y + ov.Height) && (ov2.Location.Y > ov.Y))
                {
                    info.Text = "Умница! Овал";
                    info.ForeColor = Color.Green;
                }
            } //Проверка для формы квадрата
            if ((sq2.Location.X < rect.X + rect.Width) && (sq2.Location.X > rect.X))
            {
                if ((sq2.Location.Y < rect.Y + rect.Height) && (sq2.Location.Y > rect.Y))
                {
                    info.Text = "Это сюда не подходит!";
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
                    info.Text = "Нет! ";
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
            if ((rect2.Location.X < circ.X + circ.Width) && (rect2.Location.X > circ.X) )
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
                    info.Text = "Подумай еще! ";
                    info.ForeColor = Color.Red;
                }
            }
            pic.Invalidate();
        }

        private void Pic_MouseUp(object sender, MouseEventArgs e) //изменение формы
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
            if ((forma.Location.X < ov.X + ov.Width) && (forma.Location.X > ov.X))
            {
                if ((forma.Location.Y < ov.Y + ov.Height) && (forma.Location.Y > ov.Y))
                {
                    lastclick = 4;
                }
            }
            if (lastclick == 2) //круг меняется на квадрат
            {
                if ((forma.Location.X < circ.X + circ.Width) && (forma.Location.X > circ.X))
                {
                    if ((forma.Location.Y < circ.Y + circ.Height) && (forma.Location.Y > circ.Y))
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
            if (lastclick == 3) //квадрат меняется на прямоугольник
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
            if (lastclick == 1) //прямоугольник меняется на овал
            {
                if ((forma.Location.X < rect.X + rect.Width) && (forma.Location.X > rect.X))
                {
                    if ((forma.Location.Y < rect.Y + rect.Height) && (forma.Location.Y > rect.Y))
                    {
                        x = rect.X;
                        y = rect.Y;
                        dx = xrect;
                        dy = yrect;
                        rect.X = ov.X;
                        rect.Y = ov.Y;
                        xrect = xov;
                        yrect = yov;
                        ov.X = x;
                        ov.Y = y;
                        xov = dx;
                        yov = dy;
                        
                    }
                }
            }
            if (lastclick == 4) //овал меняется на круг
            {
                if ((forma.Location.X < ov.X + ov.Width) && (forma.Location.X > ov.X))
                {
                    if ((forma.Location.Y < ov.Y + ov.Height) && (forma.Location.Y > ov.Y))
                    {
                        x = ov.X;
                        y = ov.Y;
                        dx = xov;
                        dy = yov;
                        ov.X = circ.X;
                        ov.Y = circ.Y;
                        xov = xcirc;
                        yov = ycirc;
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
            e.Graphics.FillEllipse(Brushes.LightGray, ov2);
            e.Graphics.FillEllipse(Brushes.CornflowerBlue, ov);


        }
    }
}
