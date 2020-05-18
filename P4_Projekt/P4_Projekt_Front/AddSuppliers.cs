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
    public partial class AddSuppliers : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddSuppliers()
        {
            InitializeComponent();
        }

        private void AddSuppliers_Load(object sender, EventArgs e)
        {
            db.Suppliers.Load();
            dataGridView1.DataSource = db.Suppliers.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cat = new Suppliers() {SupplierId=0, CompanyName = textBox1.Text, ContactName = textBox2.Text, ContactTitle = textBox3.Text, Address = textBox4.Text, City = textBox5.Text, Region = textBox6.Text, PostalCode = textBox7.Text, Country = textBox8.Text, Phone = textBox9.Text, Fax = textBox10.Text };
            var add = new AddingData();
            while(true)
            {
                if(db.Suppliers.Any(x=>x.SupplierId==cat.SupplierId))
                {
                    cat.SupplierId++;
                }
                else
                {
                    add.AddSuppliers(cat, db);
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
                    break;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }
    }
}
