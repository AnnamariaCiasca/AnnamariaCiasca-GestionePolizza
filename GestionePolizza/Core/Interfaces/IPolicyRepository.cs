using GestionePolizza.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePolizza.Core.Interfaces
{
    public interface IPolicyRepository : IRepository<InsurancePolicy>
    {
        List<InsurancePolicy> FetchByCustomerId(int id);
        InsurancePolicy GetByNumber(int numero);

        List<InsurancePolicy> GetByType(PolicyTypeEnum type);


    }
}