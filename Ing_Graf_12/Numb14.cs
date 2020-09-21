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
    public partial class Numb14 : Form
    {
        public Numb14()
        {
            InitializeComponent();
        }

        Graphics G;
        double Pitch, Yaw, Roll;
        double Factor = Math.PI / 180;

        private void Zadanie_14_Load(object sender, EventArgs e)
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



            //ЦИЛИНДР ЦИЛИНДР ЦИЛИНДР ЦИЛИНДР ЦИЛИНДР ЦИЛИНДР ЦИЛИНДР ЦИЛИНДР
            {
                int x0, y0, z0, R, L, m;
                x0 = 100;

                y0 = 100;
                z0 = 100;
                R = 50;
                L = 100;
                m = 1;

                GraphicObject.Clear(Color.White);

                int i, j;

                for (i = x0 - R; i <= x0 + R; i += m)
                {
                    double y1, y2;
                    y1 = y0 - Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - x0), 2));
                    y2 = y0 + Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - x0), 2));
                    double x11 = 0, y11 = 0, z11 = 0;
                    double x21 = 0, y21 = 0, z21 = 0;
                    z11 = RotateObject(Pitch, Yaw, Roll, i, y1, z0, ref x11, ref y11);
                    z21 = RotateObject(Pitch, Yaw, Roll, i, y2, z0, ref x21, ref y21);
                    Rectangle MyBox1 = new Rectangle((int)x11, (int)y11, m, m);
                    Rectangle MyBox2 = new Rectangle((int)x21, (int)y21, m, m);
                    Pen MyPen1 = new Pen(Color.Green, 1);
                    Pen MyPen2 = new Pen(Color.Orchid, 1);
                    GraphicObject.DrawLine(MyPen1, (float)x11, (float)y11, (float)x21, (float)y21);
                    GraphicObject.DrawEllipse(MyPen1, MyBox1);
                    GraphicObject.DrawEllipse(MyPen2, MyBox2);

                }

                for (i = z0 - m; i <= z0 + L - m; i += m)
                {
                    for (j = x0 - R; j <= x0 + R; j += m)
                    {
                        double y1, y2;
                        y1 = y0 - Math.Sqrt(Math.Pow(R, 2) - Math.Pow((j - x0), 2));
                        y2 = y0 + Math.Sqrt(Math.Pow(R, 2) - Math.Pow((j - x0), 2));
                        double x11 = 0, y11 = 0, z11 = 0;
                        double x21 = 0, y21 = 0, z21 = 0;
                        z11 = RotateObject(Pitch, Yaw, Roll, j, y1, i, ref x11, ref y11);
                        z21 = RotateObject(Pitch, Yaw, Roll, j, y2, i, ref x21, ref y21);
                        Rectangle MyBox1 = new Rectangle((int)x11, (int)y11, m, m);
                        Rectangle MyBox2 = new Rectangle((int)x21, (int)y21, m, m);
                        Pen MyPen1 = new Pen(Color.Blue, 1);
                        Pen MyPen2 = new Pen(Color.Red, 1);
                        GraphicObject.DrawEllipse(MyPen1, MyBox1);
                        GraphicObject.DrawEllipse(MyPen2, MyBox2);
                    }
                }

                for (i = x0 - R; i <= x0 + R; i += m)
                {
                    double y1, y2;
                    y1 = y0 - Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - x0), 2));
                    y2 = y0 + Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - x0), 2));
                    double x11 = 0, y11 = 0, z11 = 0;
                    double x21 = 0, y21 = 0, z21 = 0;
                    z11 = RotateObject(Pitch, Yaw, Roll, i, y1, z0 + L, ref x11, ref y11);
                    z21 = RotateObject(Pitch, Yaw, Roll, i, y2, z0 + L, ref x21, ref y21);
                    Rectangle MyBox1 = new Rectangle((int)x11, (int)y11, m, m);
                    Rectangle MyBox2 = new Rectangle((int)x21, (int)y21, m, m);
                    Pen MyPen1 = new Pen(Color.Green, 1);
                    Pen MyPen2 = new Pen(Color.Orchid, 1);
                    GraphicObject.DrawLine(MyPen2, (float)x11, (float)y11, (float)x21, (float)y21);
                    GraphicObject.DrawEllipse(MyPen1, MyBox1);
                    GraphicObject.DrawEllipse(MyPen2, MyBox2);
                }

                Matrix myMatrix = new Matrix();
                myMatrix.Translate((float)(MyPictureBox.Width / (double)2), (float)(MyPictureBox.Height / (double)2), MatrixOrder.Append);
                G.Transform = myMatrix;
            }


         
        }
    }
}
