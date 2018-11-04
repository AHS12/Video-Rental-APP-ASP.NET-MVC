using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApp.Managers;
using VideoRentalApp.Models;
using VideoRentalApp.ViewModels;
using VideoRentalAPP.Models;

namespace VideoRentalApp.Controllers
{
    public class CustomerController : Controller
    {
//        private ApplicationDbContext _context;
        private CustomerManager aCustomerManager;
       
        public CustomerController()
        {
//            _context = new ApplicationDbContext();
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

        [HttpGet]
        public ActionResult Save()
        {
            var memberships = aCustomerManager.GetAllMemberShipTypes();
            var viewModel = new CustomerFormViewModel
            {
                MemberShipTypes = memberships
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(CustomerFormViewModel formViewModel)
        {
            ViewBag.Message = aCustomerManager.Save(formViewModel.Customer);

            formViewModel.MemberShipTypes = aCustomerManager.GetAllMemberShipTypes();
            // return RedirectToAction("Index","Customer");
            
            return View("CustomerForm",formViewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = aCustomerManager.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MemberShipTypes = aCustomerManager.GetAllMemberShipTypes()
            };
            return View("CustomerForm",viewModel);
        }
    }
}