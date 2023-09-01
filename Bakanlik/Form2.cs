using DevExpress.Xpo.DB.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bakanlik
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        bakanEntities conn=new bakanEntities();
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
            groupBox3.Location = new System.Drawing.Point(177, 160);
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
            groupBox1.Location = new System.Drawing.Point(177, 160);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            EmpLogin cgir = new EmpLogin();
            cgir.employeeUser = textBox1.Text;
            cgir.employeePassword = textBox2.Text;

            if (conn.cLogin(cgir.employeeUser, cgir.employeePassword).Any())
            {
                MessageBox.Show("Giriş başarılı");
                Form1 fgec=new Form1();
                fgec.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("giriş başarısız");
            }
        }
        public static int kNo;
        private void button2_Click(object sender, EventArgs e)
        {    vatandas kgir = new vatandas();
            kgir.KisiTelefon = textBox4.Text;
            kgir.kisiTC = textBox3.Text;

            var query = from user in conn.vatandas where user.KisiTelefon == textBox4.Text && user.kisiTC == textBox3.Text select user.kisiNo;

            if (query.Any())
            {
                kNo = query.First();
            }

            if (conn.kLogin(kgir.KisiTelefon,Convert.ToInt32(kgir.kisiTC)).Any())
            {
                MessageBox.Show("giriş başarılı");
                vatandas_page vgec= new vatandas_page();
                vgec.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("giriş başarısız");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vatandas emp = new vatandas();
            emp.kisiTC = textBox6.Text;
            emp.KisiMeslek = textBox5.Text;
            emp.KisiAdres = textBox7.Text;
            emp.KisiTelefon = maskedTextBox1.Text;
            emp.KisiMail = textBox9.Text;
            emp.vergiID = null;
            conn.vatandasAdd(emp.kisiTC, emp.KisiMeslek, emp.KisiAdres, emp.KisiTelefon, emp.KisiMail, emp.vergiID);
            conn.SaveChanges();
            MessageBox.Show("Kayıdınız oluşturuldu, Giriş yapabilirsiniz(K.ad=Tel no, Şifre=TC)");
        }
    }
}
