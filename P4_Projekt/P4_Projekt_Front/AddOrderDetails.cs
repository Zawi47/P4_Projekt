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
    public partial class AddOrderDetails : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddOrderDetails()
        {
            InitializeComponent();
        }

        private void AddOrderDetails_Load(object sender, EventArgs e)
        {
            db.OrderDetails.Load();
            dataGridView1.DataSource = db.OrderDetails.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cat = new OrderDetails() { OrderId = Int32.Parse(textBox1.Text), ProductId = Int32.Parse(textBox2.Text), UnitPrice = Decimal.Parse(textBox3.Text), Quantity = Int16.Parse(textBox4.Text), Discount = Single.Parse(textBox5.Text) };
                var add = new AddingData();
                db.Orders.Load();
                db.Products.Load();
                if(db.Orders.Any(x=>x.OrderId==cat.OrderId)==false)
                {
                    MessageBox.Show("Nie ma takiego zamówienia", "Błąd");
                }
                else if (db.Products.Any(x=>x.ProductId==cat.ProductId)==false)
                {
                    MessageBox.Show("Nie ma takiego produktu", "Błąd");
                }
                else if(db.OrderDetails.Any(x=>x.OrderId==cat.OrderId&&x.ProductId==cat.ProductId))
                {
                    MessageBox.Show("Taki element już istnieje", "Błąd");
                }
                else
                {
                    add.AddOrderDetails(cat, db);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                 
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Zły format Danych", "Błąd");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Zły format Danych", "Błąd");
            }
        }
    }
}
