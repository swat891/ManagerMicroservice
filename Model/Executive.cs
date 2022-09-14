using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerMicroservice
{
    public class Executive
    {
        [Key]
        public int ExecutiveId { get; set; }
        public string Name { get; set; }
        public string Contact_Number { get; set; }
        public string Locality { get; set; }
        public string EmailId { get; set; }
    }
}