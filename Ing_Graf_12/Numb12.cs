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
    public partial class Numb12 : Form
    {
        public Numb12()
        {
            InitializeComponent();
        }

     
        Graphics G;
        double Pitch, Yaw, Roll;
        double Factor = Math.PI / 180;

        private void Zadanie_12_Load(object sender, EventArgs e)
        {
            {
                G = MyPictureBox.CreateGraphics();
                int Minimum, Maximum;
                Minimum = 0;
                Maximum = 369;
                HScrollBarPitch.Minimum = Minimum;
                HScrollBarPitch.Maximum = Maximum;
                HScrollBarYaw.Minimum = Minimum;
                HScrollBarYaw.Maximum = Maximum;
                HScrollBarRoll.Minimum = Minimum;
                HScrollBarRoll.Maximum = Maximum;
            }

        }

        private void HScrollBarPitch_Scroll(object sender, ScrollEventArgs e)
        {

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

        private void Button1_Click(object sender, EventArgs e)
        {
            HScrollBarPitch.Value = (int)numericUpDown1.Value;
            HScrollBarYaw.Value = (int)numericUpDown2.Value;
            HScrollBarRoll.Value = (int)numericUpDown3.Value;
            Pitch = HScrollBarPitch.Value;
            Pitch = Factor * HScrollBarPitch.Value;

            Yaw = HScrollBarYaw.Value;
            Yaw = Factor * HScrollBarYaw.Value;

            Roll = HScrollBarRoll.Value;
            Roll = Factor * HScrollBarRoll.Value;


            DrawShape(G);


        }

        private void MyPictureBox_Click(object sender, EventArgs e)
        {

        }

      

        public double RotateObject(double Pitch, double Yaw, double Roll, double x, double y, double z, ref double NewX, ref double NewY)
        {


            double[,] m = new double[4, 4];
            m[1, 1] = Math.Cos(Yaw) * Math.Cos(Roll);
            m[1, 2] = -Math.Cos(Yaw) * Math.Sin(Roll);
            m[1, 3] = -Math.Sin(Yaw);
            m[2, 1] = Math.Sin(Pitch) * Math.Sin(Yaw) * Math.Cos(Roll) + Math.Sin(Roll)
            * Math.Cos(Pitch);
            m[2, 2] = -Math.Sin(Pitch) * Math.Sin(Yaw) * Math.Sin(Roll) + Math.Cos(Roll)
            * Math.Cos(Pitch);
            m[2, 3] = Math.Cos(Yaw);
            m[3, 1] = -Math.Cos(Pitch) * Math.Sin(Yaw) * Math.Cos(Roll) + Math.Sin(Pitch)
            * Math.Sin(Roll);
            m[3, 2] = Math.Cos(Pitch) * Math.Sin(Yaw) * Math.Sin(Roll) + Math.Sin(Pitch)
            * Math.Cos(Roll);
            m[3, 3] = Math.Cos(Yaw) * Math.Cos(Pitch);
            double NewZ;
            NewX = m[1, 1] * x + m[2, 1] * y + m[3, 1] * z;
            NewY = m[1, 2] * x + m[2, 2] * y + m[3, 2] * z;
            NewZ = m[1, 3] * x + m[2, 3] * y + m[3, 3] * z;
            return NewZ;
        }

        public void DrawShape(Graphics GraphicObject)
        {
            //{
            //    int x0, y0, z0, h, R, m;
            //    x0 = 5;
            //    y0 = 5;
            //    z0 = 5;
            //    h = 100;
            //    R = 60;
            //    m = 1;

            //    GraphicObject.Clear(Color.White);

            //    int i, j;
            //    int ZMin, ZMax;
            //    ZMin = z0;
            //    ZMax = z0 + h;

            //    int XMin, XMax;
            //    double SmallR;


            //    SmallR = ((R / (double)h) * (h + z0));
            //    XMin = (int)(x0 - SmallR);
            //    XMax = (int)(x0 + SmallR);

            //    for (j = (int)XMin; j <=(int) XMax; j += m)
            //    {
            //        int YMin, YMax, x, z;
            //        x = j;
            //        z = z0;
            //        YMin = (int)(y0 - Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((x - x0), 2)));
            //        YMax = (int)(y0 + Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((x - x0), 2)));
            //        double NewX1 = 0, NewY1 = 0, NewZ1 = 0, Newx2 = 0, NewY2 = 0, NewZ2 = 0;
            //        NewZ1 = RotateObject(Pitch, Yaw, Roll, x, YMin, z, ref NewX1, ref NewY1);
            //        NewZ2 = RotateObject(Pitch, Yaw, Roll, x, YMax, z, ref Newx2, ref NewY2);

            //        Pen MyPen1 = new Pen(Color.Yellow, 1);
            //        Pen MyPen2 = new Pen(Color.Blue, 1);
            //        Rectangle MyBox1 = new Rectangle(System.Convert.ToInt32(NewX1), System.Convert.ToInt32(NewY1), 1, 1);
            //        Rectangle MyBox2 = new Rectangle(System.Convert.ToInt32(Newx2), System.Convert.ToInt32(NewY2), 1, 1);
            //        GraphicObject.DrawLine(MyPen1, (int)NewX1, (int)NewY1, (int)Newx2, (int)NewY2);
            //    }

            //    for (i = ZMin; i <= ZMax; i += m)
            //    {
            //        SmallR = (R / (double)h) * (h + z0 - i);
            //        XMin = (int)(x0 - SmallR);
            //        XMax = (int)(x0 + SmallR);
            //        for (j = (int)XMin; j <= XMax; j += m)
            //        {
            //            int YMin, YMax, x, z;
            //            x = j;
            //            z = z0;
            //            YMin =(int)( y0 - Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((x - x0), 2)));
            //            YMax =(int)( y0 + Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((x - x0), 2)));
            //            double NewX1 = 0, NewY1 = 0, NewZ1 = 0, Newx2 = 0, NewY2 = 0, NewZ2 = 0;
            //            NewZ1 = RotateObject(Pitch, Yaw, Roll, x, YMin, z, ref NewX1, ref NewY1);
            //            NewZ2 = RotateObject(Pitch, Yaw, Roll, x, YMax, z, ref Newx2, ref NewY2);

            //            Pen MyPen1 = new Pen(Color.Red, 1);
            //            Pen MyPen2 = new Pen(Color.Blue, 1);
            //            Rectangle MyBox1 = new Rectangle((int)NewX1, (int)NewY2, 1, 1);
            //            Rectangle MyBox2 = new Rectangle((int)Newx2, (int)NewY2, 1, 1);
            //            GraphicObject.DrawEllipse(MyPen1, MyBox1);
            //            GraphicObject.DrawEllipse(MyPen2, MyBox2);
            //        }
            //    }

            //    Matrix myMatrix = new Matrix();
            //    myMatrix.Translate((float)(MyPictureBox.Width / (double)2), (float)(MyPictureBox.Height / (double)2), MatrixOrder.Append);
            //    G.Transform = myMatrix;
            //}


            //ЦИЛИНДР ЦИЛИНДР ЦИЛИНДР ЦИЛИНДР ЦИЛИНДР ЦИЛИНДР ЦИЛИНДР ЦИЛИНДР
            //{
            //    int x0, y0, z0, R, L, m;
            //    x0 = 5;
            //    y0 = 5;
            //    z0 = 5;
            //    R = 50;
            //    L = 100;
            //    m = 1;

            //    GraphicObject.Clear(Color.White);

            //    int i, j;

            //    for (i = x0 - R; i <= x0 + R; i += m)
            //    {
            //        double y1, y2;
            //        y1 = y0 - Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - x0), 2));
            //        y2 = y0 + Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - x0), 2));
            //        double x11 = 0, y11 = 0, z11 = 0;
            //        double x21 = 0, y21 = 0, z21 = 0;
            //        z11 = RotateObject(Pitch, Yaw, Roll, i, y1, z0, ref x11, ref y11);
            //        z21 = RotateObject(Pitch, Yaw, Roll, i, y2, z0, ref x21, ref y21);
            //        Rectangle MyBox1 = new Rectangle((int)x11, (int)y11, m, m);
            //        Rectangle MyBox2 = new Rectangle((int)x21, (int)y21, m, m);
            //        Pen MyPen1 = new Pen(Color.Green, 1);
            //        Pen MyPen2 = new Pen(Color.Orchid, 1);
            //        GraphicObject.DrawLine(MyPen1, (float)x11, (float)y11, (float)x21, (float)y21);
            //        GraphicObject.DrawEllipse(MyPen1, MyBox1);
            //        GraphicObject.DrawEllipse(MyPen2, MyBox2);

            //    }

            //    for (i = z0 - m; i <= z0 + L - m; i += m)
            //    {
            //        for (j = x0 - R; j <= x0 + R; j += m)
            //        {
            //            double y1, y2;
            //            y1 = y0 - Math.Sqrt(Math.Pow(R, 2) - Math.Pow((j - x0), 2));
            //            y2 = y0 + Math.Sqrt(Math.Pow(R, 2) - Math.Pow((j - x0), 2));
            //            double x11 = 0, y11 = 0, z11 = 0;
            //            double x21 = 0, y21 = 0, z21 = 0;
            //            z11 = RotateObject(Pitch, Yaw, Roll, j, y1, i, ref x11, ref y11);
            //            z21 = RotateObject(Pitch, Yaw, Roll, j, y2, i, ref x21, ref y21);
            //            Rectangle MyBox1 = new Rectangle((int)x11, (int)y11, m, m);
            //            Rectangle MyBox2 = new Rectangle((int)x21, (int)y21, m, m);
            //            Pen MyPen1 = new Pen(Color.Blue, 1);
            //            Pen MyPen2 = new Pen(Color.Red, 1);
            //            GraphicObject.DrawEllipse(MyPen1, MyBox1);
            //            GraphicObject.DrawEllipse(MyPen2, MyBox2);
            //        }
            //    }

            //    for (i = x0 - R; i <= x0 + R; i += m)
            //    {
            //        double y1, y2;
            //        y1 = y0 - Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - x0), 2));
            //        y2 = y0 + Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - x0), 2));
            //        double x11 = 0, y11 = 0, z11 = 0;
            //        double x21 = 0, y21 = 0, z21 = 0;
            //        z11 = RotateObject(Pitch, Yaw, Roll, i, y1, z0 + L, ref x11, ref y11);
            //        z21 = RotateObject(Pitch, Yaw, Roll, i, y2, z0 + L, ref x21, ref y21);
            //        Rectangle MyBox1 = new Rectangle((int)x11, (int)y11, m, m);
            //        Rectangle MyBox2 = new Rectangle((int)x21, (int)y21, m, m);
            //        Pen MyPen1 = new Pen(Color.Green, 1);
            //        Pen MyPen2 = new Pen(Color.Orchid, 1);
            //        GraphicObject.DrawLine(MyPen2, (float)x11, (float)y11, (float)x21, (float)y21);
            //        GraphicObject.DrawEllipse(MyPen1, MyBox1);
            //        GraphicObject.DrawEllipse(MyPen2, MyBox2);
            //    }

            //    Matrix myMatrix = new Matrix();
            //    myMatrix.Translate((float)(MyPictureBox.Width / (double)2), (float)(MyPictureBox.Height / (double)2), MatrixOrder.Append);
            //    G.Transform = myMatrix;
            //}


            //ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА

            //{
            //    int x0, y0, z0, h, d, m;
            //    x0 = 0;
            //    y0 = 0;
            //    z0 = 0;
            //    h = 150;
            //    d = 70;
            //    m = 1;

            //    GraphicObject.Clear(Color.White);

            //    double i, j, k;
            //    Pen MyPen1 = new Pen(Color.Blue, 1);
            //    Pen MyPen2 = new Pen(Color.Red, 1);
            //    Pen MyPen3 = new Pen(Color.Green, 1);
            //    Pen MyPen4 = new Pen(Color.Black, 1);

            //    double XMin, Xmax;


            //    for (i = z0; i <= z0 + h; i += m)
            //    {
            //        XMin = -(z0 + i) * d / (2 * h);
            //        Xmax = (z0 + i) * d / (2 * h);
            //        for (j = XMin; j <= Xmax; j += m)
            //        {
            //            double newx1 = 0, newy1 = 0, newz1 = 0;
            //            double newx2 = 0, newy2 = 0, newz2 = 0;
            //            newz1 = RotateObject(Pitch, Yaw, Roll, XMin, j, i, ref newx1, ref newy1);
            //            newz2 = RotateObject(Pitch, Yaw, Roll, Xmax, j, i, ref newx2, ref newy2);
            //            Rectangle MyBox1 = new Rectangle(System.Convert.ToInt32(newx1), System.Convert.ToInt32(newy1), 1, 1);
            //            Rectangle MyBox2 = new Rectangle(System.Convert.ToInt32(newx2), System.Convert.ToInt32(newy2), 1, 1);
            //            GraphicObject.DrawEllipse(MyPen1, MyBox1);
            //            GraphicObject.DrawEllipse(MyPen2, MyBox2);
            //        }

            //        for (k = XMin; k <= Xmax; k += m)
            //        {
            //            double newx1 = 0, newy1 = 0, newz1 = 0;
            //            double newx2 = 0, newy2 = 0, newz2 = 0;
            //            newz1 = RotateObject(Pitch, Yaw, Roll, k, Xmax, i, ref newx1, ref newy1);
            //            newz2 = RotateObject(Pitch, Yaw, Roll, k, XMin, i, ref newx2, ref newy2);
            //            Rectangle MyBox3 = new Rectangle(System.Convert.ToInt32(newx1), System.Convert.ToInt32(newy1), 1, 1);
            //            Rectangle MyBox4 = new Rectangle(System.Convert.ToInt32(newx2), System.Convert.ToInt32(newy2), 1, 1);
            //            GraphicObject.DrawEllipse(MyPen3, MyBox3);
            //            GraphicObject.DrawEllipse(MyPen4, MyBox4);
            //        }
            //    }

            //    XMin = -(z0 + h) * d / (double)(2 * h);
            //    Xmax = (z0 + h) * d / (double)(2 * h);
            //    Pen MyPen5 = new Pen(Color.Brown, 1);
            //    for (j = XMin; j <= Xmax; j += m)
            //    {
            //        double newx1 = 0, newy1 = 0, newz1 = 0;
            //        double newx2 = 0, newy2 = 0, newz2 = 0;
            //        newz1 = RotateObject(Pitch, Yaw, Roll, j, XMin, z0 + h, ref newx1, ref newy1);
            //        newz2 = RotateObject(Pitch, Yaw, Roll, j, Xmax, z0 + h, ref newx2, ref newy2);

            //        GraphicObject.DrawLine(MyPen5, (float)newx1, (float)newy1, (float)newx2, (float)newy2);
            //    }

            //    Matrix myMatrix = new Matrix();
            //    myMatrix.Translate((float)(MyPictureBox.Width / (double)2), (float)(MyPictureBox.Height / (double)2), MatrixOrder.Append);
            //    G.Transform = myMatrix;
            //}

            //КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ КУБ
            int x0, y0, z0; // Координаты начала отсчета
            x0 = 20;
            y0 = 10;
            z0 = 5;
            int a, b, c; // Длины сторон параллепипеда
            a = 100;
            b = 100;
            c = 100;
            int i, j, k, l;
            int m; // Шаг итерации
            m = 1;
            Pen MyPen = new Pen(Color.Red);

            Pen MyPen1 = new Pen(Color.Blue, 1);
            Pen MyPen2 = new Pen(Color.Red, 1);
            Pen MyPen3 = new Pen(Color.Green, 1);
            Pen MyPen4 = new Pen(Color.Black, 1);
            Pen MyPen5 = new Pen(Color.Yellow, 1);
            Pen MyPen6 = new Pen(Color.Orchid, 1);

            GraphicObject.Clear(Color.White);

            for (i = x0; i <= x0 + a; i += m)
            {
                for (j = y0; j <= y0 + b; j += m)
                {
                    double newx1 = 0, newy1 = 0, newz1 = 0;
                    newz1 = RotateObject(Pitch, Yaw, Roll, i, j, z0, ref newx1, ref newy1);
                    Rectangle MyBox = new Rectangle((int)newx1, (int)newy1, m, m);
                    GraphicObject.DrawEllipse(MyPen5, MyBox);
                }
            }

            for (i = z0 + m; i <= z0 + c - m; i += m)
            {
                for (j = y0; j <= y0 + b; j += m)
                {
                    double newx1 = 0, newy1 = 0, newz1 = 0;
                    double newx2 = 0, newy2 = 0, newz2 = 0;
                    newz1 = RotateObject(Pitch, Yaw, Roll, x0, j, i, ref newx1, ref newy1);
                    newz2 = RotateObject(Pitch, Yaw, Roll, x0 + a, j, i, ref newx2, ref newy2);
                    Rectangle MyBox1 = new Rectangle(System.Convert.ToInt32(newx1), System.Convert.ToInt32(newy1), m, m);
                    Rectangle MyBox2 = new Rectangle(System.Convert.ToInt32(newx2), System.Convert.ToInt32(newy2), m, m);
                    GraphicObject.DrawEllipse(MyPen1, MyBox1);
                    GraphicObject.DrawEllipse(MyPen2, MyBox2);
                }

                for (k = x0; k <= x0 + a; k += m)
                {
                    double newx1 = 0, newy1 = 0, newz1 = 0;
                    double newx2 = 0, newy2 = 0, newz2 = 0;
                    newz1 = RotateObject(Pitch, Yaw, Roll, k, y0, i, ref newx1, ref newy1);
                    newz2 = RotateObject(Pitch, Yaw, Roll, k, y0 + b, i, ref newx2, ref newy2);
                    Rectangle MyBox3 = new Rectangle(System.Convert.ToInt32(newx1), System.Convert.ToInt32(newy1), m, m);
                    Rectangle MyBox4 = new Rectangle(System.Convert.ToInt32(newx2), System.Convert.ToInt32(newy2), m, m);
                    GraphicObject.DrawEllipse(MyPen3, MyBox3);
                    GraphicObject.DrawEllipse(MyPen4, MyBox4);
                }
            }

            for (i = x0; i <= x0 + a; i += m)
            {
                for (j = y0; j <= y0 + b; j += m)
                {
                    double newx1 = 0, newy1 = 0, newz1 = 0;
                    newz1 = RotateObject(Pitch, Yaw, Roll, i, j, z0 + c, ref newx1, ref newy1);
                    Rectangle MyBox = new Rectangle((int)newx1, (int)newy1, m, m);
                    GraphicObject.DrawEllipse(MyPen6, MyBox);
                }
            }

            Matrix myMatrix = new Matrix();
            myMatrix.Translate((int)(MyPictureBox.Width / (double)2), (float)(MyPictureBox.Height / 2), MatrixOrder.Append);
            G.Transform = myMatrix;
        }
    }
}
