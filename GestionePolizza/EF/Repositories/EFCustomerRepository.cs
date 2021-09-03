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
   public class EFCustomerRepository: ICustomerRepository
    {
        private readonly PolicyContext ctx;
        public EFCustomerRepository()
        {
            ctx = new PolicyContext();
        }

    


        public bool Add(Customer customer)
        {
            if (customer == null)
                return false;

            try
            {
                ctx.Customers.Add(new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Code = customer.Code,
                    
                });

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Customer customerToDelete)
        {
            if (customerToDelete == null)
                return false;

            try
            {
                var customer = ctx.Customers.Find(customerToDelete.Id);

                if (customer != null)
                    ctx.Customers.Remove(customer);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Customer> Fetch()
        {
            try
            {
                var customers = ctx.Customers.ToList();
                return customers;
            }
            catch (Exception)
            {
                return new List<Customer>();
            }
        }

        public Customer GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Customers.Find(id);
        }


        public bool Update(Customer CustomerToUpdate)
        {
            if (CustomerToUpdate == null)
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

        public List<Customer> FetchByLife()
        {     
        

        PolicyTypeEnum pt = PolicyTypeEnum.Vita;
            try
            {
                //var costum = from c in ctx.Customers
                //             join Policies p on c.Id = p.CustomerId
                //             where p.PolicyType == pt;

                //return costum;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}