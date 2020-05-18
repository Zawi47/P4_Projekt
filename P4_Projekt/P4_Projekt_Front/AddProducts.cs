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
    public partial class AddProducts : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddProducts()
        {
            InitializeComponent();
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {
            db.Products.Load();
            dataGridView1.DataSource = db.Products.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cat = new Products() { ProductId = 0, ProductName = textBox1.Text, SupplierId = Int32.Parse(textBox2.Text), CategoryId = Int32.Parse(textBox3.Text), QuantityPerUnit = textBox4.Text, UnitPrice = Decimal.Parse(textBox5.Text), UnitsInStock = Int16.Parse(textBox6.Text), UnitsOnOrder = Int16.Parse(textBox7.Text), ReorderLevel = Int16.Parse(textBox8.Text), Discontinued = Boolean.Parse(textBox9.Text) };
                var add = new AddingData();
                db.Suppliers.Load();
                db.Categories.Load();
                if (db.Suppliers.Any(x => x.SupplierId == cat.SupplierId) == false)
                {
                    MessageBox.Show("Nie ma takiego dostawcy", "Błąd");
                }
                else if (db.Categories.Any(x=>x.CategoryId==cat.CategoryId)==false)
                {
                    MessageBox.Show("Nie ma takiej kategorii", "Błąd");
                }
                else
                {
                    while(true)
                    {
                        if(db.Products.Any(x=>x.ProductId==cat.ProductId))
                        {
                            cat.ProductId++;
                        }
                        else
                        {
                            add.AddProducts(cat, db);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";
                            textBox7.Text = "";
                            textBox8.Text = "";
                            textBox9.Text = "";
                            break;
                        }
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd formatu danych", "Błąd");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd formatu danych", "Błąd");
            }
        }
    }
}
