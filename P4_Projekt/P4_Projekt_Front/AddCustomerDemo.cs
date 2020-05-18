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
    public partial class AddCustomerDemo : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddCustomerDemo()
        {
            InitializeComponent();
        }

        private void AddCustomerDemo_Load(object sender, EventArgs e)
        {
            db.CustomerCustomerDemo.Load();
            dataGridView1.DataSource = db.CustomerCustomerDemo.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cat = new CustomerCustomerDemo() { CustomerId = textBox1.Text, CustomerTypeId = textBox2.Text };
            bool repeat = false;
            bool cust = false;
            bool demo = false;
            db.Customers.Load();
            db.CustomerDemographics.Load();
            if(db.Customers.Any(x=>x.CustomerId==cat.CustomerId))
            {
                cust = true;
            }
            if(db.CustomerDemographics.Any(x=>x.CustomerTypeId==cat.CustomerTypeId))
            {
                demo = true;
            }
            if(db.CustomerCustomerDemo.Any(x=>x.CustomerId==cat.CustomerId&&x.CustomerTypeId==cat.CustomerTypeId))
            {
                repeat = true;
            }
            if(repeat==false&&cust==true&&demo==true)
            {
                cat.Customer = db.Customers.First(x => x.CustomerId == cat.CustomerId);
                cat.CustomerType = db.CustomerDemographics.First(x => x.CustomerTypeId == cat.CustomerTypeId);
                var add = new AddingData();
                add.AddCustomerCustomerDemo(cat, db);
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Niepoprawne Dane", "błąd");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }
    }
}
