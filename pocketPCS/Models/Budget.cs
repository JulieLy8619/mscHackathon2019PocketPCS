using System;
using System.Collections.Generic;

namespace pcsHackathon2019.Models
{
    public class Budget
    {
        public string Name;

        public Move move;
        public virtual ICollection<Allowance> Allowances { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public double ExpenseTotal
        {
            get
            {
                double sum = 0.0;
                foreach (var expense in Expenses)
                {
                    sum += expense.Cost;
                }
                return sum;
            }
        }
        public double AllowanceTotal
        {
            get
            {
                double sum = 0.0;
                foreach (var allowance in Allowances)
                {
                    sum += allowance.Cost;
                }
                return sum;
            }
        }

        //public void AddAllowance(Allowance allowance)
        //{
        //    Allowances.Add(allowance);
        //}

        //public void AddExpense(Expense expense)
        //{
        //    Expenses.Add(expense);
        //}

        //public double CalculateDelta()
        //{
        //    return AllowanceTotal - ExpenseTotal;
        //}

        public Budget(string name)
        {
            this.Name = name;
        }

        
    }
}
