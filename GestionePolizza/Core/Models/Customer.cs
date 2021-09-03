using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePolizza.Core.Models
{
    public class Customer
    {   
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }
      
        [Column(TypeName = "varchar(16)")]
        public string Code { get; set; }

        public List<InsurancePolicy> Policies = new List<InsurancePolicy>();

    

    }
}
