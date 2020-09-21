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
    public partial class Numb1 : Form
    {
        double factor = Math.PI / 180;
        double x, y, z;
        public int vertexnum = 3;
        double[] x0 = new double[3];
        double[] y0 = new double[3];
        double[] z0 = new double[3];
        double[] newX = new double[3];
        double[] newY = new double[3];
        double[] newZ = new double[3];
        PointF[] points = new PointF[3];
        int Scrollnumber = -1;
        int ranColorRed;
        int ranColorGreen;
        int ranColorBlue;
        Random random = new Random();
        public Numb1()
        {
            InitializeComponent();
        }
        private Color RandomColor()
        {
            Color color;
            ranColorRed = random.Next(0, 255);
            ranColorGreen = random.Next(0, 255);
            ranColorBlue = random.Next(0, 255);
            color = Color.FromArgb(ranColorRed, ranColorGreen, ranColorBlue);
            return color;
        }

        private Pen RandomPen()
        {
            Pen pen = new Pen(RandomColor(), 3);
            return pen;
        }

        private SolidBrush RandomSolidBrush()
        {
            SolidBrush solidbrush = new SolidBrush(RandomColor());
            return solidbrush;
        }

        private void DrawShape(Graphics g, int number)
        {
            if (number == 1)
            {
                newZ[0] = RotateX(x0[0], y0[0], z0[0], x, ref newX[0], ref newY[0]);
                newZ[1] = RotateX(x0[1], y0[1], z0[1], x, ref newX[1], ref newY[1]);
                newZ[2] = RotateX(x0[2], y0[2], z0[2], x, ref newX[2], ref newY[2]);
            }
            else if (number == 2)
            {
                newZ[0] = RotateY(x0[0], y0[0], z0[0], y, ref newX[0], ref newY[0]);
                newZ[1] = RotateY(x0[1], y0[1], z0[1], y, ref newX[1], ref newY[1]);
                newZ[2] = RotateY(x0[2], y0[2], z0[2], y, ref newX[2], ref newY[2]);
            }
            else if (number == 3)
            {
                newZ[0] = RotateZ(x0[0], y0[0], z0[0], z, ref newX[0], ref newY[0]);
                newZ[1] = RotateZ(x0[1], y0[1], z0[1], z, ref newX[1], ref newY[1]);
                newZ[2] = RotateZ(x0[2], y0[2], z0[2], z, ref newX[2], ref newY[2]);
            }
            x0[0] = newX[0];
            y0[0] = newY[0];
            z0[0] = newZ[0];
            x0[1] = newX[1];
            y0[1] = newY[1];
            z0[1] = newZ[1];
            x0[2] = newX[2];
            y0[2] = newY[2];
            z0[2] = newZ[2];
            points[0] = new PointF((float)newX[0], (float)newY[0]);
            points[1] = new PointF((float)newX[1], (float)newY[1]);
            points[2] = new PointF((float)newX[2], (float)newY[2]);
            g.DrawPolygon(new Pen(Color.Red, 3), points);
            g.FillPolygon(new SolidBrush(Color.Blue), points);
        }

        private double RotateX(double x1, double y1, double z1, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ = 0;
            NewX = x1;
            NewY = y1 * Math.Cos(alpha) - z1 * Math.Sin(alpha);
            NewZ = y1 * Math.Sin(alpha) + z1 * Math.Cos(alpha);
            return NewZ;
        }
        private double RotateY(double x1, double y1, double z1, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ = 0;
            NewX = x1 * Math.Cos(alpha) + z1 * Math.Sin(alpha); ;
            NewY = y1;
            NewZ = -x1 * Math.Sin(alpha) + z1 * Math.Cos(alpha);
            return NewZ;
        }
        private double RotateZ(double x1, double y1, double z1, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ = 0;
            NewX = x1 * Math.Cos(alpha) - y1 * Math.Sin(alpha);
            NewY = x1 * Math.Sin(alpha) + y1 * Math.Cos(alpha);
            NewZ = z1;
            return NewZ;
        }
        private void HScrollBarX_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                Scrollnumber = 1;
                x = factor * (e.NewValue - e.OldValue);
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            {
                if (Scrollnumber > 0)
                {
                    DrawShape(e.Graphics, Scrollnumber);
                }
                else if (Scrollnumber == -1)
                {
                    x0[0] = 400;
                    y0[0] = 250;
                    z0[0] = 0;

                    x0[1] = 500;
                    y0[1] = 400;
                    z0[1] = 0;

                    x0[2] = 600;
                    y0[2] = 250;
                    z0[2] = 0;
                    points[0] = new PointF((float)x0[0], (float)y0[0]);
                    points[1] = new PointF((float)x0[1], (float)y0[1]);
                    points[2] = new PointF((float)x0[2], (float)y0[2]);
                    e.Graphics.DrawPolygon(new Pen(Color.Blue, 3), points);
                    e.Graphics.FillPolygon(new SolidBrush(Color.Green), points);
                }
            }
        }

        private void HScrollBarY_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                Scrollnumber = 2;
                y = factor * (e.NewValue - e.OldValue);
                pictureBox1.Invalidate();
            }
        }

        private void HScrollBarZ_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                Scrollnumber = 3;
                z = factor * (e.NewValue - e.OldValue);
                pictureBox1.Invalidate();
            }
        }

    }
}
