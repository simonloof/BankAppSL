using SimonsBankApp.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsBankApp.ViewModels
{
    public class AccountViewModel
    {
        public Customer Customer { get; set; }
        public Account Account { get; set; }
        public Account TargetAccount { get; set; }
        public decimal BalanceChange { get; set; }
        public AccountActionType Action { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }



    }
}
