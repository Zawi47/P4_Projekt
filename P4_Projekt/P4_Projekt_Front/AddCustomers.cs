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
    public partial class AddCustomers : Form
    {
        public AddCustomers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customers cat = new Customers() { CompanyName = companyName.Text, Address = address.Text, Phone = phone.Text };
            char[] help = cat.CompanyName.ToCharArray();
            string help2 = "";
            for(int i=0;i<3;i++)
            {
                help2 += help[i];
            }
            cat.CustomerId = help2;
            AddingData add = new AddingData();
            add.AddCustomers(cat);
        }
    }
}
