using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bakanlik
{
    public partial class vatandas_page : Form
    {
        public vatandas_page()
        {
            InitializeComponent();
        }
        bakanEntities3 conn = new bakanEntities3();
        private void button1_Click(object sender, EventArgs e)
        {
            var query = from user in conn.vatandas where user.kisiNo==Form2.kNo select user;
            dataGridView2.DataSource = query.ToList();
        }

        private void vatandas_page_Load(object sender, EventArgs e)
        {
            var query = from user in conn.vatandas where user.kisiNo == Form2.kNo select user;
            if (query.Any())
            {
                foreach (var item in query)
                {
                    textBox6.Text = item.kisiNo.ToString();
                    textBox10.Text = item.kisiTC.ToString();
                    textBox9.Text = item.KisiMeslek.ToString();
                    textBox8.Text = item.KisiAdres.ToString();
                    textBox7.Text = item.KisiTelefon.ToString();
                    textBox11.Text = item.KisiMail.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int verID=0;
            var query = from user in conn.vatandas where user.kisiNo == Form2.kNo select user;
            if (query.Any())
            {
                foreach (var item in query)
                {
                    verID =Convert.ToInt32(item.vergiID);
                }
            }
            vatandas emp = new vatandas();
            emp.kisiNo = int.Parse(textBox6.Text);
            emp.kisiTC = textBox10.Text;
            emp.KisiMeslek = textBox9.Text;
            emp.KisiAdres = textBox8.Text;
            emp.KisiTelefon = textBox7.Text;
            emp.KisiMail = textBox11.Text;
            emp.vergiID = Convert.ToInt32(verID);
            object value = conn.vatandasUpdate(emp.kisiNo, emp.kisiTC, emp.KisiMeslek, emp.KisiAdres, emp.KisiTelefon, emp.KisiMail, emp.vergiID);
            conn.SaveChanges();
            dataGridView2.DataSource = query.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 gec = new Form2();
            gec.Show();
            this.Hide();
            Form2.kNo = 0;
        }
    }
}
