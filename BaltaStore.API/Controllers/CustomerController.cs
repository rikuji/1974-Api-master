using BaltaStore.Domain.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaltaStore.API.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("Lucas", "Valenzuela");
            var document = new Document("03379401188");
            var email = new Email("lucasbezerra@gmail.com");
            var customer = new Customer(name, document, email, "5561993537517");
            var customers = new List<Customer>();

            customers.Add(customer);

            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("Lucas", "Valenzuela");
            var document = new Document("03379401188");
            var email = new Email("lucasbezerra@gmail.com");
            var customer = new Customer(name, document, email, "5561993537517");

            return customer;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            var name = new Name("Lucas", "Valenzuela");
            var document = new Document("03379401188");
            var email = new Email("lucasbezerra@gmail.com");
            var customer = new Customer(name, document, email, "5561993537517");
            var order = new Order(customer);

            var mouse = new Product("Mouse", "Mouse", "Mouse.jpg", 100M, 10);
            var monitor = new Product("Monitor", "Monitor", "Monitor.jpg", 100M, 10);

            order.AddItem(monitor, 5);
            order.AddItem(mouse, 5);

            var orders = new List<Order>();
            orders.Add(order);

            return orders;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpPut]
        [Route("customers")]
        public Customer Put([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete([FromBody]Customer customer)
        {
            return new { message = "Cliente removido com sucesso" };
        }
    }
}
