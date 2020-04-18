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

namespace P4_Projekt_Front
{
    public partial class AddCategories : Form
    {
        public AddCategories()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cat = new Categories(){ CategoryName = categoryName.Text, Description = description.Text };
            var add = new AddingData();
            add.AddCategory(cat);
            this.Close();
        }
    }
}
