using GestionePolizza.Core.Interfaces;
using GestionePolizza.Core.Models;
using GestionePolizza.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePolizza.Client
{
    public class Menu
    {
        private static MainBL mainBL = new MainBL(new EFCustomerRepository(), new EFPolicyRepository());



        internal static void Start()
        {
           

            char choice;

            do
            {
                Console.WriteLine("Premi 1 per inserire un nuovo cliente");   //ok
                Console.WriteLine("Premi 2 per inserire una polizza per un cliente");   //ok
                Console.WriteLine("Premi 3 per visualizzare le polizze di un cliente"); //ok
                Console.WriteLine("Premi 4 per posticipare data di scadenza"); //ok
                Console.WriteLine("Premi 5 per visualizzare i clienti che hanno una polizza vita"); // non terminato

                Console.WriteLine("Premi Q per uscire");

                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':

                        AddNewCustomer();
                        Console.WriteLine();
                        break;
                    case '2':
                        AddNewPolicy();
                        break;
                    case '3':
                        ShowCustomerPolicy();
                        Console.WriteLine();
                        break;
                    case '4':
                        UpdateDate();
                        Console.WriteLine();
                        break;
                    case '5':
                        ShowByCustomersLife();
                        Console.WriteLine();
                        break;
                
                    case 'Q':
                        return;
                    default:
                        Console.WriteLine("Scelta non disponibile");
                        break;
                }
            }
            while (!(choice == 'Q'));
        }

        private static void ShowByCustomersLife()
        {
            PolicyTypeEnum type = PolicyTypeEnum.Vita;

            
        }

        private static void UpdateDate()
        {

            int numero;
            DateTime expirationDate;

            Console.WriteLine("\nScegli il cliente che possiede la polizza di cui vuoi modificare la data, dopodiché digita il numero della polizza che vuoi modificare");
            ShowCustomerPolicy();

            Console.Write("Inserisci il numero della polizza:");

            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Inserisci un valore corretto!");
            }


            var policyToUpdate = GetPolicyByNumber(numero);

            if (policyToUpdate != null)
            {
                Console.WriteLine("Inserisci la nuova data di scadenza (dd/mm/yyyy)");

                while (!DateTime.TryParse(Console.ReadLine(), out expirationDate) || expirationDate < DateTime.Now)
                {
                    Console.WriteLine("Devi inserire una data, posteriore o uguale a oggi!");
                }

                policyToUpdate.ExpirationDate = expirationDate;
                mainBL.UpdatePolicy(policyToUpdate);
            }
            else
            {
                Console.WriteLine("Non c'è una polizza con questo numero");
            }
        }

        private static InsurancePolicy GetPolicyByNumber(int numero)
        {
            var policy = mainBL.GetByNumber(numero);

            return policy;
        }

        private static void ShowCustomerPolicy()
        {
            Console.WriteLine("\n Di quale cliente vuoi visualizzare le polizze?");
            Customer chosenCustomer = null;
            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("Scegli il cliente");
                chosenCustomer = ChooseCustomer();
            }
            while (chosenCustomer == null);


            if (chosenCustomer != null)
            {
                var policies = mainBL.ShowCustomerPolicy(chosenCustomer);

                foreach (var p in policies)
                {
                    Console.WriteLine($"Numero: {p.Number}  -Data: {p.ExpirationDate.ToShortDateString()}  -Rata: {p.MonthlyRate} -Tipo: {p.PolicyType}");
                }
            }
            else
                Console.WriteLine("Non ci sono scaffali con questo codice");
        }

        private static void ShowCustomers()
        {
            throw new NotImplementedException();
        }

        private static void AddNewCustomer()
        {
            Console.WriteLine("\n");
            string firstName, lastName, code;

            Console.WriteLine("Inserisci il nome del cliente: ");
            firstName = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome del cliente: ");
            lastName = Console.ReadLine();

            do
            {
                Console.Write("Inserisci il codice fiscale di 16 caratteri:");
                code = Console.ReadLine();
            }
            while (code.Length != 16);


            Customer newCustomer = new Customer
            {
                Code = code,
                FirstName = firstName,
                LastName = lastName
            };


            bool isAdded = mainBL.AddCustomer(newCustomer);

            if (isAdded)
                Console.WriteLine("Cliente aggiunto con successo");
            else
                Console.WriteLine("Qualcosa è andato storto");


        }

        private static void AddNewPolicy()
        {
            int numero;
            decimal rata;
            DateTime expirationDate = new DateTime();
           

            Customer customer = null;
            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("Scegli il cliente");
                customer = ChooseCustomer();
            }
            while (customer == null);

        
         
            Console.WriteLine("Inserisci il numero di polizza");

            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Inserire un valore corretto");
            }

            Console.WriteLine("Che tipo di polizza vuoi inserire? ");
            Console.WriteLine("1. Per RC-AUTO ");
            Console.WriteLine("2. Per Furto");
            Console.WriteLine("3. Per Polizza vita");
            int tipoPolizza;
            while (!int.TryParse(Console.ReadLine(), out tipoPolizza) || tipoPolizza < 0 || tipoPolizza > 3)
            {
                Console.WriteLine("Inserire un valore corretto");
            }

            Console.WriteLine("Inserisci data di scadenza (dd/mm/yyyy)");
      
            while (!DateTime.TryParse(Console.ReadLine(), out expirationDate) || expirationDate < DateTime.Now)
            {
                Console.WriteLine("Devi inserire una data, posteriore o uguale a oggi!");
            }


            Console.WriteLine("Inserisci la rata mensile");
         
            while (!decimal.TryParse(Console.ReadLine(), out rata) || rata < 0)
            {
                Console.WriteLine("Inserire un valore corretto");
            }

            InsurancePolicy newPolicy = new InsurancePolicy
            {
                Number = numero,
                ExpirationDate = expirationDate,
                MonthlyRate = rata,
                PolicyType = (PolicyTypeEnum)tipoPolizza,
                Customer = customer,
                CustomerId = customer.Id
            };

         
            bool isAdded = mainBL.AddPolicy(newPolicy);

            if (isAdded)
                Console.WriteLine("Polizza aggiunta con successo");
            else
                Console.WriteLine("Qualcosa è andato storto");
        }

        private static Customer ChooseCustomer()
        {
            int scelta;
            int count = 1;

            List<Customer> customers = mainBL.FetchCustomers();
            foreach (var c in customers)
            {
                Console.WriteLine($"Premi {count} per scegliere il cliente {c.FirstName} {c.LastName}");
                count++;
            }

            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > customers.Count)
            {
                Console.WriteLine("\n Inserisci una scelta valida.");
            }

            return customers.ElementAt(scelta - 1);
        }
    }
}