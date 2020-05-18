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
    public partial class AddRegion : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddRegion()
        {
            InitializeComponent();
        }

        private void AddRegion_Load(object sender, EventArgs e)
        {
            db.Region.Load();
            dataGridView1.DataSource = db.Region.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cat = new P4_Projekt.Models.Region() {RegionId=0, RegionDescription = textBox1.Text };
            var add = new AddingData();
            while (true)
            {
                if (db.Region.Any(x => x.RegionId == cat.RegionId))
                {
                    cat.RegionId++;
                }
                else
                {
                    add.AddRegion(cat, db);
                    textBox1.Text = "";
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
