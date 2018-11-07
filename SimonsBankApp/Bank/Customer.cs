using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsBankApp.Bank
{
    public class Customer
    {
        public string CustomerNo { get; set; }
        public string Name { get; set; }

        public DateTime BirthYear { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
