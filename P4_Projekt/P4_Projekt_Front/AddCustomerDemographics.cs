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
    public partial class AddCustomerDemographics : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddCustomerDemographics()
        {
            InitializeComponent();
        }

        private void AddCustomerDemographics_Load(object sender, EventArgs e)
        {
            db.CustomerDemographics.Load();
            dataGridView1.DataSource = db.CustomerDemographics.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cat = new CustomerDemographics() { CustomerTypeId = textBox1.Text, CustomerDesc = textBox2.Text };
            bool repeat = false;
            if(db.CustomerDemographics.Any(x=>x.CustomerTypeId==cat.CustomerTypeId))
            {
                repeat = true;
            }
            if(repeat==true)
            {
                MessageBox.Show("Powtórzone Id", "Błąd");
            }
            else
            {
                var add = new AddingData();
                add.AddCustomerDemographics(cat, db);
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }
    }
}
