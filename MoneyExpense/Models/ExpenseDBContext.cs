using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoneyExpense.Models
{
    public class ExpenseDBContext:DbContext
    {
        public virtual DbSet<ExpenseReport> ExpenseReport { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QIFFI9I\\SQLE2016;Initial Catalog=Budget;Persist Security Info=True;Integrated Security = true");
            }
        }
    }
}
