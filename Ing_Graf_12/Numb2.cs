using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ing_Graf_12
{
    public partial class Numb2 : Form
    {
        double factor = Math.PI / 180;
        public int vertexnum = 3;
        double[] x = new double[3];
        double[] y = new double[3];
        double[] z = new double[3];
        double[] newX = new double[3];
        double[] newY = new double[3];
        double[] newZ = new double[3];
        PointF[] points = new PointF[3];
        double XAxisAngle, YAxisAngle, ZAxisAngle;
        Graphics G;
        int Scrollnumber = -1;
        int x0;
        int y0;
        int z0;



        public Numb2()
        {
            InitializeComponent();

            int x0 = hScrollBar1.Value;
            int y0 = hScrollBar2.Value;
            int z0 = hScrollBar3.Value;

        }

        private void DrawShape(Graphics g, int number)
        {
            if (number == 1)
            {
                newZ[0] = RotateX(x[0], y[0], z[0], XAxisAngle, ref newX[0], ref newY[0]);
                newZ[1] = RotateX(x[1], y[1], z[1], XAxisAngle, ref newX[1], ref newY[1]);
                newZ[2] = RotateX(x[2], y[2], z[2], XAxisAngle, ref newX[2], ref newY[2]);
            }
            else if (number == 2)
            {
                newZ[0] = RotateY(x[0], y[0], z[0], YAxisAngle, ref newX[0], ref newY[0]);
                newZ[1] = RotateY(x[1], y[1], z[1], YAxisAngle, ref newX[1], ref newY[1]);
                newZ[2] = RotateY(x[2], y[2], z[2], YAxisAngle, ref newX[2], ref newY[2]);
            }
            else if (number == 3)
            {
                newZ[0] = RotateZ(x[0], y[0], z[0], ZAxisAngle, ref newX[0], ref newY[0]);
                newZ[1] = RotateZ(x[1], y[1], z[1], ZAxisAngle, ref newX[1], ref newY[1]);
                newZ[2] = RotateZ(x[2], y[2], z[2], ZAxisAngle, ref newX[2], ref newY[2]);
            }
            x[0] = newX[0];
            y[0] = newY[0];
            z[0] = newZ[0];
            x[1] = newX[1];
            y[1] = newY[1];
            z[1] = newZ[1];
            x[2] = newX[2];
            y[2] = newY[2];
            z[2] = newZ[2];
            points[0] = new PointF((float)newX[0], (float)newY[0]);
            points[1] = new PointF((float)newX[1], (float)newY[1]);
            points[2] = new PointF((float)newX[2], (float)newY[2]);
            g.DrawPolygon(new Pen(Color.Red, 3), points);

            Rectangle MyBox = new Rectangle(x0, y0, 5, 5);
            g.DrawEllipse(new Pen(Color.Red, 5), MyBox);
            g.FillPolygon(new SolidBrush(Color.Blue), points);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //G = pictureBox1.CreateGraphics();

            hScrollBar1.Minimum = 1;
            hScrollBar1.Maximum = 369;

            hScrollBar2.Minimum = 1;
            hScrollBar2.Maximum = 369;

            hScrollBar3.Minimum = 1;
            hScrollBar3.Maximum = 369;

            hScrollBar4.Minimum = 1;
            hScrollBar4.Maximum = pictureBox1.Width;

            hScrollBar5.Minimum = 1;
            hScrollBar5.Maximum = pictureBox1.Height;

            hScrollBar6.Minimum = 1;
            hScrollBar6.Maximum = pictureBox1.Height;

            x[0] = 200;
            y[0] = 100;

            x[1] = 300;
            y[1] = 300;

            x[2] = 400;
            y[2] = 100;

        }

        private void pictureBoxLab2_Paint(object sender, PaintEventArgs e)
        {
            if (Scrollnumber > 0)
            {
                DrawShape(e.Graphics, Scrollnumber);
            }
            else if (Scrollnumber == -1)
            {
                x[0] = 200;
                y[0] = 100;

                x[1] = 300;
                y[1] = 300;

                x[2] = 400;
                y[2] = 100;
                points[0] = new PointF((float)x[0], (float)y[0]);
                points[1] = new PointF((float)x[1], (float)y[1]);
                points[2] = new PointF((float)x[2], (float)y[2]);
                e.Graphics.DrawPolygon(new Pen(Color.Yellow, 3), points);
                e.Graphics.FillPolygon(new SolidBrush(Color.Magenta), points);
                Rectangle MyBox = new Rectangle(x0, y0, 5, 5);
                e.Graphics.DrawEllipse(new Pen(Color.Black, 5), MyBox);
            }
        }
        private double RotateX(double x1, double y1, double z1, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ = 0;
            NewX = x1;
            NewY = y0 + (y1 - y0) * Math.Cos(alpha) - (z1 - z0) * Math.Sin(alpha);
            NewZ = z0 + (y1 - y0) * Math.Sin(alpha) + (z1 - z0) * Math.Cos(alpha);
            return NewZ;
        }
        private double RotateY(double x1, double y1, double z1, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ = 0;
            NewX = x0 + (x1 - x0) * Math.Cos(alpha) + (z1 - z0) * Math.Sin(alpha); ;
            NewY = y1;
            NewZ = z0 + (x0 - x1) * Math.Sin(alpha) + (z1 - z0) * Math.Cos(alpha);
            return NewZ;
        }

        private double RotateZ(double x1, double y1, double z1, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ;
            NewX = x0 + (x1 - x0) * Math.Cos(alpha) + (y0 - y1) *
            Math.Sin(alpha);
            NewY = y0 + (x1 - x0) * Math.Sin(alpha) + (y1 - y0) *
            Math.Cos(alpha);
            NewZ = z1;
            return NewZ;
        }

        private void HScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                Scrollnumber = 2;
                YAxisAngle = factor * (hScrollBar2.Value);
            }
            pictureBox1.Invalidate();

        }

        private void HScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                Scrollnumber = 4;
                x0 = hScrollBar4.Value;
            }
            pictureBox1.Invalidate();


        }

        private void HScrollBar5_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                Scrollnumber = 5;
                y0 = hScrollBar5.Value;
            }
            pictureBox1.Invalidate();
        }

        private void HScrollBar6_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                Scrollnumber = 6;
                z0 = hScrollBar6.Value;
            }
            pictureBox1.Invalidate();
        }

        

        private void HScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                Scrollnumber = 3;
                ZAxisAngle = factor * (hScrollBar3.Value);
            }
            pictureBox1.Invalidate();

        }
        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                Scrollnumber = 1;
                XAxisAngle = factor * (hScrollBar1.Value);
            }
            pictureBox1.Invalidate();

        }
    }
}
