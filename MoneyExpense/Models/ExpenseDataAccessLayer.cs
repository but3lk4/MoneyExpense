using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoneyExpense.Models
{
    public class ExpenseDataAccessLayer
    {
        ExpenseDBContext db = new ExpenseDBContext();
        public IEnumerable<ExpenseReport> GetAllExpenses()
        {
            try
            {
                return db.ExpenseReport.ToList();
            }
            catch
            {
                throw;
            }
        }
        // filtrowanie za pomocą stringa
        public IEnumerable<ExpenseReport> GetSearchResult(string searchString)
        {
            List<ExpenseReport> exp = new List<ExpenseReport>();
            try
            {
                exp = GetAllExpenses().ToList();
                return exp.Where(x => x.ItemName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }
        //dodawanie wydatku  
        public void AddExpense(ExpenseReport expense)
        {
            try
            {
                db.ExpenseReport.Add(expense);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //update poszczególnego wydatku
        public int UpdateExpense(ExpenseReport expense)
        {
            try
            {
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //pobranie info o poszczególnym wydatku
        public ExpenseReport GetExpenseData(int id)
        {
            try
            {
                ExpenseReport expense = db.ExpenseReport.Find(id);
                return expense;
            }
            catch
            {
                throw;
            }
        }
        //usunięcie rekordu 
        public void DeleteExpense(int id)
        {
            try
            {
                ExpenseReport emp = db.ExpenseReport.Find(id);
                db.ExpenseReport.Remove(emp);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        // obliczanie ostatnich 6 miesięcy
        public Dictionary<string, decimal> CalculateMonthlyExpense()
        {
            ExpenseDataAccessLayer objexpense = new ExpenseDataAccessLayer();

            List<ExpenseReport> lstEmployee = new List<ExpenseReport>();

            Dictionary<string, decimal> dictMonthlySum = new Dictionary<string, decimal>();
            decimal foodSum = db.ExpenseReport.Where
                (cat => cat.Category == "Jedzenie" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
                .Select(cat => cat.Amount)
                .Sum();

            decimal shoppingSum = db.ExpenseReport.Where
               (cat => cat.Category == "Zakupy" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
               .Select(cat => cat.Amount)
               .Sum();

            decimal travelSum = db.ExpenseReport.Where
               (cat => cat.Category == "Podróże" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
               .Select(cat => cat.Amount)
               .Sum();

            decimal healthSum = db.ExpenseReport.Where
               (cat => cat.Category == "Zdrowie" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
               .Select(cat => cat.Amount)
               .Sum();

            dictMonthlySum.Add("Jedzenie", foodSum);
            dictMonthlySum.Add("Zakupy", shoppingSum);
            dictMonthlySum.Add("Podróże", travelSum);
            dictMonthlySum.Add("Zdrowie", healthSum);
            return dictMonthlySum;
        }
        // obliczanie ostatnich 4 tygodni
        public Dictionary<string, decimal> CalculateWeeklyExpense()
        {
            ExpenseDataAccessLayer objexpense = new ExpenseDataAccessLayer();

            List<ExpenseReport> lstEmployee = new List<ExpenseReport>();

            Dictionary<string, decimal> dictWeeklySum = new Dictionary<string, decimal>();
            decimal foodSum = db.ExpenseReport.Where
                (cat => cat.Category == "Jedzenie" && (cat.ExpenseDate > DateTime.Now.AddDays(-7)))
                .Select(cat => cat.Amount)
                .Sum();

            decimal shoppingSum = db.ExpenseReport.Where
               (cat => cat.Category == "Zakupy" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
               .Select(cat => cat.Amount)
               .Sum();

            decimal travelSum = db.ExpenseReport.Where
               (cat => cat.Category == "Podróże" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
               .Select(cat => cat.Amount)
               .Sum();

            decimal healthSum = db.ExpenseReport.Where
               (cat => cat.Category == "Zdrowie" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
               .Select(cat => cat.Amount)
               .Sum();

            dictWeeklySum.Add("Jedzenie", foodSum);
            dictWeeklySum.Add("Zakupy", shoppingSum);
            dictWeeklySum.Add("Podróże", travelSum);
            dictWeeklySum.Add("Zdrowie", healthSum);
            return dictWeeklySum;
        }
    }
}
