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
    public partial class AddEmployees : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddEmployees()
        {
            InitializeComponent();
        }

        private void AddEmployees_Load(object sender, EventArgs e)
        {
            db.Employees.Load();
            dataGridView1.DataSource = db.Employees.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                var cat = new Employees() { EmployeeId=0,LastName = textBox1.Text, FirstName = textBox2.Text, Title = textBox3.Text, TitleOfCourtesy = textBox4.Text, BirthDate = Convert.ToDateTime(textBox5.Text), HireDate = Convert.ToDateTime(textBox6.Text), Address = textBox7.Text, City = textBox8.Text, Region = textBox9.Text, PostalCode = textBox10.Text, Country = textBox11.Text, HomePhone = textBox12.Text, Extension = textBox13.Text, Notes = textBox14.Text, ReportsTo = Int32.Parse(textBox15.Text) };
                if (cat.ReportsTo is null || db.Employees.Any(x => x.EmployeeId == cat.ReportsTo))
                {
                    while(true)
                    {
                        if (db.Employees.Any(x=>x.EmployeeId==cat.EmployeeId))
                        {
                            cat.EmployeeId++;
                        }
                        else
                        {
                            var add = new AddingData();
                            add.AddEmployees(cat, db);
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
                            textBox14.Text = "";
                            textBox15.Text = "";
                            break;
                        }
                    }
                    
                }
                else MessageBox.Show("Niepoprawna pozycja ReportsTo", "Błąd");
            }
            catch(Exception)
            {
                MessageBox.Show("Niepoprawna forma danych", "Błąd");
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
                MessageBox.Show("Błąd");
            }
        }
    }
}
