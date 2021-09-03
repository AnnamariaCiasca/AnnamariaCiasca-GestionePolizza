using GestionePolizza.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePolizza.Core.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<Customer> FetchByLife();
    }
}
