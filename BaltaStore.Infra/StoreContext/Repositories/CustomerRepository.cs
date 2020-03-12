using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.DataContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaltaDataContext _context;

        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;
        }
        public bool CheckDocument(string document)
        {
            throw new NotImplementedException();
        }

        public bool CheckEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer custuomer)
        {
            throw new NotImplementedException();
        }
    }
}
