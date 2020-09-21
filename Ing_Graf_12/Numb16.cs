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
    public partial class Numb16 : Form
    {
        public Numb16()
        {
            InitializeComponent();
        }

        Graphics G;
        double Pitch, Yaw, Roll;
        double Factor = Math.PI / 180;

        private void Zadanie_16_Load(object sender, EventArgs e)
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



        public Double rotate(Double Pitch, Double Yaw, Double Roll, Double x, Double y, Double z, Double NewX, Double NewY)
        {
            Double[][] m = new double[3][];
            m[1][1] = Math.Cos(Yaw) * Math.Cos(Roll);
            m[1][2] = -Math.Cos(Yaw) * Math.Sin(Roll);
            m[1][3] = -Math.Sin(Yaw);
            m[2][1] = Math.Sin(Pitch) * Math.Sin(Yaw) * Math.Cos(Roll) + Math.Sin(Roll)
            * Math.Cos(Pitch);
            m[2][2] = -Math.Sin(Pitch) * Math.Sin(Yaw) * Math.Sin(Roll) + Math.Cos(Roll)
            * Math.Cos(Pitch);
            m[2][3] = Math.Cos(Yaw);
            m[3][1] = -Math.Cos(Pitch) * Math.Sin(Yaw) * Math.Cos(Roll) + Math.Sin(Pitch)
            * Math.Sin(Roll);
            m[3][2] = Math.Cos(Pitch) * Math.Sin(Yaw) * Math.Sin(Roll) + Math.Sin(Pitch)
            * Math.Cos(Roll);
            m[3][3] = Math.Cos(Yaw) * Math.Cos(Pitch);

            Double NewZ;
            NewX = m[1][1] * x + m[2][1] * y + m[3][1] * z;
            NewY = m[1][2] * x + m[2][2] * y + m[3][2] * z;
            NewZ = m[1][3] * x + m[2][3] * y + m[3][3] * z;
            return 0;
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
            NewX = (m[1, 1] * x) + m[2, 1] * y + m[3, 1] * z;
            NewY = m[1, 2] * x + m[2, 2] * y + m[3, 2] * z;
            NewZ = m[1, 3] * x + m[2, 3] * y + m[3, 3] * z;
            return NewZ;
        }

        public void DrawShape(Graphics GraphicObject)
        {
            int x0, y0, z0, h, R, m;
            x0 = 5;
            y0 = 5;
            z0 = 5;
            h = 100;
            R = 60;
            m = 1;

            GraphicObject.Clear(Color.White);

            double i, j;
            int ZMin, ZMax;
            ZMin = z0;
            ZMax = z0 + h;

            double XMin, XMax;
            double SmallR;


            SmallR = (R / h) * (h + z0);
            XMin = x0 - SmallR;
            XMax = x0 + SmallR;

            for (j = XMin; j <= XMax; j += m)
            {
                int YMin, YMax, x, z;
                x = (int)j;
                z = z0;
                YMin = y0 - (int)Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow(x - x0, 2));
                YMax = y0 + (int)Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow(x - x0, 2));
                double NewX1 = 0, NewY1 = 0, NewZ1 = 0, Newx2 = 0, NewY2 = 0, NewZ2;
                NewZ1 = RotateObject(Pitch, Yaw, Roll, x, YMin, z, ref NewX1, ref NewY1);
                NewZ2 = RotateObject(Pitch, Yaw, Roll, x, YMax, z, ref Newx2, ref NewY2);

                Pen MyPen1 = new Pen(Color.Yellow, 1);
                Pen MyPen2 = new Pen(Color.Blue, 1);
                Rectangle MyBox1 = new Rectangle(System.Convert.ToInt32(NewX1), System.Convert.ToInt32(NewY1), 1, 1);
                Rectangle MyBox2 = new Rectangle(System.Convert.ToInt32(Newx2), System.Convert.ToInt32(NewY2), 1, 1);
                GraphicObject.DrawLine(MyPen1, (float)NewX1, (float)NewY1, (float)Newx2, (float)NewY2);
            }

            for (i = ZMin; i <= ZMax; i += m)
            {
                SmallR = (R / (double)h) * (h + z0 - i);
                XMin = x0 - SmallR;
                XMax = x0 + SmallR;
                for (j = XMin; j <= XMax; j += m)
                {
                    double YMin, YMax, x, z;
                    x = j;
                    z = i;
                    YMin = y0 - Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((x - x0), 2));
                    YMax = y0 + Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((x - x0), 2));
                    double NewX1 = 0, NewY1 = 0, NewZ1 = 0, Newx2 = 0, NewY2 = 0, NewZ2 = 0;
                    NewZ1 = RotateObject(Pitch, Yaw, Roll, x, YMin, z, ref NewX1, ref NewY1);
                    NewZ2 = RotateObject(Pitch, Yaw, Roll, x, YMax, z, ref Newx2, ref NewY2);

                    Pen MyPen1 = new Pen(Color.Red, 1);
                    Pen MyPen2 = new Pen(Color.Blue, 1);
                    try
                    {
                        Rectangle MyBox1 = new Rectangle(System.Convert.ToInt32(NewX1), System.Convert.ToInt32(NewY1), 1, 1);
                        Rectangle MyBox2 = new Rectangle(System.Convert.ToInt32(Newx2), System.Convert.ToInt32(NewY2), 1, 1);
                        GraphicObject.DrawEllipse(MyPen1, MyBox1);
                        GraphicObject.DrawEllipse(MyPen2, MyBox2);
                    }
                    catch (Exception ex) { }
                }
            }

            Matrix myMatrix = new Matrix();
            myMatrix.Translate(MyPictureBox.Width / 2, MyPictureBox.Height
            / 2, MatrixOrder.Append);
            G.Transform = myMatrix;
        }


    }
}

