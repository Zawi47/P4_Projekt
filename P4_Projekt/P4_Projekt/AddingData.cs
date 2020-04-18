using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Primitives;
using P4_Projekt.Models;

namespace P4_Projekt
{
    public class AddingData
    {
        NorthwindContext db = new NorthwindContext();
        public void AddCategory(Categories cat)
        {
           
            db.Categories.Add(cat);
            db.SaveChanges();
        }
        public void AddCustomerCustomerDemo(CustomerCustomerDemo cat)
        {
           
            db.CustomerCustomerDemo.Add(cat);
            db.SaveChanges();
        }
        public void AddCustomerDemographics(CustomerDemographics cat)
        {
           
            db.CustomerDemographics.Add(cat);
            db.SaveChanges();
        }
        public void AddCustomers(Customers cat)
        {
           
            db.Customers.Add(cat);
            db.SaveChanges();
        }
        public void AddEmployees(Employees cat)
        {
           
            db.Employees.Add(cat);
            db.SaveChanges();
        }
        public void AddEmployeeTerritories(EmployeeTerritories cat)
        {
          
            db.EmployeeTerritories.Add(cat);
            db.SaveChanges();
        }
        public void AddOrderDetails(OrderDetails cat)
        {
          
            db.OrderDetails.Add(cat);
            db.SaveChanges();
        }
        public void AddOrders(Orders cat)
        {
           
            db.Orders.Add(cat);
            db.SaveChanges();
        }
        public void AddProducts(Products cat)
        {
            
            db.Products.Add(cat);
            db.SaveChanges();
        }
        public void AddRegion(Region cat)
        {
           
            db.Region.Add(cat);
            db.SaveChanges();
        }
        public void AddShippers(Shippers cat)
        {
          
            db.Shippers.Add(cat);
            db.SaveChanges();
        }
        public void AddSuppliers(Suppliers cat)
        {
           
            db.Suppliers.Add(cat);
            db.SaveChanges();
        }
        public void AddTerritories(Territories cat)
        {
           
            db.Territories.Add(cat);
            db.SaveChanges();
        }
    }
}
