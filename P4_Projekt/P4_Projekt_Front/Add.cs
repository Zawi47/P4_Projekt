using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P4_Projekt_Front
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCategories add = new AddCategories();
            this.Close();
            add.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var add = new AddCustomers();
            this.Close();
            add.ShowDialog();
            
        }
    }
}
