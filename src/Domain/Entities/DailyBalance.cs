using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DailyBalance
    {
        public DateTime Date { get; private set; }
        public decimal TotalCredits { get; private set; }
        public decimal TotalDebits { get; private set; }

        public decimal Balance => TotalCredits - TotalDebits;

        public DailyBalance(DateTime date)
        {
            Date = date.Date;
        }

        public void AddCredit(decimal amount)
        {
            TotalCredits += amount;
        }

        public void AddDebit(decimal amount)
        {
            TotalDebits += amount;
        }
    }
}
