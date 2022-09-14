using ManagerMicroservice.Model;
using ManagerMicroservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading.Tasks;

namespace ManagerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private IManagerRepository _managerRepository;

        public ManagerController(IManagerRepository executiveRepository)
        {
            _managerRepository = executiveRepository;
        }

        [HttpPost]
        [Route("CreateExecutive")]
        public async Task<IActionResult> createExecutive([FromBody] Executive ExecutiveData)
        {
            int Executiveid = await _managerRepository.CreateExecutive(ExecutiveData);
            return Ok(Executiveid);
        }

        [HttpPost]
        [Route("Createproperties")]
        public async Task<IActionResult> createProperties([FromBody] Property PropertiesData)
        {
            int PropertyId = await _managerRepository.CreateProperties(PropertiesData);
            return Ok(PropertyId);
        }

        [HttpGet]
        [Route("GetAllExecutive")]
        public IActionResult getAllExecutives()
        {
            var executives = _managerRepository.GetAllExecutive();
            return Ok(executives);
        }

        [HttpGet]
        [Route("GetExecutiveByLocality")]
        public IActionResult getAllExecutivesByLocality(string Locality)
        {
            var executives = _managerRepository.GetAllExecutivesByLocality(Locality);
            return Ok(executives);
        }

        [HttpGet]
        [Route("GetExecutiveById")]
        public IActionResult getExecutivesById(int ExecutiveId)
        {
            var executives = _managerRepository.GetExecutivesById(ExecutiveId);
            return Ok(executives);
        }

        //[HttpPut]
        //[Route("AssignExecutive")]
        //public async Task<IActionResult> AssignExecutive([FromBody] CustomerExecutive assignExecutiveModel)
        //{
        //    string msg = await _managerRepository.AssignExecutive(assignExecutiveModel);
        //    return Ok(msg);
        //}

        [HttpGet]
        [Route("GetAllCustomer")]
        public List<Customer> getProperties()
        {
            List<Customer> record = new List<Customer>();
            record = _managerRepository.GetAllCustomers();
            return record;
        }

        [HttpGet]
        [Route("GetCustomersById")]
        public IActionResult getCustomersById(int CustomerId)
        {
            var record = _managerRepository.GetCusomtersById(CustomerId);
            return Ok(record);
        }

        [HttpGet]
        [Route("GetAllProperties")]
        public List<Property> getAllProperties()
        {
            List<Property> record = new List<Property>();
            record = _managerRepository.GetProperties();
            return record;
        }
    }
}
