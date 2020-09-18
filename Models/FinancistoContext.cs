using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancistoR.Models.Maps;
using Microsoft.EntityFrameworkCore;

namespace FinancistoR.Models
{
    public class FinancistoContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public FinancistoContext(DbContextOptions<FinancistoContext>options):base(options)
        {


        }

        public FinancistoContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountMap());   
        }
    }
}
