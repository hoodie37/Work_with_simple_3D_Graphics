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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            {
               
            }

        }

        
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zadanie_12 zadanie_12 = new Zadanie_12();
            zadanie_12.Show();
        }

       

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Zadanie_13 zadanie_13 = new Zadanie_13();
            zadanie_13.Show();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Zadanie_14 zadanie_14 = new Zadanie_14();
            zadanie_14.Show();

        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Zadanie_15 zadanie_15 = new Zadanie_15();
            zadanie_15.Show();

        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Zadanie_16 zadanie_16 = new Zadanie_16();
            zadanie_16.Show();
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Zadanie_18 zadanie_18 = new Zadanie_18();
            zadanie_18.Show();
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Zadanie_17 zadanie_17 = new Zadanie_17();
            zadanie_17.Show();
        }
    }
}
