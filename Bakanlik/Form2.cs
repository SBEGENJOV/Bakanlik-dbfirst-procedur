using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakanlik
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        bakanEntities con=new bakanEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource=con.vv(1).ToList();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox1.Location = new System.Drawing.Point(177, 160);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox2.Location = new System.Drawing.Point(177, 160);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox3.Location = new System.Drawing.Point(177, 160);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
