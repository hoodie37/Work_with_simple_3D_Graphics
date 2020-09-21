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
    public partial class Numb5 : Form
    {
        public Numb5()
        {
            InitializeComponent();
        }
        Graphics G;
        double Pitch, Yaw, Roll, Theta;
        double Factor = Math.PI / 180;
        static int Vertex_Number = 3;
    
        double[] x = new double[Vertex_Number + 1], y = new double[Vertex_Number + 1], z = new double[Vertex_Number + 1], newX = new double[Vertex_Number + 1], newY = new double[Vertex_Number + 1], newZ = new double[Vertex_Number + 1];
        


        double XOffset;
        double YOffset;
        double ZOffset;


        PointF[] point = new PointF[Vertex_Number];

        private void Zadanie_5_Load(object sender, EventArgs e)
        {
            G = MyPictureBox.CreateGraphics();

            HScrollBarPitch.Minimum = 1;
            HScrollBarPitch.Maximum = 369;

            HScrollBarYaw.Minimum = 1;
            HScrollBarYaw.Maximum = 369;

            HScrollBarRoll.Minimum = 1;
            HScrollBarRoll.Maximum = 369;

            HScrollBarTheta.Minimum = 1;
            HScrollBarTheta.Maximum = 369;

            x[0] = 200;
            y[0] = 100;

            x[1] = 300;
            y[1] = 300;

            x[2] = 400;
            y[2] = 100;


        }
        private void HScrollBarPitch_Scroll(System.Object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            Pitch = HScrollBarPitch.Value;
            DrawShape(G);
        }

        private void HScrollBarYaw_Scroll(System.Object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            Yaw = HScrollBarYaw.Value;
            DrawShape(G);
        }

        private void HScrollBarZOffset_Scroll_1(object sender, ScrollEventArgs e)
        {
            ZOffset = HScrollBarZOffset.Value;
            DrawShape(G);
        }

        private void HScrollBarYOffset_Scroll_1(object sender, ScrollEventArgs e)
        {
             YOffset = HScrollBarYOffset.Value;
            DrawShape(G);
        }

        private void HScrollBarXOffset_Scroll_1(object sender, ScrollEventArgs e)
        {
            XOffset = HScrollBarXOffset.Value;
            DrawShape(G);
        }

        private void HScrollBarRoll_Scroll(System.Object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            Roll = HScrollBarRoll.Value;
            DrawShape(G);
        }

        private void HScrollBarTheta_Scroll(System.Object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            Theta = HScrollBarTheta.Value;
            DrawShape(G);
        }

       



        public double RotateObject(double Theta, double Pitch, double Yaw, double Roll, double x, double y, double z, double x0, double y0, double z0, ref double NewX, ref double NewY)
        {
            double temp;
            temp = 1.0 - Math.Cos(Theta);
            double NewZ;

            NewX = x0 + (x - x0) * (Pitch * temp * Pitch + Math.Cos(Theta)) + (y - y0) * (Yaw * temp * Pitch - Math.Sin(Theta) * Roll) + (z - z0) * (Roll * temp * Pitch + Math.Sin(Theta) * Yaw);
            NewY = y0 + (x - x0) * (Pitch * temp * Yaw + Math.Sin(Theta) * Roll) + (y - y0) * (Yaw * temp * Yaw + Math.Cos(Theta)) + (z - z0) * (Roll * temp * Yaw - Math.Sin(Theta) * Pitch);
            NewZ = z0 + (x - x0) * (Pitch * temp * Roll - Math.Sin(Theta) * Yaw) + (y - y0) * (Yaw * temp * Roll + Math.Sin(Theta) * Pitch) + (z - z0) * (Roll * temp * Roll + Math.Cos(Theta));
            return NewZ;
        }


        public void DrawShape(Graphics GraphicObject)
        {
            newZ[0] = RotateObject(Theta, Pitch, Yaw, Roll, x[0], y[0], z[0], XOffset, YOffset, ZOffset, ref newX[0], ref newY[0]);
            newZ[1] = RotateObject(Theta, Pitch, Yaw, Roll, x[1], y[1], z[1], XOffset, YOffset, ZOffset, ref newX[1], ref newY[1]);
            newZ[2] = RotateObject(Theta, Pitch, Yaw, Roll, x[2], y[2], z[2], XOffset, YOffset, ZOffset, ref newX[2], ref newY[2]);

            point[0] = new PointF((float)newX[0], (float)newY[0]);
            point[1] = new PointF((float)newX[1], (float)newY[1]);
            point[2] = new PointF((float)newX[2], (float)newY[2]);

            Rectangle MyRectangle = new Rectangle((int)XOffset, (int)YOffset, 5, 5);
            Pen blackPen = new Pen(Color.Black, 2);

            PointF[] curvePoints = new[] { point[0], point[1], point[2] };
            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            GraphicObject.Clear(Color.White);
            GraphicObject.DrawEllipse(blackPen, MyRectangle);
            double L;
            L = 5 * this.Width;
            Point MyPoint1 = new Point(0, 0);
            Point MyPoint2 = new Point((int)(L * Math.Cos(Pitch)), (int)(L * Math.Cos(Yaw)));
            GraphicObject.DrawLine(MyPen, MyPoint1, MyPoint2);

            GraphicObject.DrawPolygon(MyPen, curvePoints);
            GraphicObject.FillPolygon(myBrush, curvePoints);
        }

        private void RotateAxisPointThetaForm_Load(System.Object sender, System.EventArgs e)
        {
            G = MyPictureBox.CreateGraphics();

            int Minimum, Maximum;
            Minimum = 1;
            Maximum = 369;

            HScrollBarTheta.Minimum = Minimum;
            HScrollBarTheta.Maximum = Maximum;

            HScrollBarPitch.Minimum = Minimum;
            HScrollBarPitch.Maximum = MyPictureBox.Width;

            HScrollBarYaw.Minimum = Minimum;
            HScrollBarYaw.Maximum = MyPictureBox.Width;

            HScrollBarRoll.Minimum = Minimum;
            HScrollBarRoll.Maximum = MyPictureBox.Width;

            HScrollBarXOffset.Minimum = Minimum;
            HScrollBarXOffset.Maximum = MyPictureBox.Width;

            HScrollBarYOffset.Minimum = Minimum;
            HScrollBarYOffset.Maximum = MyPictureBox.Width;

            HScrollBarZOffset.Minimum = Minimum;
            HScrollBarZOffset.Maximum = MyPictureBox.Width;

            // Задаем координаты вершин треугольника
            x[0] = 200;
            y[0] = 100;

            x[1] = 300;
            y[1] = 300;

            x[2] = 400;
            y[2] = 100;
        }



    }
}
