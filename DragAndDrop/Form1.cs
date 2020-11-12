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
        Rectangle rect = new Rectangle(10,10,200,100);
        Rectangle circ = new Rectangle(220, 10, 150, 150);
        Rectangle sq = new Rectangle(380, 10, 150, 150);
        Label vid, forma, info;
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
            this.Width = 850;
            
            vid = new Label { BorderStyle = BorderStyle.FixedSingle };
            forma = new Label { BorderStyle = BorderStyle.FixedSingle };
            info = new Label { BorderStyle = BorderStyle.FixedSingle };
            pic = new PictureBox { Size = new Size(580,480), BorderStyle= BorderStyle.FixedSingle, Location = new Point(50,10)};
            pic.Paint += Pic_Paint;
            pic.MouseDown += Pic_MouseDown;
            pic.MouseUp += Pic_MouseUp;
            pic.MouseMove += Pic_MouseMove;
            vid.Location = new Point(100,380);
            forma.Location = new Point(300,380);
            info.Location = new Point(500,380);
            info.Size = new Size(100, 100);
            forma.Size = new Size(100, 100);
            vid.Size = new Size(100, 100);
            vid.Text = "вид";
            info.Text = "информация";
            forma.Text = "форма";
            this.Controls.Add(vid);
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
            if ((vid.Location.X<sq.X +sq.Width) && (vid.Location.X > sq.X))
            {
                if((vid.Location.Y<sq.Y+sq.Height) && (vid.Location.Y > sq.Y))
                {
                    info.Text = "Синий квадрат";
                }
            }
            if ((vid.Location.X < circ.X + circ.Width) && (vid.Location.X > circ.X))
            {
                if ((vid.Location.Y < circ.Y + circ.Height) && (vid.Location.Y > circ.Y))
                {
                    info.Text = "Красный круг";
                }
            }
            if ((vid.Location.X < rect.X + rect.Width) && (vid.Location.X > rect.X))
            {
                if ((vid.Location.Y < rect.Y + rect.Height) && (vid.Location.Y > rect.Y))
                {
                    info.Text = "Желтый прямоугольник";
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
                        rect.X = sq.X;
                        rect.Y = sq.Y;
                        xrect = xsq;
                        yrect = ysq;
                        sq.X = x;
                        sq.Y = y;
                        xsq = dx;
                        ysq = dy;
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
        }
    }
}
