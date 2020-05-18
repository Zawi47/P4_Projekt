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

namespace P4_Projekt_Front
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            var add = new AddCategories();
            add.ShowDialog();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            var add = new AddCustomers();
            add.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var add = new AddCustomerDemo();
            add.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var add = new AddCustomerDemographics();
            add.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var add = new AddEmployees();
            add.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var add = new AddSuppliers();
            add.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var add = new AddShippers();
            add.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var add = new AddRegion();
            add.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var add = new AddTerritories();
            add.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var add = new AddEmployeeTerritories();
            add.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var add = new AddProducts();
            add.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var add = new AddOrders();
            add.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var add = new AddOrderDetails();
            add.ShowDialog();
        }
    }
}
