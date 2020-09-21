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
    public partial class Numb15 : Form
    {
        public Numb15()
        {
            InitializeComponent();
        }

        Graphics G;
        double Pitch, Yaw, Roll;
        double Factor = Math.PI / 180;

        private void Zadanie_15_Load(object sender, EventArgs e)
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
            {
                int x0, y0, z0, R, m;
                x0 = 5;
                y0 = 5;
                z0 = 5;
                R = 50;
                m = 1;

                GraphicObject.Clear(Color.White);

                int ZMin, Zmax;
                ZMin = z0 - R;
                Zmax = z0 + R;
                int i, j;
                Pen MyPen1 = new Pen(Color.Blue, 1);
                Pen MyPen2 = new Pen(Color.Red, 1);
                for (i = ZMin; i <= Zmax; i += m)
                {
                    int XMin, XMax;
                    XMin = (int)(x0 - Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - z0), 2)));
                    XMax = (int)(x0 + Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - z0), 2)));
                    int SmallR;
                    SmallR = (int)(Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - z0), 2)));
                    for (j = XMin; j <= XMax; j += m)
                    {
                        double y1, y2;
                        y1 = y0 + Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((j - x0), 2));
                        y2 = y0 - Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((j - x0), 2));
                        double NewX1 = 0, NewY1 = 0, NewZ1 = 0;
                        double NewX2 = 0, NewY2 = 0, NewZ2 = 0;
                        NewZ1 = RotateObject(Pitch, Yaw, Roll, j, y1, i, ref NewX1, ref NewY1);
                        NewZ2 = RotateObject(Pitch, Yaw, Roll, j, y2, i, ref NewX2, ref NewY2);
                        Rectangle MyBox1 = new Rectangle((int)NewX1, (int)NewY1, m, m);
                        Rectangle MyBox2 = new Rectangle((int)NewX2, (int)NewY2, m, m);
                        GraphicObject.DrawEllipse(MyPen1, MyBox1);
                        GraphicObject.DrawEllipse(MyPen2, MyBox2);
                    }
                }

                Matrix myMatrix = new Matrix();
                myMatrix.Translate((float)(MyPictureBox.Width / (double)2), (float)(MyPictureBox.Height / (double)2), MatrixOrder.Append);
                G.Transform = myMatrix;
            }




        }
    }
}
