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
    public partial class AddOrders : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddOrders()
        {
            InitializeComponent();
        }

        private void AddOrders_Load(object sender, EventArgs e)
        {
            db.Orders.Load();
            dataGridView1.DataSource = db.Orders.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cat = new Orders() { OrderId = 10248, CustomerId = textBox1.Text, EmployeeId = Int32.Parse(textBox2.Text), OrderDate = Convert.ToDateTime(textBox3.Text), RequiredDate = Convert.ToDateTime(textBox4.Text), ShippedDate = Convert.ToDateTime(textBox5.Text), ShipVia = Int32.Parse(textBox6.Text), Freight = Decimal.Parse(textBox7.Text), ShipName = textBox8.Text, ShipAddress = textBox9.Text, ShipCity = textBox10.Text, ShipRegion = textBox11.Text, ShipPostalCode = textBox12.Text, ShipCountry = textBox13.Text };
                var add = new AddingData();
                db.Customers.Load();
                db.Employees.Load();
                if(db.Customers.Any(x=>x.CustomerId==cat.CustomerId)==false)
                {
                    MessageBox.Show("Nie ma takiego klienta", "Błąd");
                }
                else if(db.Employees.Any(x=>x.EmployeeId==cat.EmployeeId)==false)
                {
                    MessageBox.Show("Nie ma takiego pracownika", "Błąd");
                }
                else
                {
                    while(true)
                    {
                        if(db.Orders.Any(x=>x.OrderId==cat.OrderId))
                        {
                            cat.OrderId++;
                        }
                        else
                        {
                            add.AddOrders(cat, db);
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
                            textBox11.Text = "";
                            textBox12.Text = "";
                            textBox13.Text = "";
                            break;
                        }
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Zły format danych", "Błąd");
              
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
                MessageBox.Show("Zły format danych", "Błąd");
            }
        }
    }
}
