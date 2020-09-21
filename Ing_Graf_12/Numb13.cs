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
    public partial class Numb13 : Form
    {
        public Numb13()
        {
            InitializeComponent();
        }

        

        Graphics G;
        double Pitch, Yaw, Roll;
        double Factor = Math.PI / 180;

        private void _13_Load(object sender, EventArgs e)
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



            //ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА ПИРАМИДА

            {
                int x0, y0, z0, h, d, m;
                x0 = 0;
                y0 = 0;
                z0 = 0;
                h = 150;
                d = 70;
                m = 1;

                GraphicObject.Clear(Color.White);

                double i, j, k;
                Pen MyPen1 = new Pen(Color.Blue, 1);
                Pen MyPen2 = new Pen(Color.Red, 1);
                Pen MyPen3 = new Pen(Color.Green, 1);
                Pen MyPen4 = new Pen(Color.Black, 1);

                double XMin, Xmax;


                for (i = z0; i <= z0 + h; i += m)
                {
                    XMin = -(z0 + i) * d / (2 * h);
                    Xmax = (z0 + i) * d / (2 * h);
                    for (j = XMin; j <= Xmax; j += m)
                    {
                        double newx1 = 0, newy1 = 0, newz1 = 0;
                        double newx2 = 0, newy2 = 0, newz2 = 0;
                        newz1 = RotateObject(Pitch, Yaw, Roll, XMin, j, i, ref newx1, ref newy1);
                        newz2 = RotateObject(Pitch, Yaw, Roll, Xmax, j, i, ref newx2, ref newy2);
                        Rectangle MyBox1 = new Rectangle(System.Convert.ToInt32(newx1), System.Convert.ToInt32(newy1), 1, 1);
                        Rectangle MyBox2 = new Rectangle(System.Convert.ToInt32(newx2), System.Convert.ToInt32(newy2), 1, 1);
                        GraphicObject.DrawEllipse(MyPen1, MyBox1);
                        GraphicObject.DrawEllipse(MyPen2, MyBox2);
                    }

                    for (k = XMin; k <= Xmax; k += m)
                    {
                        double newx1 = 0, newy1 = 0, newz1 = 0;
                        double newx2 = 0, newy2 = 0, newz2 = 0;
                        newz1 = RotateObject(Pitch, Yaw, Roll, k, Xmax, i, ref newx1, ref newy1);
                        newz2 = RotateObject(Pitch, Yaw, Roll, k, XMin, i, ref newx2, ref newy2);
                        Rectangle MyBox3 = new Rectangle(System.Convert.ToInt32(newx1), System.Convert.ToInt32(newy1), 1, 1);
                        Rectangle MyBox4 = new Rectangle(System.Convert.ToInt32(newx2), System.Convert.ToInt32(newy2), 1, 1);
                        GraphicObject.DrawEllipse(MyPen3, MyBox3);
                        GraphicObject.DrawEllipse(MyPen4, MyBox4);
                    }
                }

                XMin = -(z0 + h) * d / (double)(2 * h);
                Xmax = (z0 + h) * d / (double)(2 * h);
                Pen MyPen5 = new Pen(Color.Brown, 1);
                for (j = XMin; j <= Xmax; j += m)
                {
                    double newx1 = 0, newy1 = 0, newz1 = 0;
                    double newx2 = 0, newy2 = 0, newz2 = 0;
                    newz1 = RotateObject(Pitch, Yaw, Roll, j, XMin, z0 + h, ref newx1, ref newy1);
                    newz2 = RotateObject(Pitch, Yaw, Roll, j, Xmax, z0 + h, ref newx2, ref newy2);

                    GraphicObject.DrawLine(MyPen5, (float)newx1, (float)newy1, (float)newx2, (float)newy2);
                }

                Matrix myMatrix = new Matrix();
                myMatrix.Translate((float)(MyPictureBox.Width / (double)2), (float)(MyPictureBox.Height / (double)2), MatrixOrder.Append);
                G.Transform = myMatrix;
            }

        }
    }
}
