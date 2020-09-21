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
    public partial class Numb3 : Form
    {
        double Factor = Math.PI / 180;
        public int vertexnum = 3;
        double[] x = new double[3];
        double[] y = new double[3];
        double[] z = new double[3];
        double[] newX = new double[3];
        double[] newY = new double[3];
        double[] newZ = new double[3];
        PointF[] points = new PointF[3];

        Graphics G;
        int Scrollnumber = -1;
        int Pitch;
        int Yaw;
        int Roll;
        public Numb3()
        {
            InitializeComponent();
            Pitch = hScrollBar1.Value;
            Yaw = hScrollBar2.Value;
            Roll = hScrollBar3.Value;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            G = pictureBox1.CreateGraphics();
            hScrollBar1.Minimum = 1;
            hScrollBar1.Maximum = 369;

            hScrollBar2.Minimum = 1;
            hScrollBar2.Maximum = 369;

            hScrollBar3.Minimum = 1;
            hScrollBar3.Maximum = 369;
            x[0] = 200;
            y[0] = 100;

            x[1] = 300;
            y[1] = 300;

            x[2] = 400;
            y[2] = 100;

        }
        private double RotateX(double Pitch, double Yaw, double Roll, double x1, double y1, double z1, ref double NewX, ref double NewY)
        {
            double[,] arraym = new double[3, 3];
            arraym[0, 0] = Math.Cos(Factor * Yaw) * Math.Cos(Factor * Roll);
            arraym[0, 1] = -Math.Cos(Factor * Yaw) * Math.Sin(Factor * Roll);
            arraym[0, 2] = -Math.Sin(Factor * Yaw);
            arraym[1, 0] = Math.Sin(Factor * Pitch) * Math.Sin(Factor * Yaw) * Math.Cos(Factor * Roll) + Math.Sin(Factor * Roll) * Math.Cos(Factor * Pitch);
            arraym[1, 1] = -Math.Sin(Factor * Pitch) * Math.Sin(Factor * Yaw) * Math.Sin(Factor * Roll) + Math.Cos(Factor * Roll) * Math.Cos(Factor * Pitch);
            arraym[1, 2] = Math.Cos(Factor * Yaw);
            arraym[2, 0] = -Math.Cos(Factor * Pitch) * Math.Sin(Factor * Yaw) * Math.Cos(Factor * Roll) + Math.Sin(Factor * Pitch) * Math.Sin(Factor * Roll);
            arraym[2, 1] = Math.Cos(Factor * Pitch) * Math.Sin(Factor * Yaw) * Math.Sin(Factor * Roll) + Math.Sin(Factor * Pitch) * Math.Cos(Factor * Roll);
            arraym[2, 2] = Math.Cos(Factor * Yaw) * Math.Cos(Factor * Pitch);
            double NewZ = 0;
            NewX = arraym[0, 0] * x1 + arraym[1, 0] * y1 + arraym[2, 0] * z1;
            NewY = arraym[0, 1] * x1 + arraym[1, 1] * y1 + arraym[2, 1] * z1;
            NewZ = arraym[0, 2] * x1 + arraym[1, 2] * y1 + arraym[2, 2] * z1;

            return NewZ;
        }

        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                Scrollnumber = 1; Pitch = hScrollBar1.Value;

            }
            pictureBox1.Invalidate();


        }

        private void HScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {

            if (e.OldValue != e.NewValue)
            {
                Scrollnumber = 1; Yaw = hScrollBar2.Value;

            }
            pictureBox1.Invalidate();


        }


        private void HScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                Scrollnumber = 1; Roll = hScrollBar3.Value;

            }
            pictureBox1.Invalidate();


        }


        private void pictureBoxLab2_Paint(object sender, PaintEventArgs e)
        {
            if (Scrollnumber == 1)
            {
                DrawShape(e.Graphics, Scrollnumber);
            }

        }
        private void DrawShape(Graphics g, int number)

        {
            if (number == 1)
            {

                newZ[0] = RotateX(Pitch, Yaw, Roll, x[0], y[0], z[0], ref newX[0], ref newY[0]);
                newZ[1] = RotateX(Pitch, Yaw, Roll, x[1], y[1], z[1], ref newX[1], ref newY[1]);
                newZ[2] = RotateX(Pitch, Yaw, Roll, x[2], y[2], z[2], ref newX[2], ref newY[2]);
                points[0] = new PointF((float)newX[0], (float)newY[0]);
                points[1] = new PointF((float)newX[1], (float)newY[1]);
                points[2] = new PointF((float)newX[2], (float)newY[2]);
                g.DrawPolygon(new Pen(Color.Red, 3), points);
                g.FillPolygon(new SolidBrush(Color.Blue), points);
            }



        }
    }
}
