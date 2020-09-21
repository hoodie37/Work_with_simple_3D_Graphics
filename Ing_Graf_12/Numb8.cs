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
    public partial class Numb8 : Form
    {
        double Factor = Math.PI / 180;
        // double x, y, z;
        public int vertexnum = 3;
        double[] x = new double[3];
        double[] y = new double[3];
        double[] z = new double[3];
        double[] newX = new double[3];
        double[] newY = new double[3];
        double[] newZ = new double[3];
        PointF[] point = new PointF[3];
        double Theta;
        double u;
        double v;
        double w;

        double A;
        double B;
        double C;
        Graphics G;
        public Numb8()
        {
            InitializeComponent();
            Theta = Factor * HScrollBarTheta.Value;
            u = Factor * HScrollBarPitch.Value;
            v = Factor * HScrollBarYaw.Value;
            w = Factor * HScrollBarRoll.Value;

            A = Factor * HScrollBarA.Value;
            B = Factor * HScrollBarB.Value;
            C = Factor * HScrollBarC.Value;
        }

        public double RotateObject(double Theta, double A, double B, double C, double u, double v, double w, double x, double y, double z, ref double NewX
    , ref double NewY)
        {
            double NewZ;
            double L = Math.Pow(u, 2) + Math.Pow(v, 2) + Math.Pow(w, 2);
            double SqrL = Math.Sqrt(L);
            double Lu = Math.Pow(v, 2) + Math.Pow(w, 2);
            double Lv = Math.Pow(u, 2) + Math.Pow(w, 2);
            double Lw = Math.Pow(u, 2) + Math.Pow(v, 2);

            NewX = (A * Lu + u * (-B * v - C * w + u * x + v * y
                  + w * z) + ((x - A) * Lu + u * (B * v + C * w - v * y
                        - w * z) + Lu * x) * Math.Cos(Theta) + SqrL * (-C * v +
              B * w - w * y + v * z) * Math.Sin(Theta)) / L;
            NewY = (B * Lv + v * (-A * u - C * w + u * x + v * y +
                w * z) + ((y - B) * Lv + v * (A * u + C * w - u * x -
             w * z) + Lv * y) * Math.Cos(Theta) + SqrL * (-C * u - A * w +
                  w * x - u * z) * Math.Sin(Theta)) / L;
            NewZ = (C * Lw + w * (-A * u - B * v + u * x + v * y +
         w * z) + ((z - C) * Lw + w * (A * u + B * v - u * x - v * y)
               + Lw * z) * Math.Cos(Theta) + SqrL * (-B * u + A * v - v * x +
                 u * y) * Math.Sin(Theta)) / L;

            return NewZ;
        }

        public void DrawShape(Graphics GraphicObject)
        {
            newZ[0] = RotateObject(Theta, A, B, C, u, v, w, x[0],
        y[0], z[0], ref newX[0], ref newY[0]);
            newZ[1] = RotateObject(Theta, A, B, C, u, v, w, x[1],

               y[1], z[1], ref newX[1], ref newY[1]);
            newZ[2] = RotateObject(Theta, A, B, C, u, v, w, x[2],

              y[2], z[2], ref newX[2], ref newY[2]);

            point[0] = new PointF((float)newX[0], (float)newY[0]);
            point[1] = new PointF((float)newX[1], (float)newY[1]);
            point[2] = new PointF((float)newX[2], (float)newY[2]);

            PointF[] curvePoints = { point[0], point[1], point[2] };
            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            GraphicObject.Clear(Color.White);
            GraphicObject.DrawPolygon(MyPen, curvePoints);
            GraphicObject.FillPolygon(myBrush, curvePoints);

            PointF MyPoint1 = new PointF((float)(A), (float)(B));
            PointF MyPoint2 = new PointF((float)(u), (float)(v));
            Pen blackPen = new Pen(Color.Black, 2);
            GraphicObject.DrawLine(blackPen, MyPoint1, MyPoint2);

        }

        private void HScrollBarPitch_Scroll(object sender, ScrollEventArgs e)
        {
            u = HScrollBarPitch.Value;
            DrawShape(G);

        }

        private void HScrollBarYaw_Scroll(object sender, ScrollEventArgs e)
        {
            v = HScrollBarYaw.Value;
            DrawShape(G);

        }

        private void HScrollBarRoll_Scroll(object sender, ScrollEventArgs e)
        {
            w = HScrollBarRoll.Value;
            DrawShape(G);

        }

        private void HScrollBarA_Scroll(object sender, ScrollEventArgs e)
        {
            A = HScrollBarA.Value;
            DrawShape(G);

        }

        private void HScrollBarB_Scroll(object sender, ScrollEventArgs e)
        {
            B = HScrollBarB.Value;
            DrawShape(G);

        }

        private void HScrollBarC_Scroll(object sender, ScrollEventArgs e)
        {
            C = HScrollBarC.Value;
            DrawShape(G);

        }

        private void HScrollBarTheta_Scroll(object sender, ScrollEventArgs e)
        {
            Theta = HScrollBarTheta.Value;
            Theta = Factor * HScrollBarTheta.Value;
            DrawShape(G);

        }

        private void FormLab8_Load(object sender, EventArgs e)
        {
            G = pictureBox1.CreateGraphics();

            int Minimum, Maximum;
            Minimum = 1;
            Maximum = 369;

            HScrollBarTheta.Minimum = Minimum;
            HScrollBarTheta.Maximum = Maximum;

            HScrollBarPitch.Minimum = Minimum;
            HScrollBarPitch.Maximum = pictureBox1.Width;

            HScrollBarYaw.Minimum = Minimum;
            HScrollBarYaw.Maximum = pictureBox1.Width;

            HScrollBarRoll.Minimum = Minimum;
            HScrollBarRoll.Maximum = pictureBox1.Width;

            HScrollBarA.Minimum = Minimum;
            HScrollBarA.Maximum = pictureBox1.Width;

            HScrollBarB.Minimum = Minimum;
            HScrollBarB.Maximum = pictureBox1.Width;

            HScrollBarC.Minimum = Minimum;
            HScrollBarC.Maximum = pictureBox1.Width;

            // 'Задаем координаты вершин треугольника
            x[0] = 200;
            y[0] = 100;

            x[1] = 300;
            y[1] = 300;

            x[2] = 400;
            y[2] = 100;

        }
    }
}
