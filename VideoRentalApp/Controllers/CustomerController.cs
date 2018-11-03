using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApp.Managers;

namespace VideoRentalApp.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerManager aCustomerManager;
       
        public CustomerController()
        {
            aCustomerManager = new CustomerManager();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var Customers = aCustomerManager.GetAllCustomerWithMemberShip();
            return View(Customers);
        }

        public ActionResult Details(int id)
        {
            var customer = aCustomerManager.GetCustomerDetailsById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}