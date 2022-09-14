using ManagerMicroservice.Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ManagerMicroservice.Repository
{
    public interface IManagerRepository
    {
        public Task<int> CreateExecutive(Executive executive);
        public List<Property> GetProperties();
        public List<Executive> GetAllExecutive();
        public List<Executive> GetAllExecutivesByLocality(string Locality);
        public List<Executive> GetExecutivesById(int ExecutiveId);
        //public Task<string> AssignExecutive(int CustomerId);
        public List<Customer> GetAllCustomers();
        public List<Customer> GetCusomtersById(int CustomerId);
    }
}
