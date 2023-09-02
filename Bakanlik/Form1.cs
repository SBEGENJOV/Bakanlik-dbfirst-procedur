using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bakanlik
{
    public partial class Form1 : Form
    {
        bakanEntities conn=new bakanEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.bakanList().ToList();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            bakanlik emp = new bakanlik();
            emp.bakanlikID = int.Parse(textBox1.Text);
            conn.bakanDelete(emp.bakanlikID);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.bakanList().ToList();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            bakanlik emp = new bakanlik();
            emp.bakanlikAdi = textBox1.Text;
            emp.daireBaskani = textBox2.Text;
            emp.bakanlikCiro = int.Parse(textBox3.Text);
            emp.BakanlikMerkez = textBox4.Text;
            conn.bakanAdd(emp.bakanlikAdi, emp.daireBaskani, emp.bakanlikCiro, emp.BakanlikMerkez);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.bakanList().ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            bakanlik emp = new bakanlik();
            emp.bakanlikID = int.Parse(textBox5.Text);
            emp.bakanlikAdi = textBox1.Text;
            emp.daireBaskani = textBox2.Text;
            emp.bakanlikCiro = int.Parse(textBox3.Text);
            emp.BakanlikMerkez = textBox4.Text;
            conn.bakanUpdate(emp.bakanlikID,emp.bakanlikAdi, emp.daireBaskani, emp.bakanlikCiro, emp.BakanlikMerkez);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.bakanList().ToList();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = conn.vatandasList().ToList();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            vatandas emp = new vatandas();
            emp.kisiNo = int.Parse(textBox6.Text);
            conn.vatandasDelete(emp.kisiNo);
            conn.SaveChanges();
            dataGridView2.DataSource = conn.vatandasList().ToList();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            vatandas emp = new vatandas();
            emp.kisiTC = textBox10.Text;
            emp.KisiMeslek = textBox9.Text;
            emp.KisiAdres = textBox8.Text;
            emp.KisiTelefon = textBox7.Text;
            emp.KisiMail = textBox11.Text;
            emp.vergiID = int.Parse(textBox12.Text);
            conn.vatandasAdd(emp.kisiTC, emp.KisiMeslek, emp.KisiAdres, emp.KisiTelefon, emp.KisiMail, emp.vergiID);
            conn.SaveChanges();
            dataGridView2.DataSource = conn.vatandasList().ToList();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            vatandas emp = new vatandas();
            emp.kisiNo = int.Parse(textBox6.Text);
            emp.kisiTC = textBox10.Text;
            emp.KisiMeslek = textBox9.Text;
            emp.KisiAdres = textBox8.Text;
            emp.KisiTelefon = textBox7.Text;
            emp.KisiMail = textBox11.Text;
            emp.vergiID = int.Parse(textBox12.Text);
            conn.vatandasUpdate(emp.kisiNo,emp.kisiTC, emp.KisiMeslek, emp.KisiAdres, emp.KisiTelefon, emp.KisiMail, emp.vergiID);
            conn.SaveChanges();
            dataGridView2.DataSource = conn.vatandasList().ToList();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource=conn.vergilerList().ToList();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            vergiler emp = new vergiler();
            emp.vergiID = int.Parse(textBox15.Text);
            conn.vergiDelete(emp.vergiID);
            conn.SaveChanges();
            dataGridView3.DataSource = conn.vergilerList().ToList();
        }

        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            vergiler emp = new vergiler();
            emp.vergiAdi =textBox19.Text;
            emp.vergiTipi = textBox18.Text;
            emp.vergiTutar = int.Parse(textBox17.Text);
            emp.vergiFaiz = int.Parse(textBox16.Text);
            emp.bakanlikID = int.Parse(textBox14.Text);
            conn.vergilerAdd(emp.vergiAdi, emp.vergiTipi, emp.vergiTutar, emp.vergiFaiz, emp.bakanlikID);
            conn.SaveChanges();
            dataGridView3.DataSource = conn.vergilerList().ToList();
        }
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            vergiler emp = new vergiler();
            emp.vergiID = int.Parse(textBox15.Text);
            emp.vergiAdi = textBox19.Text;
            emp.vergiTipi = textBox18.Text;
            emp.vergiTutar = int.Parse(textBox17.Text);
            emp.vergiFaiz = int.Parse(textBox16.Text);
            emp.bakanlikID = int.Parse(textBox14.Text);
            conn.vergilerUpdate(emp.vergiID,emp.vergiAdi, emp.vergiTipi, emp.vergiTutar, emp.vergiFaiz, emp.bakanlikID);
            conn.SaveChanges();
            dataGridView3.DataSource = conn.vergilerList().ToList();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=bakan;Integrated Security=true;");
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("bakanList", con);
            adp.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("bakanlikAdi LIKE '%{0}%'", textBox13.Text);
            dataGridView4.DataSource = dv;
        }

        private void textBox13_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource=conn.bakanList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                dataGridView4.DataSource = conn.bmaxciro().ToList();
            }
            else if (comboBox1.SelectedIndex==1)
            {
                dataGridView4.DataSource = conn.bminciro().ToList();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dataGridView4.DataSource = conn.bavgciro().ToList();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                dataGridView4.DataSource = conn.bsumciro().ToList();
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                dataGridView4.DataSource = conn.bmersay().ToList();
            }
             else if (comboBox1.SelectedIndex == 5)
            {
                dataGridView4.DataSource = conn.bakver().ToList();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                dataGridView4.DataSource = conn.vmax().ToList();
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                dataGridView4.DataSource = conn.vmin().ToList();
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                dataGridView4.DataSource = conn.vsum().ToList();
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                dataGridView4.DataSource = conn.vavg().ToList();
            }
            else if (comboBox2.SelectedIndex == 4)
            {
                dataGridView4.DataSource = conn.vfmax().ToList();
            }
            else if (comboBox2.SelectedIndex == 5)
            {
                dataGridView4.DataSource = conn.vfmin().ToList();
            }
            else if (comboBox2.SelectedIndex == 6)
            {
                dataGridView4.DataSource = conn.vfsum().ToList();
            }
            else if (comboBox2.SelectedIndex == 7)
            {
                dataGridView4.DataSource = conn.vfavg().ToList();
            }
            else if (comboBox2.SelectedIndex == 8)
            {
                dataGridView4.DataSource = conn.vb().ToList();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                dataGridView4.DataSource = conn.vmes().ToList();
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                dataGridView4.DataSource = conn.vil().ToList();
            }
            else if (comboBox3.SelectedIndex == 2)
            {
                dataGridView4.DataSource = conn.vwv().ToList();
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("vergilerList", con);
            adp.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("vergiAdi LIKE '%{0}%'", textBox20.Text);
            dataGridView4.DataSource = dv;
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("vatandasList", con);
            adp.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("kisiTC LIKE '%{0}%'", textBox21.Text);
            dataGridView4.DataSource = dv;
        }

        private void textBox20_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = conn.vergilerList();
        }

        private void textBox21_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = conn.vatandasList();
        }
    }
}
