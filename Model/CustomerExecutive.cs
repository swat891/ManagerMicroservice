using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerMicroservice.Model
{
    public class CustomerExecutive
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ExecutiveId { get; set; }
    }
}
