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
    public partial class AddShippers : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddShippers()
        {
            InitializeComponent();
        }

        private void AddShippers_Load(object sender, EventArgs e)
        {
            db.Shippers.Load();
            dataGridView1.DataSource = db.Shippers.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cat = new Shippers() { ShipperId=0,CompanyName = textBox1.Text, Phone = textBox2.Text };
            var add = new AddingData();
            while(true)
            {
                if(db.Shippers.Any(x=>x.ShipperId==cat.ShipperId))
                {
                    cat.ShipperId++;
                }
                else
                {
                    add.AddShippers(cat, db);
                    textBox1.Text = "";
                    textBox2.Text = "";
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
