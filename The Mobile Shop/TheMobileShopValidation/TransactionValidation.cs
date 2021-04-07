using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMobileShopCodeFirstFromDB;

namespace TheMobileShopValidation
{
    public static class TransactionValidation
    {
        public static bool EmployeeIsValid(this Transaction transaction)
        {
            using (TheMobileShopEntities context = new TheMobileShopEntities())
            {
                return context.Employees.Any(c => c.EmployeeId == transaction.EmployeeId);
            }
        }
        public static bool TransactionIsValid(this Transaction transaction)
        {
            return (transaction.TotalCost != 0 || transaction.TotalPrice != 0 || transaction.TaxAmount != 0 || transaction.PaymentMethod != null
                || transaction.Date != null || EmployeeIsValid(transaction));
        }
    }
}
