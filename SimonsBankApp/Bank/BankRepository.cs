using SimonsBankApp.Business;
using SimonsBankApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsBankApp.Bank
{
    public class BankRepository
    {
        private static BankRepository instance = null;
        private static readonly object padlock = new object();
        private AccountLogic _accountLogic;

        private List<Customer> _customers;
        public BankRepository()
        {
            _customers = GetCustomers();
            _accountLogic = new AccountLogic(this);
        }

        public static void Reset()
        {
            instance = null;
        }
        public static BankRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BankRepository();
                    }
                    return instance;
                }
            }
        }
        public List<Customer> Customers
        {
            get { return _customers; }
        }
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
