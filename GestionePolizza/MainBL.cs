using GestionePolizza.Core.Interfaces;
using GestionePolizza.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePolizza
{
   public class MainBL
    {
        private ICustomerRepository customRep;
        private IPolicyRepository policyRep;
        public MainBL(ICustomerRepository customerRepository, IPolicyRepository policyRepository)
        {
            customRep = customerRepository;
            policyRep = policyRepository;
        }

        internal bool AddPolicy(InsurancePolicy newPolicy)
        {
          
            if (newPolicy == null) throw new ArgumentNullException();

            bool isAdded = policyRep.Add(newPolicy);
            return isAdded; 
        }

        internal List<Customer> FetchCustomers()
        {
            try
            {
                return customRep.Fetch();
            }
            catch
            {
                return null;
            }
        }

        internal bool AddCustomer(Customer newCustomer)
        {

            if (newCustomer == null) throw new ArgumentNullException();

            bool isAdded = customRep.Add(newCustomer);
            return isAdded;
        }

        internal List<InsurancePolicy> ShowCustomerPolicy(Customer chosenCustomer)
        {
            if (chosenCustomer == null) throw new ArgumentNullException();

            return policyRep.FetchByCustomerId(chosenCustomer.Id);
        }

        internal InsurancePolicy GetByNumber(int numero)
        {
            if (numero == 0) throw new ArgumentNullException();

            var policy = policyRep.GetByNumber(numero);
            return policy;
        }

        internal void UpdatePolicy(InsurancePolicy policyToUpdate)
        {
            if (policyToUpdate == null) throw new ArgumentNullException();

            policyRep.Update(policyToUpdate);
        }

        //internal static List<InsurancePolicy> GetByType(PolicyTypeEnum type)
        //{
        
        //}



    }
}
