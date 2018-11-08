using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using VideoRentalApp.Dtos;
using VideoRentalApp.Models;
using VideoRentalAPP.Models;

namespace VideoRentalApp.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers(string query = null) //null means its optional
        {
            var customersQuery = _context.Customers.Include(c => c.MemberShipType);

            //filtering the parameter
            if (!string.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customers = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customers);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto aCustomerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(aCustomerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            aCustomerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), aCustomerDto);
        }

        //PUT api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto aCustomerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.Find(id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            //<CustomerDto, Customer>
            Mapper.Map(aCustomerDto, customerInDb);
//            Using Mapper..so no need for manual mapping
//            customerInDb.Name = aCustomerDto.Name;
//            customerInDb.BirthDate = aCustomerDto.BirthDate;
//            customerInDb.MemberShipTypeId = aCustomerDto.MemberShipTypeId;
//            customerInDb.IsSubscribedToNewsLetter = aCustomerDto.IsSubscribedToNewsLetter;

            _context.SaveChanges();

            return Ok();
        }

        //DELETE api/Customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.Find(id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}