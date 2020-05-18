using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P4_Projekt;
using P4_Projekt.Models;
using Microsoft.Extensions.Primitives;
using Microsoft.EntityFrameworkCore;

namespace P4_Projekt_Front
{
    public partial class AddCategories : Form
    {
        NorthwindContext db = new NorthwindContext();
        public AddCategories()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cat = new Categories(){ CategoryName = categoryName.Text, Description = description.Text,CategoryId=0 };
            var add = new AddingData();
            while (true)
            {
                if (db.Categories.Any(x=>x.CategoryId==cat.CategoryId))
                {
                    cat.CategoryId++;
                }
                else
                {
                    add.AddCategory(cat, db);
                    categoryName.Text = "";
                    description.Text = "";
                    break;
                }
            }
            
            dataGridView1.Refresh();
        }

        

        private void AddCategories_Load(object sender, EventArgs e)
        { 
            db.Categories.Load();
            dataGridView1.DataSource = db.Categories.Local.ToBindingList();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }
    }
}
