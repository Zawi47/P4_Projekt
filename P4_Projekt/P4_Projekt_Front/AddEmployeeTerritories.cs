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
    public partial class AddEmployeeTerritories : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddEmployeeTerritories()
        {
            InitializeComponent();
        }

        private void AddEmployeeTerritories_Load(object sender, EventArgs e)
        {
            db.EmployeeTerritories.Load();
            dataGridView1.DataSource = db.EmployeeTerritories.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cat = new EmployeeTerritories() { EmployeeId = Int32.Parse(textBox1.Text), TerritoryId = textBox2.Text };
                var add = new AddingData();
                db.Employees.Load();
                db.Territories.Load();
                if(db.EmployeeTerritories.Any(x=>x.EmployeeId==cat.EmployeeId&&x.TerritoryId==cat.TerritoryId))
                {
                    MessageBox.Show("Taki element już występuje", "Błąd");
                }
                else if(db.Employees.Any(x=>x.EmployeeId==cat.EmployeeId)==false)
                {
                    MessageBox.Show("Nie ma takiego pracownika", "Błąd");
                }
                else if(db.Territories.Any(x=>x.TerritoryId==cat.TerritoryId)==false)
                {
                    MessageBox.Show("Nie ma takiego terytorium", "Błąd");
                }
                else
                {
                    add.AddEmployeeTerritories(cat, db);
                    textBox1.Text = "";
                    textBox2.Text = "";

                }
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd danych", "Błąd");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }
    }
}
