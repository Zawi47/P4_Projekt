using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Primitives;
using P4_Projekt.Models;

namespace P4_Projekt
{
    public class AddingData
    {
        
        public void AddCategory(Categories cat,NorthwindContext db)
        {
           
            db.Categories.Add(cat);
            db.SaveChanges();
        }
        public void AddCustomerCustomerDemo(CustomerCustomerDemo cat, NorthwindContext db)
        {
           
            db.CustomerCustomerDemo.Add(cat);
            db.SaveChanges();
        }
        public void AddCustomerDemographics(CustomerDemographics cat, NorthwindContext db)
        {
           
            db.CustomerDemographics.Add(cat);
            db.SaveChanges();
        }
        public void AddCustomers(Customers cat, NorthwindContext db)
        {
           
            db.Customers.Add(cat);
            db.SaveChanges();
        }
        public void AddEmployees(Employees cat, NorthwindContext db)
        {
           
            db.Employees.Add(cat);
            db.SaveChanges();
        }
        public void AddEmployeeTerritories(EmployeeTerritories cat, NorthwindContext db)
        {
          
            db.EmployeeTerritories.Add(cat);
            db.SaveChanges();
        }
        public void AddOrderDetails(OrderDetails cat, NorthwindContext db)
        {
          
            db.OrderDetails.Add(cat);
            db.SaveChanges();
        }
        public void AddOrders(Orders cat, NorthwindContext db)
        {
           
            db.Orders.Add(cat);
            db.SaveChanges();
        }
        public void AddProducts(Products cat, NorthwindContext db)
        {
            
            db.Products.Add(cat);
            db.SaveChanges();
        }
        public void AddRegion(Region cat, NorthwindContext db)
        {
           
            db.Region.Add(cat);
            db.SaveChanges();
        }
        public void AddShippers(Shippers cat, NorthwindContext db)
        {
          
            db.Shippers.Add(cat);
            db.SaveChanges();
        }
        public void AddSuppliers(Suppliers cat, NorthwindContext db)
        {
           
            db.Suppliers.Add(cat);
            db.SaveChanges();
        }
        public void AddTerritories(Territories cat, NorthwindContext db)
        {
           
            db.Territories.Add(cat);
            db.SaveChanges();
        }
    }
}
