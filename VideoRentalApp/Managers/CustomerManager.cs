using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO.MemoryMappedFiles;
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

        public string Save(Customer aCustomer)
        {
            if (aCustomer.Id == 0)
            {

                _context.Customers.Add(aCustomer);
                return _context.SaveChanges() > 0 ? "Saved!" : "Failed!";
            }
            else
            {
                var customerInDb = _context.Customers.Find(aCustomer.Id);
                customerInDb.Name = aCustomer.Name;
                customerInDb.BirthDate = aCustomer.BirthDate;
                customerInDb.MemberShipTypeId = aCustomer.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsLetter = aCustomer.IsSubscribedToNewsLetter;

                return _context.SaveChanges() > 0 ? "Updated!" : "Failed!";
            }
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
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);
            return customer;
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            return customer;
        }

        public IEnumerable<MemberShipType> GetAllMemberShipTypes()
        {
            var memberships = _context.MemberShipTypes.ToList();
            return memberships;
        }
    }
}