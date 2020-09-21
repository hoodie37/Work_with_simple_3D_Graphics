using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;

namespace Ing_Graf_12
{
    public partial class Numb18 : Form
    {
        public Numb18()
        {
            InitializeComponent();
        }
        Graphics G;
        double Pitch, Yaw, Roll;
        double Factor = Math.PI / 180;
        private void Zadanie_18_Load(object sender, EventArgs e)
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
            FillClippedCone();

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
        public void DrawShape(Graphics GraphicObject)
        {
            G.Clear(Color.White);
            int GListCount;
            GListCount = GList.Count - 1;
            int i;
            Pen MyPen = new Pen(Color.Red, 1);
            for (i = 0; i <= GListCount; i++)
            {
                int x, y, z;
                double newx = 0, newy = 0, newz = 0;
                x = ((Vertex_Coordinate)GList[i]).x;
                y = ((Vertex_Coordinate)GList[i]).y;
                z = ((Vertex_Coordinate)GList[i]).z;
                newz = RotateObject(Pitch, Yaw, Roll, x, y, z, ref newx, ref newy);
                Rectangle MyBox = new Rectangle((int)newx, (int)newy, 1, 1);
                G.DrawEllipse(MyPen, MyBox);
            }
            int xstart, ystart;
            xstart = MyPictureBox.Width / 2;
            ystart = MyPictureBox.Height / 2;
            Matrix MyMatrix = new Matrix();
            MyMatrix.Translate(xstart, ystart);
            G.Transform = MyMatrix;
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

        public class Vertex_Coordinate
        {
            public int x;
            public int y;
            public int z;

            public Vertex_Coordinate(int x, int y, int z) : base()
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        private ArrayList GList = new ArrayList();

        public int RotateAboutAlphaBeta(double alpha, double beta, int x0, int y0, int z0, ref int x, ref int y)
        {
            int z;
            double factor;
            factor = Math.PI / 180;
            x = (int)(Math.Cos(alpha) * x0 + Math.Sin(alpha) * Math.Sin(-beta) * y0 + Math.Sin(alpha) * Math.Cos(-beta) * z0);
            y = (int)(Math.Cos(-beta) * y0 - Math.Sin(-beta) * z0);
            z = (int)(-Math.Sin(alpha) * x0 + Math.Cos(alpha) * Math.Sin(-beta) * y0 + Math.Cos(alpha) * Math.Cos(-beta) * z0);
            return z;
        }

        private void MyPictureBox_Click(object sender, EventArgs e)
        {

        }

        public ArrayList GetClippedCone(int Length, int RBig, int RSmall, int m)
        {
            ArrayList MyList = new ArrayList();
            int i, j;
            int ZMin, ZMax;
            ZMin = 0;
            ZMax = Length;
            for (i = ZMin; i <= ZMax; i += m)
            {
                int XMin, XMax;
                int SmallR;
                SmallR = (RBig - i * (RBig - RSmall) / Length);
                XMin = -SmallR;
                XMax = SmallR;
                for (j = XMin; j <= XMax; j += m)
                {
                    int YMin, YMax, x, z;
                    x = j;
                    z = i;
                    YMin = (int)(-Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((x), 2)));
                    YMax = (int)(Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((x), 2)));
                    MyList.Add(new Vertex_Coordinate(j, YMin, i));
                    MyList.Add(new Vertex_Coordinate(j, YMax, i));
                }
            }
            return MyList;
        }

        public void FillClippedCone()
        {
            int Segments_Count;
            Segments_Count = 3;
            int[] x = new int[Segments_Count + 1], y = new int[Segments_Count + 1], z = new int[Segments_Count + 1];
            double[] alpha = new double[Segments_Count + 1], beta = new double[Segments_Count + 1], Length = new double[Segments_Count + 1];
            int[] RBig = new int[Segments_Count + 1], RSmall = new int[Segments_Count + 1];
            int m;
            m = 5;
            RBig[0] = 60;
            RSmall[0] = 50;
            RBig[1] = 50;
            RSmall[1] = 40;
            RBig[2] = 40;
            RSmall[2] = 30;
            double factor;
            factor = Math.PI / 180;
            alpha[0] = factor * 15;
            beta[0] = factor * 25;
            alpha[1] = factor * 30;
            beta[1] = factor * 45;
            alpha[2] = factor * 15;
            beta[2] = factor * 30;
            Length[0] = 200;
            Length[1] = 150;
            Length[2] = 100;
            x[0] = 0;
            y[0] = 0;
            z[0] = 0;
            int i, j;
            for (i = 1; i <= Segments_Count; i++)
            {
                x[i] = x[i - 1] + System.Convert.ToInt32(Length[i - 1] * Math.Cos(beta[i - 1]) * Math.Sin(alpha[i - 1]));
                y[i] = y[i - 1] + System.Convert.ToInt32(Length[i - 1] * Math.Sin(beta[i - 1]));
                z[i] = z[i - 1] + System.Convert.ToInt32(Length[i - 1] * Math.Cos(beta[i - 1]) * Math.Cos(alpha[i - 1]));
                ArrayList MyList = new ArrayList();
                MyList = GetClippedCone((int)Length[i - 1], RBig[i - 1], RSmall[i - 1], m);
                int MyListCount;
                MyListCount = MyList.Count - 1;
                for (j = 0; j <= MyListCount; j++)
                {
                    int x1, y1, z1, newx = 0, newy = 0, newz = 0;
                    x1 = ((Vertex_Coordinate)MyList[j]).x;
                    y1 = ((Vertex_Coordinate)MyList[j]).y;
                    z1 = ((Vertex_Coordinate)MyList[j]).z;
                    newz = RotateAboutAlphaBeta(alpha[i - 1], beta[i - 1], x1, y1, z1, ref newx, ref newy);
                    int nx, ny, nz;
                    nx = newx + x[i - 1];
                    ny = newy + y[i - 1];
                    nz = newz + z[i - 1];
                    GList.Add(new Vertex_Coordinate(nx, ny, nz));
                }
            }
        }
    }
}