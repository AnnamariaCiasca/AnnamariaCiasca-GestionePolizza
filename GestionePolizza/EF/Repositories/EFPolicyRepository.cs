using GestionePolizza.Core.Interfaces;
using GestionePolizza.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePolizza.EF.Repositories
{
    public class EFPolicyRepository : IPolicyRepository
    {
        private readonly PolicyContext ctx;


        public EFPolicyRepository()
        {
            ctx = new PolicyContext();
        }

        public bool Add(InsurancePolicy newPolicy)
        {
            if (newPolicy == null)
                return false;

            try
            {
                ctx.Policies.Add(new InsurancePolicy
                {
                    Number = newPolicy.Number,
                    ExpirationDate = newPolicy.ExpirationDate,
                    MonthlyRate = newPolicy.MonthlyRate,
                    PolicyType = newPolicy.PolicyType,
                    //Customer = newPolicy.Customer,
                    CustomerId = newPolicy.CustomerId
                });

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<InsurancePolicy> FetchByCustomerId(int id)
        {
            if (id == 0)
                return null;

            try
            {
                var policies = ctx.Policies.Include(p => p.Customer)
                   .Where(p => p.Customer.Id == id).ToList();

                return policies;
            }
            catch (Exception)
            {
                return null;
            }
        }




        public bool Delete(InsurancePolicy item)
        {
            throw new NotImplementedException();
        }

        public List<InsurancePolicy> Fetch()
        {
            try
            {
                var categorie = ctx.Policies
                    .ToList();
                return categorie;
            }
            catch (Exception)
            {
                return new List<InsurancePolicy>();
            }
        }

        public InsurancePolicy GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(InsurancePolicy updatedPolicy)
        {
            if (updatedPolicy == null)
                return false;

            try
            {
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public InsurancePolicy GetByNumber(int numero)
        {
            if (numero == 0)
                return null;

            try
            {
                var policy = ctx.Policies.Where(p => p.Number == numero).FirstOrDefault();

                return policy;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<InsurancePolicy> GetByType(PolicyTypeEnum type)
        {
            return ctx.Policies.Where(p => p.PolicyType == type).Include(p => p.Customer).ToList();
        }
    }
}
