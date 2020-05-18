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
    public partial class AddTerritories : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddTerritories()
        {
            InitializeComponent();
        }
        private void AddTerritories_Load(object sender, EventArgs e)
        {
            db.Territories.Load();
            dataGridView1.DataSource = db.Territories.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cat = new Territories() { TerritoryId = textBox1.Text, TerritoryDescription = textBox2.Text, RegionId = Int32.Parse(textBox3.Text) };
                var add = new AddingData();
                db.Region.Load();
                if (db.Territories.Any(x=>x.TerritoryId==cat.TerritoryId))
                {
                    MessageBox.Show("Istnieje terytorium o takim id", "błąd");
                }
                else if (db.Region.Any(x=>x.RegionId==cat.RegionId)==false)
                {
                    MessageBox.Show("Nie ma regionu o takim id", "błąd");
                }
                else
                {
                    add.AddTerritories(cat, db);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Zły format RegionId", "Błąd");
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
                MessageBox.Show("Zły format RegionId", "Błąd");
            }
        }
    }
}
