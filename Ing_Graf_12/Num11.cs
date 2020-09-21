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
    public partial class Num11 : Form
    {
        double factor = Math.PI / 180;
        double X, Y, Z;
        List<Vertex> VertexList = new List<Vertex>();
        List<Side> SideList = new List<Side>();
        ArrayList SurFaceList = new ArrayList();
        //List<SurFace> SurFaceList = new List<SurFace>();
        public Num11()
        {
            InitializeComponent();
            X = factor * hScrollBarX.Value;
            Y = factor * hScrollBarY.Value;
            Z = factor * hScrollBarZ.Value;
            FillCube();
            FillSurFace();
        }
        public class Vertex
        {
            public double x, y, z;
            public Vertex(double _x, double _y, double _z)
            {
                this.x = _x;
                this.y = _y;
                this.z = _z;
            }
        }
        public class Side
        {
            public Vertex a, b, c, d;
            public Side(Vertex _a, Vertex _b, Vertex _c, Vertex _d)
            {
                this.a = _a;
                this.b = _b;
                this.c = _c;
                this.d = _d;
            }
        }

        public class SurFace
        {
            public Vertex x1, x2, x3, x4;
            public SurFace(Vertex _x1, Vertex _x2, Vertex _x3, Vertex _x4)
            {
                this.x1 = _x1;
                this.x2 = _x2;
                this.x3 = _x3;
                this.x4 = _x4;
            }
        }

        public class NewSurFace
        {
            public SurFace x;
            public int z;
            public NewSurFace(SurFace _x, int _z)
            {
                this.x = _x;
                this.z = _z;
            }
        }
        public class VertexComparer : IComparer
        {
            int IComparer.Compare(object o1, object o2)
            {
                NewSurFace z1;
                NewSurFace z2;
                z1 = (NewSurFace)o1;
                z2 = (NewSurFace)o2;
                if (z1.z < z2.z)
                {
                    return 1;
                }
                else
                {
                    if (z1.z > z2.z)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public void FillCube()
        {
            VertexList.Add(new Vertex(200, 200, 200));
            VertexList.Add(new Vertex(300, 200, 200));
            VertexList.Add(new Vertex(300, 200, 300));
            VertexList.Add(new Vertex(200, 200, 300));
            VertexList.Add(new Vertex(200, 300, 200));
            VertexList.Add(new Vertex(300, 300, 200));
            VertexList.Add(new Vertex(300, 300, 300));
            VertexList.Add(new Vertex(200, 300, 300));
            SideList.Add(new Side(VertexList[0], VertexList[1], VertexList[2], VertexList[3]));
            SideList.Add(new Side(VertexList[4], VertexList[5], VertexList[6], VertexList[7]));
            SideList.Add(new Side(VertexList[6], VertexList[5], VertexList[1], VertexList[2]));
            SideList.Add(new Side(VertexList[7], VertexList[4], VertexList[0], VertexList[3]));
            SideList.Add(new Side(VertexList[0], VertexList[4], VertexList[5], VertexList[1]));
            SideList.Add(new Side(VertexList[7], VertexList[6], VertexList[2], VertexList[3]));
        }

        public void FillSurFace()
        {
            SurFaceList.Add(new SurFace(new Vertex(200, 200, 200), new Vertex(300, 200, 200), new Vertex(300, 200, 300), new Vertex(200, 200, 300)));
            SurFaceList.Add(new SurFace(new Vertex(200, 200, 300), new Vertex(200, 300, 300), new Vertex(300, 300, 300), new Vertex(300, 200, 300)));
            SurFaceList.Add(new SurFace(new Vertex(200, 200, 300), new Vertex(200, 300, 300), new Vertex(200, 300, 200), new Vertex(200, 200, 200)));
            SurFaceList.Add(new SurFace(new Vertex(200, 200, 200), new Vertex(200, 300, 200), new Vertex(300, 300, 200), new Vertex(300, 200, 200)));
            SurFaceList.Add(new SurFace(new Vertex(300, 200, 200), new Vertex(300, 200, 300), new Vertex(300, 300, 300), new Vertex(300, 300, 200)));
            SurFaceList.Add(new SurFace(new Vertex(200, 300, 300), new Vertex(200, 300, 200), new Vertex(300, 300, 200), new Vertex(300, 300, 300)));
        }
        private void hScrollBarX_Scroll(object sender, ScrollEventArgs e)
        {
            X = hScrollBarX.Value;
            pictureBox1.Invalidate();
        }

        private void hScrollBarY_Scroll(object sender, ScrollEventArgs e)
        {
            Y = hScrollBarY.Value;
            pictureBox1.Invalidate();
        }

        private void hScrollBarZ_Scroll(object sender, ScrollEventArgs e)
        {
            Z = hScrollBarZ.Value;
            pictureBox1.Invalidate();
        }
        private double RotateObj(double X, double Y, double Z, double x, double y, double z, ref double NewX, ref double NewY)
        {
            double NewZ = 0;
            double[,] m = new double[3, 3];
            m[0, 0] = Math.Cos(Y) * Math.Cos(Z);
            m[0, 1] = -Math.Cos(Y) * Math.Cos(Z);
            m[0, 2] = -Math.Sin(Y);
            m[1, 0] = Math.Sin(X) * Math.Sin(Y) * Math.Cos(Z) + Math.Sin(Z) * Math.Cos(X);
            m[1, 1] = -Math.Sin(X) * Math.Sin(Y) * Math.Sin(Z) + Math.Cos(Z) * Math.Cos(X);
            m[1, 2] = Math.Cos(Y);
            m[2, 0] = -Math.Cos(X) * Math.Sin(Y) * Math.Cos(Z) + Math.Sin(X) * Math.Sin(Z);
            m[2, 1] = Math.Cos(X) * Math.Sin(Y) * Math.Sin(Z) + Math.Sin(X) * Math.Cos(Z);
            m[2, 2] = Math.Cos(Y) * Math.Cos(X);
            NewX = m[0, 0] * x + m[1, 0] * y + m[2, 0] * z;
            NewY = m[0, 1] * x + m[1, 1] * y + m[2, 1] * z;
            NewZ = m[0, 2] * x + m[1, 2] * y + m[2, 2] * z;
            return NewZ;
        }
        private Vertex RotateVertex(double X, double Y, double Z, Vertex vertex)
        {
            double x, y, z, NewX, NewY, NewZ;
            x = vertex.x;
            y = vertex.y;
            z = vertex.z;
            double[,] m = new double[3, 3];
            m[0, 0] = Math.Cos(Y) * Math.Cos(Z);
            m[0, 1] = -Math.Cos(Y) * Math.Cos(Z);
            m[0, 2] = -Math.Sin(Y);
            m[1, 0] = Math.Sin(X) * Math.Sin(Y) * Math.Cos(Z) + Math.Sin(Z) * Math.Cos(X);
            m[1, 1] = -Math.Sin(X) * Math.Sin(Y) * Math.Sin(Z) + Math.Cos(Z) * Math.Cos(X);
            m[1, 2] = Math.Cos(Y);
            m[2, 0] = -Math.Cos(X) * Math.Sin(Y) * Math.Cos(Z) + Math.Sin(X) * Math.Sin(Z);
            m[2, 1] = Math.Cos(X) * Math.Sin(Y) * Math.Sin(Z) + Math.Sin(X) * Math.Cos(Z);
            m[2, 2] = Math.Cos(Y) * Math.Cos(X);
            NewX = m[0, 0] * x + m[1, 0] * y + m[2, 0] * z;
            NewY = m[0, 1] * x + m[1, 1] * y + m[2, 1] * z;
            NewZ = m[0, 2] * x + m[1, 2] * y + m[2, 2] * z;
            Vertex newVertex = new Vertex(NewX, NewY, NewZ);
            return newVertex;
        }
        private SurFace RotateSurFace(double X, double Y, double Z, SurFace surface)
        {
            Vertex x1, x2, x3, x4;
            x1 = surface.x1;
            x2 = surface.x2;
            x3 = surface.x3;
            x4 = surface.x4;
            Vertex newX1, newX2, newX3, newX4;
            newX1 = RotateVertex(X, Y, Z, x1);
            newX2 = RotateVertex(X, Y, Z, x2);
            newX3 = RotateVertex(X, Y, Z, x3);
            newX4 = RotateVertex(X, Y, Z, x4);
            SurFace newSurFace = new SurFace(newX1, newX2, newX3, newX4);
            return newSurFace;
        }



        private void DrawShape(PaintEventArgs e)
        {

            Matrix matrix = new Matrix();
            float Xstart = 0;
            float Ystart = 0;
            SolidBrush[] solids = new SolidBrush[] { new SolidBrush(Color.Blue), new SolidBrush(Color.Red), new SolidBrush(Color.Black), new SolidBrush(Color.Purple), new SolidBrush(Color.Orchid), new SolidBrush(Color.Green) };
                    SurFace[] xtemp = new SurFace[SurFaceList.Count];
                    SurFace[] newxtemp = new SurFace[SurFaceList.Count];
                    ArrayList NewSurFaceList = new ArrayList();
                    for (int i = 0; i <= SurFaceList.Count - 1; i++)
                    {
                        xtemp[i] = (SurFace)SurFaceList[i];
                        int a, b, c;
                        a = Convert.ToInt32((((SurFace)SurFaceList[i]).x1.x + ((SurFace)SurFaceList[i]).x2.x + ((SurFace)SurFaceList[i]).x3.x + ((SurFace)SurFaceList[i]).x4.x) / 4);
                        b = Convert.ToInt32((((SurFace)SurFaceList[i]).x1.y + ((SurFace)SurFaceList[i]).x2.y + ((SurFace)SurFaceList[i]).x3.y + ((SurFace)SurFaceList[i]).x4.y) / 4);
                        c = Convert.ToInt32((((SurFace)SurFaceList[i]).x1.z + ((SurFace)SurFaceList[i]).x2.z + ((SurFace)SurFaceList[i]).x3.z + ((SurFace)SurFaceList[i]).x4.z) / 4);
                        Vertex V = new Vertex(a, b, c);
                        Vertex NewV;
                        NewV = RotateVertex(X, Y, Z, V);
                        int z;
                        z = Convert.ToInt32(NewV.z);
                        newxtemp[i] = RotateSurFace(X, Y, Z, xtemp[i]);
                        NewSurFaceList.Add(new NewSurFace(newxtemp[i], z));
                    }
                    NewSurFaceList.Sort(new VertexComparer());
                    for (int i = 0; i <= SurFaceList.Count - 1; i++)
                    {
                        PointF[] curvePoints = { new PointF((float)((NewSurFace)NewSurFaceList[i]).x.x1.x, (float)((NewSurFace)NewSurFaceList[i]).x.x1.y),
                    new PointF((float)((NewSurFace)NewSurFaceList[i]).x.x2.x, (float)((NewSurFace)NewSurFaceList[i]).x.x2.y),
                    new PointF((float)((NewSurFace)NewSurFaceList[i]).x.x3.x, (float)((NewSurFace)NewSurFaceList[i]).x.x3.y),
                    new PointF((float)((NewSurFace)NewSurFaceList[i]).x.x4.x, (float)((NewSurFace)NewSurFaceList[i]).x.x4.y)};
                        e.Graphics.FillPolygon(solids[i], curvePoints, FillMode.Winding);
                    }
                    Xstart = pictureBox1.Width / 2;
                    Ystart = pictureBox1.Height / 2;
                    matrix = new Matrix();
                    matrix.Translate(Xstart, Ystart);
                    e.Graphics.Transform = matrix;
                    
               
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawShape(e);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
