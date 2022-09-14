using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerMicroservice.Model
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int PropertyId { get; set; }
            public string PropertyType { get; set; }
            public int Budget { get; set; }
            public string Locality { get; set; }
    }
}

