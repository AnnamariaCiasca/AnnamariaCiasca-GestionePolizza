using GestionePolizza.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePolizza.EF
{
    public class PolicyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InsurancePolicy> Policies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
		                                  Database=Assicurazione;
                                          Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>()
            //            .ToTable("Customer")
            //            .HasKey(c => c.Id);
            //modelBuilder.Entity<Customer>()
            //            .Property(c => c.Code).IsFixedLength().HasMaxLength(16).IsRequired();
            //modelBuilder.Entity<Customer>()
            //            .Property(c => c.FirstName).HasMaxLength(30).IsRequired();
            //modelBuilder.Entity<Customer>()
            //            .Property(c => c.LastName).HasMaxLength(20).IsRequired();


            //modelBuilder.Entity<InsurancePolicy>()
            //            .ToTable("Policy")
            //            .HasKey(p => p.Id);
            //modelBuilder.Entity<InsurancePolicy>()
            //            .Property(p => p.Number)
            //            .HasColumnType("int")
            //            .HasColumnName("Number")
            //            .IsRequired();
            //modelBuilder.Entity<InsurancePolicy>()
            //            .Property(p => p.ExpirationDate)
            //            .HasColumnType("datetime2")
            //            .HasColumnName("Date")
            //            .IsRequired();
            //modelBuilder.Entity<InsurancePolicy>()
            //            .Property(p => p.MonthlyRate)
            //            .HasColumnType("decimal")
            //            .IsRequired();
            //modelBuilder.Entity<InsurancePolicy>()
            //            .HasOne(p => p.Customer)
            //            .WithMany(c => c.Policies)
            //            .HasForeignKey(p => p.CustomerId);

            //modelBuilder.Entity<InsurancePolicy>()
            //            .HasDiscriminator<string>("PolicyType")
            //            .HasValue<PolicyTypeEnum>("RCAuto")
            //            .HasValue<PolicyTypeEnum>("Furto")
            //            .HasValue<PolicyTypeEnum>("Vita");

            modelBuilder.Entity<Customer>()
                        .HasData(
                            new Customer
                            {
                                Id = 1,
                                FirstName = "Maria",
                                LastName = "Verdi",
                                Code = "VRDMRA7891LH2D67"

                            },
                            new Customer
                            {
                                Id = 2,
                                FirstName = "Luca",
                                LastName = "Rossi",
                                Code = "RSSLCA45H67LK097"
                            }
                );

            modelBuilder.Entity<InsurancePolicy>().HasData(
                    new InsurancePolicy()
                    {
                        Id = 1,
                        Number = 1872,
                        ExpirationDate = new DateTime(2025, 08, 09),
                        MonthlyRate = 80,
                        PolicyType = PolicyTypeEnum.RCAuto,
                        CustomerId = 2,
                        
                    }
                );
        }
    }
}
