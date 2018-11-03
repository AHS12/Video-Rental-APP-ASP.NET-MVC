using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using VideoRentalApp.Models;
using VideoRentalAPP.Models;

namespace VideoRentalApp.Managers
{
    public class CustomerManager
    {
        private ApplicationDbContext _context;

        public CustomerManager()
        {
            _context = new ApplicationDbContext();
        }

        public List<Customer> GetAllCustomers()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }

        public List<Customer> GetAllCustomerWithMemberShip()
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return customers;
        }

        public Customer GetCustomerDetailsById(int id)
        {
            var customer = _context.Customers.Include(c=>c.MemberShipType).SingleOrDefault(c => c.Id == id);
            return customer;
        }

    }
}