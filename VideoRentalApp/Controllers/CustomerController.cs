using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private ApplicationDbContext _context;
        // private CustomerManager aCustomerManager;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
            //aCustomerManager = new CustomerManager();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customer
        public ViewResult Index()
        {
            //No Need to Pass model CUZ providing it With API
           // var Customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }


        public ActionResult New()
        {
            var membershipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                //need it to populate Id or Get ModalState Error for Id
                //Another Way is in The MovieController and MovieFormViewModel
                Customer = new Customer(),
                MemberShipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }


//        [HttpGet]
//        public ActionResult Save()
//        {
//            var memberships = _context.MemberShipTypes.ToList();
//            var viewModel = new CustomerFormViewModel
//            {
//                MemberShipTypes = memberships
//            };
//            return View("CustomerForm", viewModel);
//        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //[Bind(Exclude = "Id")] not gonna work for update
//            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
//                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));

                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }


            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Find(customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");

//            //ViewBag.Message = aCustomerManager.Save(customer);
//            var viewModel2 = new CustomerFormViewModel
//            {
//                MemberShipTypes = _context.MemberShipTypes.ToList()
//            };
//
//            ModelState.Clear();
//            return View("CustomerForm", viewModel2);


            // return RedirectToAction("Index","Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}