using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ing_Graf_12
{
    public partial class Numb9 : Form
    {
        Graphics G;
        double Factor = Math.PI / 180;
        double Pitch;
        double Yaw;
        double Roll;

        public Numb9()
        {
            InitializeComponent();
            Pitch = Factor * HScrollBarPitch.Value;
            Yaw = Factor * HScrollBarYaw.Value;
            Roll = Factor * HScrollBarRoll.Value;
        }
        public class Vertex
        {
            public double x;
            public double y;
            public double z;

            public Vertex()
            {

            }
            public Vertex(double x, double y,
        double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

        }
        public class Side
        {
            public Vertex a;
            public Vertex b;
            public Vertex c;
            public Vertex d;

            public Side()
            {
                this.a = null;
                this.b = null;
                this.c = null;
                this.d = null;
            }
            public Side(Vertex a1, Vertex b1,
    Vertex c1, Vertex d1)
            {

                this.a = a1;
                this.b = b1;
                this.c = c1;
                this.d = d1;
            }


        }


        ArrayList VertexList = new ArrayList();
        ArrayList SideList = new ArrayList();

        public void FillCube()
        {
            VertexList.Add(new Vertex(0, 0, 0));
            VertexList.Add(new Vertex(100, 0, 0));
            VertexList.Add(new Vertex(100, 0, 100));
            VertexList.Add(new Vertex(0, 0, 100));
            VertexList.Add(new Vertex(0, 100, 0));
            VertexList.Add(new Vertex(100, 100, 0));
            VertexList.Add(new Vertex(100, 100, 100));
            VertexList.Add(new Vertex(0, 100, 100));

            SideList.Add(new Side((Vertex)VertexList[0], (Vertex)VertexList[1], (Vertex)VertexList[2], (Vertex)VertexList[3]));

            SideList.Add(new Side((Vertex)VertexList[4], (Vertex)VertexList[5],
            (Vertex)VertexList[6], (Vertex)VertexList[7]));
            SideList.Add(new Side((Vertex)VertexList[6], (Vertex)VertexList[5],
            (Vertex)VertexList[1], (Vertex)VertexList[2]));
            SideList.Add(new Side((Vertex)VertexList[7], (Vertex)VertexList[4],
            (Vertex)VertexList[0], (Vertex)VertexList[3]));
            SideList.Add(new Side((Vertex)VertexList[0], (Vertex)VertexList[4],
           (Vertex)VertexList[5], (Vertex)VertexList[1]));
            SideList.Add(new Side((Vertex)VertexList[7], (Vertex)VertexList[6],
            (Vertex)VertexList[2], (Vertex)VertexList[3]));

        }

        public double RotateObject(double Pitch, double Yaw, double Roll, double x, double y, double z, ref double NewX, ref double NewY)
        {
            double[,] m = new double[4, 4];
            m[1, 1] = Math.Cos(Yaw) * Math.Cos(Roll);
            m[1, 2] = -Math.Cos(Yaw) * Math.Sin(Roll);
            m[1, 3] = -Math.Sin(Yaw);
            m[2, 1] = Math.Sin(Pitch) * Math.Sin(Yaw) * Math.Cos(Roll) + Math.Sin(Roll) *
            Math.Cos(Pitch);
            m[2, 2] = -Math.Sin(Pitch) * Math.Sin(Yaw) * Math.Sin(Roll) + Math.Cos(Roll) *
            Math.Cos(Pitch);
            m[2, 3] = Math.Cos(Yaw);
            m[3, 1] = -Math.Cos(Pitch) * Math.Sin(Yaw) * Math.Cos(Roll) + Math.Sin(Pitch) *
            Math.Sin(Roll);
            m[3, 2] = Math.Cos(Pitch) * Math.Sin(Yaw) * Math.Sin(Roll) + Math.Sin(Pitch) *
            Math.Cos(Roll);
            m[3, 3] = Math.Cos(Yaw) * Math.Cos(Pitch);
            double NewZ;
            NewX = m[1, 1] * x + m[2, 1] * y + m[3, 1] * z;
            NewY = m[1, 2] * x + m[2, 2] * y + m[3, 2] * z;
            NewZ = m[1, 3] * x + m[2, 3] * y + m[3, 3] * z;
            return NewZ;

        }
        public void DrawShape(Graphics GraphicObject)
        {
            int ArraySize;
            ArraySize = 9;
            double[] NewX = new double[ArraySize], NewY = new double[ArraySize], NewZ = new double[ArraySize];
            int i;

            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush MyBrush = new SolidBrush(Color.Blue);

            GraphicObject.Clear(Color.White);
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(pictureBox1.Width / 2, pictureBox1.Height /
            2, MatrixOrder.Append);
            G.Transform = myMatrix;

            for (i = 0; i < ArraySize - 1; i++)
            {
                NewZ[i] = RotateObject(Pitch, Yaw, Roll, ((Vertex)VertexList[i]).x, ((Vertex)VertexList[i]).y, ((Vertex)VertexList[i]).z, ref NewX[i], ref NewY[i]);
                Rectangle MyBox = new Rectangle((int)NewX[i], (int)NewY[i], 10, 10);
                GraphicObject.DrawEllipse(MyPen, MyBox);
                GraphicObject.FillEllipse(MyBrush, MyBox);
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

        private void FormLab9_Load(object sender, EventArgs e)
        {
            G = pictureBox1.CreateGraphics();
            FillCube();
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
}
