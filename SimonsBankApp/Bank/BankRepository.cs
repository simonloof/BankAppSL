using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsBankApp.Bank
{
    public class BankRepository
    {
        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    CustomerNo = "A100",
                    Name = "Charlie Sheen",
                    BirthYear = new DateTime(1995,9,3).Date,
                    Accounts = new List<Account>
                    {
                        new Account
                        {
                            AccountNo = 1,
                            Balance = 100m
                        }
                    }
                },
                new Customer
                {
                    CustomerNo = "A200",
                    Name = "Sara Johansson",
                    BirthYear = new DateTime(1955,7,3).Date,
                    Accounts = new List<Account>
                    {
                        new Account
                        {
                            AccountNo = 2,
                            Balance = 200m
                        }
                    }
                },
                 new Customer
                {
                    CustomerNo = "A300",
                    Name = "Krister Johansson",
                    BirthYear = new DateTime(1957,7,3).Date,
                    Accounts = new List<Account>
                    {
                        new Account
                        {
                            AccountNo = 3,
                            Balance = 2000m
                        }
                    }
                },
            };
            return customers;
        }
    }
}
