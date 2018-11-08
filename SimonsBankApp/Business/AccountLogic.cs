﻿using SimonsBankApp.Bank;
using SimonsBankApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsBankApp.Business
{
    public class AccountLogic
    {
        private readonly BankRepository _bankRepository;

        public AccountLogic(BankRepository bankRepository)
        {
            _bankRepository = bankRepository;

        }
        public AccountViewModel WithDrawal(int accountNo, int sum)
        {
            var accountViewModel = new AccountViewModel();
            var customers = _bankRepository.Customers;

            if (customers.Any(x => x.Accounts.Any(z => z.AccountNo == accountNo)))
            {
                var customer = customers.First(x => x.Accounts.First().AccountNo == accountNo);
                var account = customer.Accounts.Single();
                var status = account.WithDrawal(sum);
                if (status == "success")
                {
                    accountViewModel.Account = account;
                    accountViewModel.Customer = customer;
                    accountViewModel.BalanceChange = sum;
                    accountViewModel.Success = true;
                    accountViewModel.Message = "Uttag genomfört!";
                    accountViewModel.Action = AccountActionType.Withdrawal;
                }
                else
                {
                    accountViewModel.Success = false;
                    accountViewModel.Message = status;
                }
            }
            else
            {
                accountViewModel.Success = false;
                accountViewModel.Message = "Det finns inget konto med det kontonummret!";
            }
            return accountViewModel;
        }

        public AccountViewModel Transfer(int sourceAccountNo, int targetAccountNo, int sum)
        {
            var accountViewModel = new AccountViewModel();
            var customers = _bankRepository.Customers;

            var sourceAccount = customers.FirstOrDefault(c => c.Accounts.Any(a => a.AccountNo == sourceAccountNo))
                                ?.Accounts.Single(a => a.AccountNo == sourceAccountNo);
            var targetAccount = customers.FirstOrDefault(c => c.Accounts.Any(a => a.AccountNo == targetAccountNo))
                                ?.Accounts.Single(a => a.AccountNo == targetAccountNo);

            if (sourceAccount == null || targetAccount == null)
            {
                accountViewModel.Success = false;
                accountViewModel.Message = "Från-konto eller till-konto finns ej!";
            }
            else
            {
                accountViewModel.Action = AccountActionType.Transfer;

            }

            return accountViewModel;

        }

        public AccountViewModel Deposit(int accountNo, int sum)
        {
            var accountViewModel = new AccountViewModel();
            var customers = _bankRepository.Customers;

            if (customers.Any(x => x.Accounts.Any(z => z.AccountNo == accountNo)))
            {
                var customer = customers.First(x => x.Accounts.First().AccountNo == accountNo);
                var account = customer.Accounts.Single();
                var status = account.Deposit(sum);

                if (status == "success")
                {
                    accountViewModel.Account = account;
                    accountViewModel.Customer = customer;
                    accountViewModel.BalanceChange = sum;
                    accountViewModel.Success = true;
                    accountViewModel.Message = "Insättning genomförd!";
                    accountViewModel.Action = AccountActionType.Deposit;
                }
                else
                {
                    accountViewModel.Message = status;
                }

            }
            else
            {
                accountViewModel.Success = false;
                accountViewModel.Message = "Det finns inget konto med det kontonummret!";
            }
            return accountViewModel;
        }
    }
}
