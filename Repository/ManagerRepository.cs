using ManagerMicroservice.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManagerMicroservice.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private ManagerContext _dbcontext;

        public ManagerRepository(ManagerContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> CreateExecutive(Executive executive)
        {
            _dbcontext.Executives.Add(executive);
            await _dbcontext.SaveChangesAsync();
            return executive.ExecutiveId;
        }

        public List<Executive> GetAllExecutive()
        {
            var executives = _dbcontext.Executives.ToList<Executive>();
            return executives;
        }

        public List<Executive> GetAllExecutivesByLocality(string Locality)
        {
            var ExecutiveDetails = _dbcontext.Executives.Where(x => x.Locality == Locality).Select(x => new Executive()
            {
                ExecutiveId = x.ExecutiveId,
                Name = x.Name,
                Contact_Number = x.Contact_Number,
                Locality = x.Locality,
                EmailId = x.EmailId
            }).ToList();
            return ExecutiveDetails;
        }

        public List<Executive> GetExecutivesById(int ExecutiveId)
        {
            var ExecutiveDetails = _dbcontext.Executives.Where(x => x.ExecutiveId == ExecutiveId).Select(x => new Executive()
            {
                ExecutiveId = x.ExecutiveId,
                Name = x.Name,
                Contact_Number = x.Contact_Number,
                Locality = x.Locality,
                EmailId = x.EmailId
            }).ToList();
            return ExecutiveDetails;
        }

        public List<Customer> GetAllCustomers()
        {

            List<Customer> customer = new List<Customer>();
            using (var client = new HttpClient())
            {
                var res = client.GetAsync("https://localhost:44318/api/Customer/GetAllCustomer");
                var data = res.Result.Content.ReadAsStringAsync();
                customer = JsonConvert.DeserializeObject<List<Customer>>(data.Result);
            }
            return customer;
        }


        //public async Task<string> AssignExecutive(int CustomerId)
        //{
        //    _dbcontext.AssignExecutives.Add(assignExecutiveModel);
        //    await _dbcontext.SaveChangesAsync();
        //    return "Success";
        //}

     
        public List<Customer> GetCusomtersById(int customerId)
        {
            List<Customer> customer = new List<Customer>();

            using (var client = new HttpClient())
            {
                var res = client.GetAsync("https://localhost:44318/api/Customer/GetCustomerDetails/customerId?customerId=" + customerId);
                var data = res.Result.Content.ReadAsStringAsync();
                customer = JsonConvert.DeserializeObject<List<Customer>>(data.Result);
            }
            return customer;
        }

        public List<Property> GetProperties()
        {

            List<Property> p = new List<Property>();
            using (var client = new HttpClient())
            {
                var res = client.GetAsync("https://localhost:44385/api/Property/GetAllProperties");
                var data = res.Result.Content.ReadAsStringAsync();
                p = JsonConvert.DeserializeObject<List<Property>>(data.Result);
            }
            return p;
        }
    }
}