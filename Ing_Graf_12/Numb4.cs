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
    public partial class Numb4 : Form
    {
        public Numb4()
        {
            InitializeComponent();
        }
        Graphics G;
        double Pitch, Yaw, Roll,Theta;
        double Factor = Math.PI / 180;
        static int Vertex_Number = 3;
     
     double[] x = new double[Vertex_Number + 1], y = new double[Vertex_Number + 1], z = new double[Vertex_Number + 1], newX = new double[Vertex_Number + 1], newY = new double[Vertex_Number + 1], newZ = new double[Vertex_Number + 1];

       
        PointF[] point= new PointF[Vertex_Number];

    private void Zadanie_4_Load(object sender, EventArgs e)
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
        double RotateObject(double Pitch,double Yaw,double Roll,double a,double x,double y,double z, ref double  newx, ref double newy)
        {
            double Temp;
            Temp = 1.0 - Math.Cos(a);
            double NewZ;
            newx = x * (Pitch * Temp * Pitch + Math.Cos(a)) + y * (Yaw * Temp * Pitch - Math.Sin(a) * Roll) + z * (Roll * Temp * Pitch + Math.Sin(a) * Yaw);

            newy = x * (Pitch * Temp * Yaw + Math.Sin(a) * Roll) +  y * (Yaw * Temp * Yaw + Math.Cos(a)) + z * (Roll * Temp * Yaw - Math.Sin(a) * Pitch);
            NewZ = x * (Pitch * Temp * Roll - Math.Sin(a) * Yaw) + y * (Yaw * Temp * Roll + Math.Sin(a) * Pitch) + z * (Roll *Temp * Roll + Math.Cos(a));

            return NewZ;
        }

        public void DrawShape(Graphics GraphicObject)
        {
            newZ[0] = RotateObject(Pitch, Yaw, Roll, Theta, x[0], y[0], z[0],ref newX[0], ref newY[0]);
            newZ[1] = RotateObject(Pitch, Yaw, Roll, Theta, x[1], y[1], z[1],ref newX[1], ref newY[1]);
            newZ[2] = RotateObject(Pitch, Yaw, Roll, Theta, x[2], y[2], z[2],ref newX[2],ref newY[2]);

            point[0] = new PointF((float)newX[0],(float) newY[0]);
            point[1] = new PointF((float)newX[1], (float)newY[1]);
            point[2] = new PointF((float)newX[2], (float)newY[2]);

            Point MyPoint1 = new Point(0, 0);
            double L = 5 * this.Width;
            int MyX, MyY;
            MyX =(int)( L * Math.Cos(Pitch));
            MyY =(int) (L * Math.Cos(Yaw));
            Point MyPoint2 = new Point(MyX, MyY);
            Pen blackPen = new Pen(Color.Black, 2);

            PointF[] curvePoints = new[] { point[0], point[1], point[2] };
            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            G.Clear(Color.White);
            GraphicObject.DrawPolygon(MyPen, curvePoints);
            GraphicObject.FillPolygon(myBrush, curvePoints);
            GraphicObject.DrawLine(blackPen, MyPoint1, MyPoint2);
        }

        private void HScrollBarPitch_Scroll(object sender, ScrollEventArgs e)
        {

            Pitch = HScrollBarPitch.Value;
            Pitch = Factor * HScrollBarPitch.Value;
            DrawShape(G);
        }

        private void HScrollBarYaw_Scroll(object sender, ScrollEventArgs e)
        {
            Yaw = HScrollBarYaw.Value;
            Yaw = Factor * HScrollBarYaw.Value;
            DrawShape(G);
        }

        private void HScrollBarRoll_Scroll(object sender, ScrollEventArgs e)
        {
            Roll = HScrollBarRoll.Value;

            Roll = Factor * HScrollBarRoll.Value;
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
