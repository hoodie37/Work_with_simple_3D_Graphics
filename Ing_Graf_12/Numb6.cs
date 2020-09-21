using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Ing_Graf_12
{
    public partial class Numb6 : Form
    {
        public Numb6()
        {
            InitializeComponent();
        }

        private void Zadanie_6_Load(object sender, EventArgs e)
        {
          

            G = MyPictureBox.CreateGraphics();

            HScrollBarPitch.Minimum = 1;
            HScrollBarPitch.Maximum = MyPictureBox.Width;

            HScrollBarYaw.Minimum = 1;
            HScrollBarYaw.Maximum = MyPictureBox.Width;

            HScrollBarRoll.Minimum = 1;
            HScrollBarRoll.Maximum = MyPictureBox.Width; 

            HScrollBarTheta.Minimum = 1;
            HScrollBarTheta.Maximum = 369;

            x[0] = 200;
            y[0] = 100;

            x[1] = 300;
            y[1] = 300;

            x[2] = 400;
            y[2] = 100;

            u = Factor * HScrollBarPitch.Value;
            v = Factor * HScrollBarYaw.Value;
            w = Factor * HScrollBarRoll.Value;
            Theta= Factor * HScrollBarTheta.Value;


        }

       
            private Graphics G;
        double u;
        double v;
        double w;

        double Theta;
        static int Vertex_Number = 3;
        double[] x = new double[Vertex_Number + 1], y = new double[Vertex_Number + 1], z = new double[Vertex_Number + 1], newX = new double[Vertex_Number + 1], newY = new double[Vertex_Number + 1], newZ = new double[Vertex_Number + 1];
        PointF[] point = new PointF[Vertex_Number + 1];
        double Factor = Math.PI / 180;



        public double RotateObject(double Theta, double u, double v, double w, double x, double y, double z, ref double NewX, ref double NewY)
        {
            double NewZ;
            double a, b, c, d, e;
            a = u * x + v * y + w * z;
            b = Math.Pow(u, 2) + Math.Pow(v, 2) + Math.Pow(w, 2);
            c = Math.Sqrt(b);
            d = Math.Cos(Theta);
            e = Math.Sin(Theta);
            NewX = (u * a + (x * (Math.Pow(v, 2) + Math.Pow(w, 2) - u * (v * y + w * z)) * d + c * (-w * y + v * z) * e)) / b;
            NewY = (v * a + (y * (Math.Pow(u, 2) + Math.Pow(w, 2) - v * (u * x + w * z)) * d + c * (w * x - u * z) * e)) / b;
            NewZ = (w * a + (z * (Math.Pow(u, 2) + Math.Pow(v, 2) - w * (u * x + v * y)) * d + c * (-v * x + u * y) * e)) / b;
            return NewZ;
        }

   



        public void DrawShape(Graphics GraphicObject)
        {

          

            newZ[0] = RotateObject(Theta, u, v, w, x[0], y[0], z[0], ref newX[0], ref newY[0]);
            newZ[1] = RotateObject(Theta, u, v, w, x[1], y[1], z[1], ref newX[1], ref newY[1]);
            newZ[2] = RotateObject(Theta, u, v, w, x[2], y[2], z[2], ref newX[2], ref newY[2]);

            point[0] = new PointF((float)newX[0], (float)newY[0]);
            point[1] = new PointF((float)newX[1], (float)newY[1]);
            point[2] = new PointF((float)newX[2], (float)newY[2]);



            PointF[] curvePoints = new[] { point[0], point[1], point[2] };
            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            GraphicObject.Clear(Color.White);
            GraphicObject.DrawPolygon(MyPen, curvePoints);
            GraphicObject.FillPolygon(myBrush, curvePoints);
            PointF MyPoint1 = new PointF(0, 0);
            PointF MyPoint2 = new PointF((float)u,(float)v);
            GraphicObject.DrawLine(MyPen, MyPoint1, MyPoint2);
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
        private void HScrollBarTheta_Scroll(object sender, ScrollEventArgs e)
        {
            Theta = HScrollBarTheta.Value;

            Theta = Factor * HScrollBarTheta.Value;


            DrawShape(G);

        }
    }

   
}
