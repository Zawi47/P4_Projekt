using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using P4_Projekt;
using P4_Projekt.Models;

namespace P4_Projekt_Front
{
    public partial class AddCustomers : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddCustomers()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddCustomers_Load(object sender, EventArgs e)
        {
            db.Customers.Load();
            dataGridView1.DataSource = db.Customers.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cat = new Customers()
            {
                CompanyName = textBox1.Text,
                ContactName = textBox2.Text,
                ContactTitle = textBox3.Text,
                Address = textBox4.Text,
                City = textBox5.Text,
                Region = textBox6.Text,
                PostalCode = textBox7.Text,
                Country = textBox8.Text,
                Phone = textBox9.Text,
                Fax = textBox10.Text
            };
            if (cat.CompanyName.Length<5)
            {
                MessageBox.Show("Company Name musi mieć min. 5 znaków", "Błąd danych");
            }
            else
            {
                string id="";
                for (int i=0;i<5;i++)
                {
                    id += cat.CompanyName[i];
                }
                cat.CustomerId = id;
                var add = new AddingData();
                add.AddCustomers(cat, db);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }
    }
}
