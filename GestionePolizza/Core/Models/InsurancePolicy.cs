using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePolizza.Core.Models
{
    public class InsurancePolicy
    {   
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal MonthlyRate { get; set; }

        public PolicyTypeEnum PolicyType { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


       
    }

    public enum PolicyTypeEnum
    {
        RCAuto = 1,
        Furto = 2,
        Vita = 3
    }
}
